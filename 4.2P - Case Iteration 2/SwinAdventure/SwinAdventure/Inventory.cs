using System;
using System.Collections.Generic;
namespace SwinAdventure
{
	public class Inventory
	{
		private List<Item> _items;

		public Inventory()
		{
			_items = new List<Item>();
		}

		public bool HasItem(string id)
		{
			foreach (Item item in _items)
				if (item.AreYou(id))
					return true;
			return false;
		}

		public void Put(Item itm)
		{
			_items.Add(itm);
		}

		public Item Take(string id)
		{
			Item takenItem = Fetch(id);
			_items.Remove(takenItem!);
			return takenItem;
		}

		public Item Fetch(string id)
		{
			foreach (Item item in _items)
				if (item.AreYou(id))
					return item;
			return null;
		}

		public string ItemList
		{
			get
			{
				string listOfItem = "";

				foreach(Item item in _items)
				{
					listOfItem = listOfItem + item.ShortDescription + "\n";
				}

				return listOfItem;
			}
		}
	}
}

