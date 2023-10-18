using System;
namespace SwinAdventure
{
	public class Location : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private List<Path> _listOfPaths;

		public Location(string name, string description) : base(new string[] { "location" }, name, description)
		{
			_inventory = new Inventory();
			_listOfPaths = new List<Path>();
		}

		//public Location(string name, string description, List<Path> listOfPaths) : this(name, description)
		//{
		//	_listOfPaths = listOfPaths;
		//}


		public GameObject Locate(string identifier)
		{
			if (AreYou(identifier))
				return this;

			foreach (Path path in _listOfPaths)
				if (path.AreYou(identifier))
					return path;

			return _inventory.Fetch(identifier);
		}

		public void AddPathTo(Path path)
		{
			_listOfPaths.Add(path);
		}

		public string PathList
		{
			get
			{
				string fullPath = "" + "\n";
				if (_listOfPaths.Count == 0)
					return "Currently there are no available routes!";

				fullPath += "There are available routes to: ";
				if (_listOfPaths.Count == 1)
				{
					fullPath += _listOfPaths[0].FirstId + ".";
				}
				else
				{
					int i = 0;
					while (i < _listOfPaths.Count)
					{
						if (i != _listOfPaths.Count - 1)
							fullPath += _listOfPaths[i].FirstId + ", ";
						else
						{
							fullPath += "and " + _listOfPaths[i].FirstId + ".";
							break;
						}
					}
				}
                return fullPath;
            }
		} 

		public string ItemList
		{
			get
			{
				if (_inventory.Count == 0)
				{
					return "";
				}
				return $"{inventory.ItemList}";
			}
		}

        public override string FullDescription
        {
            get
            {
				return $"You are at location of {Name}\nDescription: {base.FullDescription}\nItems at location:\n{ItemList}\nPath description: {PathList}\n";

			}
        }

        public Inventory inventory
        {
			get
			{
				return _inventory;
			}
        }

    }
}

