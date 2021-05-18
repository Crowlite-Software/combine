using CombineControl.UI;
using Sandbox;

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
