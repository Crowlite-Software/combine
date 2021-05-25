using CombineControl.Items;
using CombineControl.Systems;
using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CombineControl.Util
{
	public static class ItemUtils
	{
		/// <summary>
		/// Lists all the items in CombineControl or, if specified, lists all the items
		/// matching the filter.
		/// </summary>
		/// <param name="filter">Optional search filter</param>
		/// <returns>A list of the items within the filter</returns>
		public static IEnumerable<BaseItem> GetAllItems( string filter = "" )
		{
			return from item in ItemSystem.Items 
				   where item.ItemName.Contains( filter, StringComparison.OrdinalIgnoreCase ) || item.ItemId.Contains( filter, StringComparison.OrdinalIgnoreCase )  
				   select item;
		}

		/// <summary>
		/// Finds the item we provide in the search variable.
		/// </summary>
		/// <param name="search">The item name we are searching for</param>
		/// <returns>The item class that we have found, returns null if no item was found</returns>
		[Obsolete("Use GetItemById instead")]
		public static BaseItem GetItemByName( string search )
		{
			if ( !string.IsNullOrEmpty( search ) )
			{
				BaseItem foundItem = ItemSystem.Items.Find( x => x.ItemName.Equals( search, StringComparison.OrdinalIgnoreCase ) );

				return foundItem;
			}

			return null;
		}

		/// <summary>
		/// Finds the item we provide in the search variable.
		/// </summary>
		/// <param name="search">The item id we are searching for</param>
		/// <returns>The item class that we have found, returns null if no item was found</returns>
		public static BaseItem GetItemById( string search )
		{
			if ( !string.IsNullOrEmpty( search ) )
			{
				BaseItem foundItem = ItemSystem.Items.Find( x => x.ItemId.Equals( search, StringComparison.OrdinalIgnoreCase ) );

				return foundItem;
			}

			return null;
		}
	}
}
