using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace CombineControl.UI
{
	/// <summary>
	/// 
	/// </summary>
	/// 
	/// Todo: Add all the stuff we need here, currently we don't really have anything
	public class PlayerInfo : Panel
	{
		public Label Name;
		public Label Balance;
		public Label ID;

		public PlayerInfo()
		{
			StyleSheet.Load( "/ui/PlayerInfo.scss" );

			// Add placeholder labels
			Name = Add.Label( "John Doe", "name" );
			Balance = Add.Label( "0 Credits", "balance" );
			ID = Add.Label( "CID #000000", "id" );
		}

		public override void Tick()
		{
			var player = Player.Local as CCPlayer;

			// Probably not a good idea to put these on Tick() but idk where else to put em.
			Name.Text = player.Name;
			//Balance.Text = Balance.Text;
			ID.Text = player.SteamId.ToString();
		}

	}
}
