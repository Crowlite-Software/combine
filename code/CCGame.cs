using CombineControl.Systems;
using CombineControl.UI;
using Sandbox;
using System.Collections.Generic;
using System.Linq;

namespace CombineControl
{
	[Library( "combine" )]
	public partial class CCGame : Game
	{
		public CCGame()
		{
			if ( IsServer )
			{
				new CCHud();
			}

			// Initialise all of our systems
			// I'm not sure if this is the best method, but it's good enough for now.
			var allSystems = from system in Library.GetAll<BaseSystem>()
							 where !system.IsAbstract
							 select system;
			foreach ( var system in allSystems )
			{
				var systemClass = Library.Create<BaseSystem>( system.FullName );
				Log.Info( $"Found and initialising: {system.FullName}" );

				if ( systemClass.Init() )
				{
					BaseSystem.SystemsList.Add( systemClass );
				}
			}
		}

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new CCPlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}
}
