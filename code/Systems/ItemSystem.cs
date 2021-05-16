using CombineControl.Entities;
using CombineControl.Items;
using Sandbox;
using System;
using System.Collections.Generic;

namespace CombineControl.Systems
{
	public class ItemSystem : NetworkClass
	{
		public static List<BaseItem> Items = new List<BaseItem>();

		public ItemSystem()
		{

		}

		private void LoadItems()
		{
			// Clear the list of previous items, just in case.
			Items.Clear();

			foreach ( var item in Library.GetAllAttributes<BaseItem>() )
			{
				// Ignore the base items
				// Todo: Make these not hardcoded. I'm sure we're gonna have more than just 3 base classes.
				if ( item.Title == "CombineControl.Items.BaseItem" || item.Title == "CombineControl.Items.BaseWeaponItem" || item.Title == "CombineControl.Items.BaseClothingItem" )
					continue;

				Log.Info( $"Found item: {item.Title}" );
			}

		}

		// Todo: Make string into BaseItem when we get item system working.
		public static void CreatePhysicalItem(string item, Vector3 pos, Angles ang)
		{
			if ( item == null )
				return;

			var ent = new ItemEntity();
			ent.SetItem( new Melon() );

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

			Vector3 pos = Vector3.Zero;
			Angles ang = new Angles( 0, owner.EyeAng.yaw, 0 );

			var tr = Trace.Ray( owner.EyePos, owner.EyePos + owner.EyeRot.Forward * 200 )
				.UseHitboxes()
				.Ignore( owner )
				.Size( 2 )
				.Run();

			pos = tr.EndPos;

			CreatePhysicalItem( item, pos, ang);
		}

		[ServerCmd( "rpa_reloaditems" )]
		public static void ReloadItemsCmd()
		{
			var _ = new ItemSystem();
			_.LoadItems();
		}
	}
}
