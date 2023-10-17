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
        Assert.That(sword, Is.EqualTo(b.Locate("Cuong Dao Guinsoo")));
        Assert.That(fireWork, Is.EqualTo(b1.Locate("Jinx")));
        Assert.IsTrue(b.Inventory.HasItem("Sword"));
        Assert.IsTrue(b1.Inventory.HasItem("Phao Hoa"));
    }

    [Test]
    public void TestBagLocateSelf()
    {
        Assert.That(b, Is.EqualTo(b.Locate("bag")));
        Assert.That(b1, Is.EqualTo(b1.Locate("bag1")));
    }

    [Test]
    public void TestBagLocatesNothing()
    {
        Assert.IsNull(b.Locate("Jinx"));
        Assert.IsNull(b1.Locate("Cuong Dao Guinsoo"));
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

        Assert.That(b2, Is.EqualTo(b1.Locate("bag2")));
        Assert.That(food, Is.EqualTo(b1.Locate("god's food")));
        Assert.That(sword, Is.EqualTo(b.Locate("Cuong Dao Guinsoo")));
        Assert.That(b1.FullDescription, Is.EqualTo("In the bag1 you can see:\nfood (thien linh tinh qua)\nfirework (phao hoa)\nbag2 (bag2)\n"));
        Assert.That(b2.FullDescription, Is.EqualTo("In the bag2 you can see:\nsword (thanh kiem)\n"));
    }
}
