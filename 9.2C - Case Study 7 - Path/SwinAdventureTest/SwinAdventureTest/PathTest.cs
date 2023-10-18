
namespace SwinAdventureTest
{
    public class PathTests
    {
        private Player _simon;
        private Location _testLocationA;
        private Location _testLocationB;
        private Path _testPath;

        [SetUp]
        public void Setup()
        {
            _simon = new Player("Simon", "Madness");
            _testLocationA = new Location("EN Building", "The Business Art building of Swinburne University of Technology");
            _testLocationB = new Location("ATC Building", "The Advanced Technology Centre of Swinburne University of Technology");
            _testPath = new Path(new string[] { "north" }, "A skyhall", "A skyhall that connects BA and ATC");
            _testPath.StartLocation = _testLocationA;
            _testPath.EndLocation = _testLocationB;
        }

        [Test]
        public void TestMovesPlayerToEndLocation()
        {
            _testLocationB.AddPathToLocation(_testPath);
            _simon.Move(_testPath);
            Assert.That(_simon.CurrentLocation, Is.EqualTo(_testLocationB));
        }

        [Test]
        public void TestPathShortDescription()
        {
            Assert.That(_testPath.ShortDescription, Is.EqualTo("A skyhall"));
        }

        [Test]
        public void TestPathFullDescription()
        {
            Assert.That(_testPath.FullDescription, Is.EqualTo("Passing through a skyhall(A skyhall that connects BA and ATC)...\nYou have arrived at ATC Building!"));
        }

        [Test]
        public void TestLocationLocatesPath()
        {
            _testLocationA.AddPathToLocation(_testPath);
            Assert.That(_testLocationA.Locate("north"), Is.EqualTo(_testPath));
        }

        [Test]
        public void PathIsNotNull()
        {
            Assert.NotNull(_testPath.AreYou("north"));
        }

    }
}