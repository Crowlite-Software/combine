using Sandbox;
using Sandbox.UI;

namespace CombineControl.UI
{
	public partial class CCHud : Hud
	{
		public CCHud()
		{
			if ( !IsClient )
				return;

			RootPanel.AddChild<NameTags>();
			RootPanel.AddChild<CrosshairCanvas>();
			RootPanel.AddChild<ChatBox>();
		}
	}
}
