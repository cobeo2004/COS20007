namespace SwinAdventure;

public class ItemObjectTest
{
    Item shovel;
    Item sword;

    [SetUp]
    public void SetUp()
    {
        shovel = new Item(new string[] { "shovel" }, "shovel", "this is a shovel");
        sword = new Item(new string[] { "sword" }, "sword", "this is a sword");
    }

    [Test]
    public void TestItemIsIdentifiable()
    {
        var trueResult = shovel.AreYou("shovel");
        Assert.IsTrue(trueResult);

        var falseResult = shovel.AreYou("sword");
        Assert.IsFalse(falseResult);
    }

    [Test]
    public void TestItemShortDescription()
    {

    }

    [Test]
    public void TestItemLongDescription()
    {

    }
}
