using Sandbox;
using System;

namespace CombineControl.Items
{
	[Library]
	public partial class Melon : BaseItem
	{
		public override string ItemName => "Melon";
		public override string ItemDescription => "A decently sized watermelon, looks tasty.";
		public override string ItemModel => "models/citizen_props/coin01.vmdl";
	}
}
