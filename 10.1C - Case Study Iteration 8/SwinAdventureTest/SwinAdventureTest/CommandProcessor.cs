namespace SwinAdventureTest;

public class CommandProcessorTest
{
    private CommandProcessor _cmdProcessor;
    private Player _testPlayer;
    private Bag _testBag;
    private Item _testItem;
    private Item _testBagItem;
    private Location _testLocationA;
    private Location _testLocationB;
    private Path _testPath;

    [SetUp]
    public void Setup()
    {
        _cmdProcessor = new CommandProcessor();
        _testPlayer = new Player("Kourt Zouma", "The boy who hits the cat");
        _testBag = new Bag(new string[] {"bag"}, "a bag", "Kourt Zouma's bag");
        _testItem = new Item(new string[] { "sword" }, "sword", "a sword");
        _testBagItem = new Item(new string[] { "money" }, "50 dollars", "50 australian dollars");
        _testLocationA = new Location("London Stadium", "Home stadium of West Ham");
        _testLocationB = new Location("Old Trafford", "Home stadium of Manchester United");
        _testPath = new Path(new string[] { "north" }, "Expressway", "Expressway to go to Old Trafford from London Stadium");
        _testPlayer.CurrentLocation = _testLocationA;
    }

    [Test]
    public void TestLookAtBag()
    {
        _testPlayer.Inventory.Put(_testBag);
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "look", "at", "bag" }), Is.EqualTo("In the a bag you can see:\n"));
    }
    [Test]
    public void TestLookAtItemInBag()
    {
        _testBag.Inventory.Put(_testBagItem);
        _testPlayer.Inventory.Put(_testBag);
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "look", "at", "money", "in", "bag"}), Is.EqualTo("50 australian dollars"));
    }

    [Test]
    public void TestLookItem()
    {
        _testPlayer.Inventory.Put(_testItem);
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "look", "at", "sword", "in", "inventory" }), Is.EqualTo("a sword"));
    }

    [Test]
    public void TestMovePlayerToEndLocation()
    {
        _testPath.EndLocation = _testLocationB;
        _testLocationA.AddPathTo(_testPath);
        _testPlayer.Move(_testPath);
        Assert.That(_testPlayer.CurrentLocation, Is.EqualTo(_testLocationB));
    }

    [Test]
    public void TestInvalidCommand()
    {
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] {"abcdef"}), Is.EqualTo("Wrong command input!, press 'help' for more about command"));
    }

    [Test]
    public void TestInvalidLookCommand()
    {
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "look" }), Is.EqualTo("Error at look command!\nMust be the 'at' keyword"));
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "look", "me" }), Is.EqualTo("Error at look command!\nI don't know how to look like that!"));
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "look", "at", "gun", "on", "me" }), Is.EqualTo("Error at look command!\nMust be the 'in' keyword"));
    }

    [Test]
    public void TestNotEnoughLookCommand()
    {
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "look", "at"}), Is.EqualTo("Error at look command!\nI don't know how to look like that!"));
    }

    [Test]
    public void TestInvalidMoveCommand()
    {
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "move", "to", "me", "via", "loop"}), Is.EqualTo("Invalid move command!"));
        Assert.That(_cmdProcessor.Execute(_testPlayer, new string[] { "move" }), Is.EqualTo("Select location that you wanted to move!\n"));
    }
}
