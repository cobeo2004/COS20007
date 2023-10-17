/*
Using.cs - Importer

global using NUnit.Framework;
global using System;
global using System.Collections.Generic;
global using System.Linq;

*/

namespace SwinAdventureTest
{
	[TestFixture]
	public class ItemTest
	{
		public Item testItem;

		[SetUp]
		public void SetUp()
		{
			testItem = new Item(new string[] { "shovel" }, "a shovel", "This is a might fine...");
		}

		[Test]
		public void TestItemIsIdentifiable()
		{
			Assert.True(testItem.AreYou("shovel"));
		}

		[Test]
		public void TestShortDescription()
		{
			Assert.That(testItem.ShortDescription, Is.EqualTo("a shovel (shovel)"));
		}

		[Test]
		public void TestFullDescription()
		{
			Assert.That(testItem.FullDescription, Is.EqualTo("This is a might fine..."));
		}
	}
}

