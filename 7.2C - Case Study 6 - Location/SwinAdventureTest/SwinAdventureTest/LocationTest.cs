namespace SwinAdventureTest
{
    public class LocationTests
    {
        private Player _testPlayer;
        private Location _testLocation;
        private Item _myKi;

        [SetUp]
        public void Setup()
        {
            _testPlayer = new Player("Simon", "This is Simon Handsome");
            _testLocation = new Location("Engineering", "This is Engineering, EN Building");
            _testPlayer.CurrentLocation = _testLocation;
            _myKi = new Item(new string[] { "myKi" }, "a myKi", "MyKi card use for public transportation");
            _testLocation.inventory.Put(_myKi);
        }

        [Test]
        public void TestPlayerHasDefaultSelfLocation()
        {
            Assert.That(_testPlayer.CurrentLocation, Is.EqualTo(_testLocation));
        }

        [Test]
        public void TestPlayerInCurrentLocation()
        {
            Assert.IsTrue(_testLocation.AreYou("location"));
        }

        [Test]
        public void TestPlayerNotInCurrentLocation()
        {
            Assert.IsFalse(_testLocation.AreYou("BA Building"));
        }   

        [Test]
        public void TestLocationCanLocateItem()
        {
            Assert.That(_testLocation.Locate("myKi"), Is.EqualTo(_myKi));
        }
    }
}