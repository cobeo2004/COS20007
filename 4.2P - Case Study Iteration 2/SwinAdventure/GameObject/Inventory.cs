using System;
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
			foreach(Item i in _items)
			{
				if (i.AreYou(id))
				{
					return true;
				}
			}
			return false;
		}

		public void Put(Item item)
		{
			_items.Add(item);
		}

		public Item Take(string id)
		{
			Item takenItem = Fetch(id);
			_items.Remove(takenItem);
			return takenItem;
		}

		public Item Fetch(string id)
		{
			Item? item = null;
			foreach(Item i in _items)
			{
				if (i.AreYou(id))
					item = i;
			}
			return item;
		}

		public string ItemList
		{
			get
			{
				string listOfItems = "";
				foreach(Item i in _items)
				{
					listOfItems = listOfItems + i.ShortDescription + "\n";
				}
				return listOfItems;
			}
		}
	}
}

