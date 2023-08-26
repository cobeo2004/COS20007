/*
Using.cs - Importer

global using NUnit.Framework;
global using System;
global using System.Collections.Generic;
global using System.Linq;

*/

namespace SwinAdventure
{
	[TestFixture]
	public class InventoryTest
	{
		public Item sword;
		public Item fireWork;

        [SetUp]
		public void SetUp()
		{
			sword = new Item(new string[] { "Thanh Kiem", "Cuong Dao Guinsoo", "sword", "Dao Choc Tiet Lon" }, "sword", "This is a sword");
            fireWork = new Item(new string[] { "Phao Hoa", "Fire Work" }, "firework", "This is a firework");
        }

		[Test]
		public void TestFindItem()
		{
			Inventory inventory = new Inventory();
			inventory.Put(sword);
			Assert.IsTrue(inventory.HasItem(sword.FirstId));
		}

		[Test]
		public void TestNoItemFind()
		{
			Inventory inventory = new Inventory();
			inventory.Put(sword);
			Assert.False(inventory.HasItem(fireWork.FirstId));
		}

		[Test]
		public void TestFetchItem()
		{
			Inventory inventory = new Inventory();
			inventory.Put(sword);
			inventory.Put(fireWork);
			Item fetchedItem = inventory.Fetch(sword.FirstId);
			Assert.IsTrue(fetchedItem == sword);
			Assert.IsTrue(inventory.HasItem(sword.FirstId));
			
		}

		[Test]
		public void TestTakeItem()
		{
			Inventory inventory = new Inventory();
			inventory.Put(sword);
			inventory.Put(fireWork);
			Item takenItem = inventory.Fetch(sword.FirstId);
			Assert.IsTrue(takenItem == sword);
			Assert.IsTrue(inventory.HasItem(sword.FirstId));
		}

		[Test]
		public void TestItemList()
		{
            Inventory inventory = new Inventory();
            inventory.Put(sword);
            inventory.Put(fireWork);

			Assert.IsTrue(inventory.HasItem(sword.FirstId));
			Assert.IsTrue(inventory.HasItem(fireWork.FirstId));

			Assert.That(inventory.ItemList, Is.EqualTo("sword (thanh kiem)\n" + "firework (phao hoa)\n"));

        }

	}
}

