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
		public Panel GeneralPanel;

		public Label Name;
		public Label Balance;
		public Label ID;

		public Panel HealthPanel;
		public Panel HealthBar;

		public PlayerInfo()
		{
			StyleSheet.Load( "/ui/PlayerInfo.scss" );

			GeneralPanel = Add.Panel( "generalpanel" );
			{
				// Add placeholder labels
				Name = GeneralPanel.Add.Label( "John Doe", "name" );
				Balance = GeneralPanel.Add.Label( "0 Credits", "balance" );
				ID = GeneralPanel.Add.Label( "CID #000000", "id" );
			}
			// Info bars
			HealthPanel = Add.Panel( "healthpanel" );
			{
				HealthBar = HealthPanel.Add.Panel( "progress-bar" );
			}
		}

		public override void Tick()
		{
			//var player = Local.Pawn as CCPlayer;

			// Probably not a good idea to put these on Tick() but idk where else to put em.
			Name.Text = Local.DisplayName;
			//Balance.Text = Balance.Text;
			ID.Text = Local.SteamId.ToString();
		}

	}
}
