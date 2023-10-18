namespace SwinAdventureTest
{
	public class MoveCommandTest
	{
		private MoveCommand _moveCmd;
		private Player _simon;
		private Location _flinders;
		private Location _poolHall;
		private Path _swanstonSt;

		[SetUp]
		public void Setup()
		{
			_moveCmd = new MoveCommand();
			_simon = new Player("Simon", "A handsome boy");
			_flinders = new Location("Flinders Street", "Flinders Street Station");
			_poolHall = new Location("pool hall", "ICue pool hall near Melbourne Central");
			_swanstonSt = new Path(new string[] { "swanston" }, "Swanston Street", "Biggest street in CBD");
			_swanstonSt.EndLocation = _poolHall;
			_flinders.AddPathTo(_swanstonSt);
		}

		[Test]
		public void TestInvalidCommand()
		{
            _simon.CurrentLocation = _flinders;
            Assert.That(_moveCmd.Execute(_simon, new string[] { "move" }), Is.EqualTo("Select location that you wanted to move!\n"));
			Assert.That(_moveCmd.Execute(_simon, new string[] {"fly"}), Is.EqualTo("Error, command should be: move, go, head, leave\n"));
			Assert.That(_simon.CurrentLocation, Is.EqualTo(_flinders));
		}

		[Test]
		public void TestMovePlayerToEndLocation()
		{
			_simon.CurrentLocation = _flinders;
			_moveCmd.Execute(_simon, new string[] { "move", "via", "swanston" });
			Assert.That(_simon.CurrentLocation, Is.EqualTo(_poolHall));
		}

		[Test]
		public void TestInvalidPath()
		{
			_simon.CurrentLocation = _poolHall;
            _moveCmd.Execute(_simon, new string[] { "move", "via", "swanston" });
			Assert.That(_moveCmd.Execute(_simon, new string[] { "move", "via", "swanston" }), Is.EqualTo("Error\nGot null when finding direction!\n"));

        }
	}
}

