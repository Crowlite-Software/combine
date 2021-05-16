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
				// Todo: Add hud entity soon
			}
		}

		public override Player CreatePlayer()
		{
			return new CCPlayer();
		}
	}
}
