/*
Using.cs - Importer

global using NUnit.Framework;
global using System;
global using System.Collections.Generic;
global using System.Linq;

*/


namespace SwinAdventure
{
	public class PlayerTest
	{
		public Player player;
		public Item sword;
		public Item fireWork;

		[SetUp]
		public void SetUp()
		{
			player = new Player("simon", "a person that makes this game");
            sword = new Item(new string[] { "Thanh Kiem", "Cuong Dao Guinsoo", "sword", "Dao Choc Tiet Lon" }, "sword", "This is a sword");
            fireWork = new Item(new string[] { "Phao Hoa", "Fire Work" }, "firework", "This is a firework");
            player.Inventory.Put(sword);
            player.Inventory.Put(fireWork);
        }

		[Test]
		public void TestPlayerIsIdentifiable()
		{
			Assert.IsTrue(player.AreYou("me") && player.AreYou("inventory"));
		}

		[Test]
		public void TestPlayerLocatesItems()
		{
			Item locatedItem = (Item)player.Locate(sword.FirstId);
			string takenItem = "";
			string remainsItem = "";

			if(locatedItem == sword)
			{
				takenItem = player.Inventory.Take(sword.FirstId).ShortDescription;
				remainsItem = player.Inventory.ItemList;
			}

			Assert.AreEqual("sword (thanh kiem)", takenItem);
			Assert.AreEqual("firework (phao hoa)\n", remainsItem);

		}

		[Test]
		public void TestPlayerLocatesItself()
		{
			GameObject? me = player.Locate("me");
			GameObject? inventory = player.Locate("inventory");
			bool result = false;

			if (me == player || me == inventory)
			{
				result = true;
			}

			Assert.IsTrue(result);
		}

		[Test]
		public void TestPlayerLocatesNothing()
		{
			GameObject? nothing = player.Locate("Bonsoir");
			Assert.IsNull(nothing);
		}

		[Test]
		public void TestPlayerFullDescription()
		{
			Assert.That("You are simon, a person that makes this game. You are carrying:\nsword (thanh kiem)\nfirework (phao hoa)\n", Is.EqualTo(player.FullDescription));
		}
	}
}

