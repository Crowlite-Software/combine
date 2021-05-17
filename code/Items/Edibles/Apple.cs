using Sandbox;
using System;

namespace CombineControl.Items
{
	[Library]
	public partial class Apple : BaseItem
	{
		public override string ItemName => "Apple";
		public override string ItemDescription => "A juicy apple.";
		public override string ItemModel => "models/citizen_props/cardboardbox01.vmdl";
	}
}
