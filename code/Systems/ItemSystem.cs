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
	public class ItemSystem : BaseSystem
	{
		public static List<BaseItem> Items = new List<BaseItem>();

		public ItemSystem()
		{

		}

		public override bool Init()
		{
			// Load our items into CC
			LoadItems();

			return true;
		}

		/// <summary>
		/// Finds all of our item classes and adds them to the global list of items.
		/// </summary>
		private void LoadItems()
		{
			// Clear the list of previous items, just in case.
			Items.Clear();

			// Find all our item classes and ignore those listed as abstract
			var foundItems = from item in Library.GetAll<BaseItem>()
							 where !item.IsAbstract
							 select item;
			foreach ( var item in foundItems )
			{

				var itemClass = Library.Create<BaseItem>( item.FullName );
				Log.Info( $"Found item: {itemClass.ItemName}" );

				Items.Add( itemClass );
			}
		}

		// Todo: Make string into BaseItem when we get item system working.
		public static void CreatePhysicalItem( BaseItem item, Vector3 pos, Angles ang )
		{
			if ( item == null )
				return;

			var ent = new ItemEntity();
			ent.SetItem( item );

			ent.Position = pos;
			ent.Rotation = Rotation.From( ang );

			// Todo: Think about moving this to the item instead;
			ent.SetModel( ent.Item.ItemModel );


			Log.Info( $"Item is: {item}, Position: {pos}, Angles: {ang}" );
		}

		///
		/// Console Commands
		///

		[ServerCmd( "rpa_spawnitem" )]
		public static void CreateItemCmd( string item )
		{
			var owner = ConsoleSystem.Caller.Pawn;

			if ( owner == null )
				return;

			BaseItem itemClass = ItemUtils.GetItemByName( item );

			// Check to make sure we've actually returned an item.
			if ( itemClass == null )
			{
				Log.Info( $"Error: {item} could not be found." );
				return;
			}

			Log.Info( $"{itemClass}" );

			Vector3 pos = Vector3.Zero;
			Angles ang = new Angles( 0, owner.EyeRot.Angles().yaw, 0 );

			var tr = Trace.Ray( owner.EyePos, owner.EyePos + owner.EyeRot.Forward * 200 )
				.UseHitboxes()
				.Ignore( owner )
				.Size( 2 )
				.Run();

			pos = tr.EndPos;

			CreatePhysicalItem( itemClass, pos, ang );
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
		public static void ListItemsCmd( string filter = "" )
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
