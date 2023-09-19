using System;
namespace SwinAdventure
{
	public interface IHaveInventory
	{
		public GameObject Locate(string id);
		public string Name
		{
			get;
		}
	}
}

