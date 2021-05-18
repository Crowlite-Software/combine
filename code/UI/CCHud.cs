using Sandbox;
using Sandbox.UI;

namespace CombineControl.UI
{
	public partial class CCHud : HudEntity<RootPanel>
	{
		public CCHud()
		{
			if ( !IsClient )
				return;

			RootPanel.AddChild<NameTags>();
			RootPanel.AddChild<CrosshairCanvas>();
			RootPanel.AddChild<ChatBox>();

			// Player Info
			RootPanel.AddChild<PlayerInfo>();
		}
	}
}
