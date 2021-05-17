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
		public static IEnumerable<BaseItem> GetAllItems(string filter = "")
		{
			return from item in ItemSystem.Items where item.ItemName.Contains( filter, StringComparison.OrdinalIgnoreCase ) select item;
		}
	}
}
