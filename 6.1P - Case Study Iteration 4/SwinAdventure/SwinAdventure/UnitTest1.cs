namespace SwinAdventure;

public class Tests
{
    private Command _lookCommand;
    private Player _player;
    private Player _player1;
    private Bag _bag;
    private Item _gem;
    [SetUp]
    public void Setup()
    {
        _lookCommand = new LookCommand();
        _player = new Player("Simon", "Player Simon Dep Trai");
        _bag = new Bag(new string[] { "bag" }, "a bag", $"This is {_player.FirstId}'s bag");
        _player.Inventory.Put(_bag);
        _player1 = new Player("Ray Tran", "Simon's Daughter");
        _gem = new Item(new string[] { "gem" }, "a gem", "This is a lovely gem");
    }

    [Test]
    public void TestLookAtMe()
    {
       Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "inventory" }), Is.EqualTo($"You are {_player.Name}, Player Simon Dep Trai. You are carrying:\n{_player.Inventory.ItemList}"));
    }

    [Test]
    public void TestLookAtGem()
    {
        _player.Inventory.Put(_gem);
        Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo($"{_gem.FullDescription}"));
    }

    [Test]
    public void TestLookAtUnk()
    {
        Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo("Could not find items: gem"));
    }

    [Test]
    public void TestLookAtGemInMe()
    {
        _player.Inventory.Put(_gem);
        Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "me" }), Is.EqualTo(_gem.FullDescription));
    }

    [Test]
    public void TestLookAtGemInBag()
    {
        _bag.Inventory.Put(_gem);
        Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo(_gem.FullDescription));
    }

    [Test]
    public void TestLookAtGemInNoBag()
    {
        _bag.Inventory.Put(_gem);
        Assert.That(_lookCommand.Execute(_player1, new string[] { "look", "at", "gem", "in", _player.FirstId}), Is.EqualTo("Could not find items: gem"));
    }

    [Test]
    public void TestLookAtNoGemInBag()
    {
        _bag.Inventory.Put(_gem);
        Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "knife", "in", "bag" }), Is.EqualTo("Could not find items: knife"));

    }

    [Test]
    public void TestInvalidLook()
    {
        Assert.That(_lookCommand.Execute(_player, new string[] { "look", "gem", "me"}), Is.EqualTo("Which one do you want to look at ?"));
        Assert.That(_lookCommand.Execute(_player, new string[] { "discover", "gem" }), Is.EqualTo("Error at look command!"));
    }
}
