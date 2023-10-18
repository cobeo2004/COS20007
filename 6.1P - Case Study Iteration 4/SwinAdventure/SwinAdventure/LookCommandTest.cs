namespace SwinAdventureTest
{
    public class LookCommandTest
    {
        private Command _lookCommand;
        private Player _player;
        private Player _player1;
        private Bag _bag;
        private Item _gem;
        private Location _location;
        [SetUp]
        public void Setup()
        {
            _lookCommand = new LookCommand();
            _player = new Player("Simon", "Player Simon Dep Trai");
            _bag = new Bag(new string[] { "bag" }, "a bag", $"This is {_player.FirstId}'s bag");
            _player.Inventory.Put(_bag);
            _player1 = new Player("Ray Tran", "Simon's Daughter");
            _gem = new Item(new string[] { "gem" }, "a gem", "This is a lovely gem");
            _location = new Location("Test Location", "this is a test location");
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
        public void TestLookAtUnknown()
        {
            _player.Inventory.Take("gem");
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
            _player.Inventory.Take("bag");
            Assert.That(_lookCommand.Execute(_player1, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("Could not find Item: bag"));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _bag.Inventory.Take("gem");
            Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("Could not find items: gem"));

        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That(_lookCommand.Execute(_player, new string[] { "look", "gem", "me" }), Is.EqualTo("Error at look command!\nMust be the 'at' keyword"));
            Assert.That(_lookCommand.Execute(_player, new string[] { "discover", "gem" }), Is.EqualTo("Error at look command!\nMust be the 'look' keyword"));
        }

        [Test]
        public void TestLookAtLocation()
        {
            _location.inventory.Put(_gem);
            _player.CurrentLocation = _location;
            Assert.That(_lookCommand.Execute(_player, new string[] { "look", "at", "location" }), Is.EqualTo($"You are at location of Test Location\nDescription: this is a test location\nItems at location:\n{_gem.ShortDescription}\n\nPath description: Currently there are no available routes!\n"));
        }
    }

}