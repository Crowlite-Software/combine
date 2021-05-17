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
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public static IEnumerable<BaseItem> GetAllItems(string filter = "")
		{
			return from item in ItemSystem.Items where item.ItemName.Contains( filter, StringComparison.OrdinalIgnoreCase ) select item;
		}
	}
}
