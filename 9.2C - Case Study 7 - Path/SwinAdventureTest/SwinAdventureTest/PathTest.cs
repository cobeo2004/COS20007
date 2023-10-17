namespace SwinAdventureTest
{
    public class PathTests
    {
        private Location _testLocationA;
        private Location _testLocationB;
        private Path _testPath;

        [SetUp]
        public void Setup()
        {
            _testLocationA = new Location("BA Building", "The Business Art building of Swinburne University of Technology");
            _testLocationB = new Location("EN Building", "The Engineering building of Swinburne University of Technology");
            _testPath = new Path(new string[] { "north" }, "Hallway", "A hallway", _testLocationA, _testLocationB);
        }

        [Test]
        public void TestPathLocateDestination()
        {
            Assert.That(_testPath.Destination, Is.EqualTo(_testLocationB));
        }

        [Test]
        public void TestPathFullDescription()
        {
            Assert.That(_testPath.FullDescription, Is.EqualTo("A hallway"));
        }

        [Test]
        public void TestPathLocating()
        {
            Assert.That(_testLocationA.Locate("north"), Is.EqualTo(_testPath));
        }

    }
}