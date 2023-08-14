using System;
using SwinAdventure;
namespace SwinAdventureMain
{
	public class Program
	{
		public static void Main()
		{
			Item item = new Item(new string[] { "showel" }, "showel", "This is a shovel");

			Console.WriteLine(item.ShortDescription);
			Console.WriteLine(item.FullDescription);
		}
	}
}

