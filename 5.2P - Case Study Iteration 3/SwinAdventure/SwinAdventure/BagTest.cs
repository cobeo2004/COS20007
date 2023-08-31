namespace SwinAdventure;

[TestFixture]
public class BagTest
{

    private Bag b;
    private Bag b1;
    private Item sword;
    private Item gun;
    private Item food;
    private Item fireWork;

    [SetUp]
    public void Setup()
    {
        b = new Bag(new string[] { "bag" }, "bag", "a bag");
        b1 = new Bag(new string[] { "bag1" }, "bag1", "a bag1");
        sword = new Item(new string[] { "Thanh Kiem", "Cuong Dao Guinsoo", "Sword" }, "sword", "a sword");
        gun = new Item(new string[] { "Sung cua Tran Dan", "gun" }, "gun", "a gun");
        food = new Item(new string[] { "Thien linh tinh qua", "god's food" }, "food", "a food");
        fireWork = new Item(new string[] { "Phao Hoa", "Jinx" }, "firework", "a firework");

        b.Inventory.Put(sword);
        b.Inventory.Put(gun);

        b1.Inventory.Put(food);
        b1.Inventory.Put(fireWork);
    }

    [Test]
    public void TestBagLocatesItems()
    { 
        Assert.IsTrue(b.Locate(sword.FirstId)== sword);
        Assert.IsTrue(b1.Locate(fireWork.FirstId)== fireWork);
        Assert.IsTrue(b.Inventory.HasItem(sword.FirstId));
        Assert.IsTrue(b1.Inventory.HasItem(fireWork.FirstId));
    }

    [Test]
    public void TestBagLocateSelf()
    {
        Assert.IsTrue(b.Locate("bag") == b);
        Assert.IsTrue(b1.Locate(b1.FirstId) == b1);
    }

    [Test]
    public void TestBagLocatesNothing()
    {
        Assert.IsNull(b.Locate(fireWork.FirstId));
        Assert.IsNull(b1.Locate(sword.FirstId));
    }

    [Test]
    public void TestBagFullDescription()
    {
        Assert.That(b.FullDescription, Is.EqualTo("In the bag you can see:\nsword (thanh kiem)\ngun (sung cua tran dan)\n"));
        Assert.That(b1.FullDescription, Is.EqualTo("In the bag1 you can see:\nfood (thien linh tinh qua)\nfirework (phao hoa)\n"));
    }

    [Test]
    public void TestBagInBag()
    {
        Bag b2 = new Bag(new string[] { "bag2" }, "bag2", "a bag2");
        b1.Inventory.Put(b2);
        b2.Inventory.Put(sword);

        Assert.IsTrue(b1.Locate(b2.FirstId) == b2);
        Assert.IsTrue(b1.Locate(food.FirstId) == food);
        Assert.IsFalse(b1.Locate(sword.FirstId) == sword);
        Assert.That(b1.FullDescription, Is.EqualTo("In the bag1 you can see:\nfood (thien linh tinh qua)\nfirework (phao hoa)\nbag2 (bag2)\n"));
        Assert.That(b2.FullDescription, Is.EqualTo("In the bag2 you can see:\nsword (thanh kiem)\n"));
    }
}
