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

		public override Player CreatePlayer()
		{
			return new CCPlayer();
		}
	}
}
