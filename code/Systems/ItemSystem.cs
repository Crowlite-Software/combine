using CombineControl.Entities;
using CombineControl.Items;
using CombineControl.Util;
using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CombineControl.Systems
{
	/// <summary>
	///
	/// </summary>
	///
	/// Todo: Change all to work with an ID rather than name, this is because some items will have the same names roughly.
	public class ItemSystem : NetworkClass
	{
		public static List<BaseItem> Items = new List<BaseItem>();

		public ItemSystem()
		{

		}

		/// <summary>
		/// Finds all of our item classes and adds them to the global list of items.
		/// </summary>
		private void LoadItems()
		{
			// Clear the list of previous items, just in case.
			Items.Clear();

			foreach ( var item in Library.GetAll<BaseItem>() )
			{
				// Ignore the base items
				// Todo: Make these not hardcoded. I'm sure we're gonna have more than just 3 base classes.
				if ( item.FullName == "CombineControl.Items.BaseItem" || item.FullName == "CombineControl.Items.BaseWeaponItem" || item.FullName == "CombineControl.Items.BaseClothingItem" )
					continue;

				var itemClass = Library.Create<BaseItem>( item.FullName );
				Log.Info( $"Found item: {itemClass.ItemName}" );

				Items.Add( itemClass );
			}

			foreach ( var item in Items )
			{
				Log.Info( $"Found item in our list: {item.ItemName}" );
			}
		}

		// Todo: Make string into BaseItem when we get item system working.
		public static void CreatePhysicalItem(BaseItem item, Vector3 pos, Angles ang)
		{
			if ( item == null )
				return;

			var ent = new ItemEntity();
			ent.SetItem( item );

			ent.WorldPos = pos;
			ent.WorldRot = Rotation.From( ang );

			// Todo: Think about moving this to the item instead;
			ent.SetModel( ent.Item.ItemModel );


			Log.Info( $"Item is: {item}, Position: {pos}, Angles: {ang}" );
		}

		///
		/// Console Commands
		///

		[ServerCmd( "rpa_spawnitem" )]
		public static void CreateItemCmd(string item)
		{
			var owner = ConsoleSystem.Caller;

			if ( owner == null )
				return;

			BaseItem itemClass = ItemUtils.GetItemByName( item );
			Log.Info( $"{itemClass}" );

			Vector3 pos = Vector3.Zero;
			Angles ang = new Angles( 0, owner.EyeAng.yaw, 0 );

			var tr = Trace.Ray( owner.EyePos, owner.EyePos + owner.EyeRot.Forward * 200 )
				.UseHitboxes()
				.Ignore( owner )
				.Size( 2 )
				.Run();

			pos = tr.EndPos;

			CreatePhysicalItem( itemClass, pos, ang);
		}

		[ServerCmd( "rpa_reloaditems" )]
		public static void ReloadItemsCmd()
		{
			var _ = new ItemSystem();
			_.LoadItems();
		}

		/// <summary>
		/// Lists all the items with a search filter so we can search
		/// for a specific item.
		/// </summary>
		/// <param name="filter">The filter we will search for</param>
		[ServerCmd( "rpa_listitems" )]
		public static void ListItemsCmd(string filter = "")
		{
			if ( filter == "" )
				Log.Info( "Item List:" );
			else
				Log.Info( $"Item List: (Filter: {filter})" );
			
			foreach ( BaseItem item in ItemUtils.GetAllItems( filter ) )
			{
				Log.Info( $"Item: {item.ItemName}" );
			}
		}
	}
}
