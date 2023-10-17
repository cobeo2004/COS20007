using System;
namespace SwinAdventure
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private Location _location;

		public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
		{
			_inventory = new Inventory();
		}

		public GameObject Locate(string id)
		{
			GameObject gameObject;

			if (AreYou(id))
				return this;
            gameObject = _inventory.Fetch(id);
			if (gameObject != null)
				return gameObject;
			if (_location != null)
			{
				gameObject = _location.Locate(id);
				return gameObject;
			}

			return null;
		}

        public override string FullDescription
		{
			get
			{
				return $"You are {Name}, {base.FullDescription}. You are carrying:\n{_inventory.ItemList}";
			}
		}

		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}

		public Location CurrentLocation
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}

		public void Move(Path pth)
		{
			if (pth.Destination != null)
				_location = pth.Destination;
		}
	}
}

