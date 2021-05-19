using Sandbox;

namespace CombineControl.Items
{
	/// <summary>
	/// Holds all the relevent information that an item would need
	/// such as name, model, weight and more.
	/// </summary>
	/// 
	/// Todo: Figure out if these variables should be public or protected.
	/// Todo: Allow items to customise their use feature, possibly something like Helix's ItemFunctions.
	public abstract class BaseItem : NetworkClass
	{
		// Todo: See if we actually need this.
		public virtual string ItemID => "base_item";

		public virtual string ItemName => "BaseItem";
		public virtual string ItemModel => "models/dev/error.vmdl";
		public virtual string ItemDescription => "This item has no description, contact a programmer.";

		// Inventory stuff
		public virtual int ItemWeight => 1;

		public virtual bool IsUsable => false;
		public virtual bool DeleteOnUse => false;
		public virtual string UseText => null;

		// This means can the item be thrown out
		public virtual bool IsThrowable => true;

		// Generally this is usually always true, I don't see a time when it wouldn't be
		public virtual bool IsDroppable => true;

		// Todo: Possible look at some other things we could use here aswell.
		protected virtual void OnPlayerUse( BaseItem item, Player player ) { }
		protected virtual void OnPlayerPickup( BaseItem item, Player player ) { }

	}
}
