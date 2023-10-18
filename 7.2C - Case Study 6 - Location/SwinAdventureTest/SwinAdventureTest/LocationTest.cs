namespace SwinAdventureTest
{
    public class LocationTests
    {
        private Player _testPlayer;
        private Location _testLocation;
        private Location _testLocation2;
        private Path _testPath;
        private Item _myKi;
        private Item _authorisedOfficer;

        [SetUp]
        public void Setup()
        {
            _testPlayer = new Player("Simon", "This is Simon Handsome");
            _testLocation = new Location("Flinder Street", "Flinders Street station, busiest station in VIC");
            _testLocation2 = new Location("Richmond", "Richmond station, junction for BLY and SYR group");
            _testPath = new Path(new string[] { "loop" }, "Burnley Clockwise Loop", "Burnley clockwise loop that leads to Richmond via Southern Cross");
            _testPath.EndLocation = _testLocation2;
            _testPlayer.CurrentLocation = _testLocation;
            _testLocation.AddPathTo(_testPath);
            _myKi = new Item(new string[] { "myKi" }, "a myKi", "MyKi card use for public transportation");
            _authorisedOfficer = new Item(new string[] { "officer" }, "Authorised officer", "Authorised officer, who is going to catch you if you using concession card");
            _testLocation.inventory.Put(_myKi);
            _testLocation2.inventory.Put(_authorisedOfficer);
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
            Assert.IsFalse(_testLocation.AreYou("Richmond"));
        }   

        [Test]
        public void TestLocationCanLocateItem()
        {
            Assert.That(_testLocation.Locate("myKi"), Is.EqualTo(_myKi));
            Assert.That(_testLocation2.Locate("officer"), Is.EqualTo(_authorisedOfficer));
        }

        [Test]
        public void TestPlayerMoveToNewLocation()
        {
            _testPlayer.Move(_testPath);
            Assert.That(_testLocation, Is.Not.EqualTo(_testPlayer.CurrentLocation));
            Assert.That(_testPlayer.CurrentLocation, Is.EqualTo(_testLocation2));
        }

        [Test]
        public void TestPlayerNotMoveIfHasNoPaths()
        {
            _testPlayer.CurrentLocation = _testLocation2;
            _testPlayer.Move(_testPath);
            Assert.That(_testPlayer.CurrentLocation, Is.EqualTo(_testLocation2));
        }
    }
}