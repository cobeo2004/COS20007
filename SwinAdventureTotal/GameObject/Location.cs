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

		public Location(string name, string description, List<Path> listOfPaths) : this(name, description)
		{
			_listOfPaths = listOfPaths;
		}


		public GameObject Locate(string identifier)
		{
			if (AreYou(identifier))
				return this;

			foreach(Path path in _listOfPaths)
				if (path.AreYou(identifier))
					return path;
			
			return _inventory.Fetch(identifier);
		}

		public void AddPath(Path path)
		{
			_listOfPaths.Add(path);
		}

		public string ListOfPath
		{
			get
			{
				string pathList = "" + "\n";
				if (_listOfPaths.Count == 0)
					return "Currently there are no available routes!";

				pathList += "There are available routes to: ";
				for (int i = 0; i < _listOfPaths.Count; i++)
				{
					if (i != _listOfPaths.Count - 1)
						pathList += _listOfPaths[i].FirstId + ", ";
					else
						pathList += "and " + _listOfPaths[i].FirstId + ".";
				}

				return pathList;
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
                return $"You are at location of {base.Name}\nDescription: {base.FullDescription}\nItems at location:\n{ItemList}\nPath description: {ListOfPath}\n";
            }
        }

        public override string ShortDescription
        {
            get
            {
                return $"You are at location of {base.Name}";
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

