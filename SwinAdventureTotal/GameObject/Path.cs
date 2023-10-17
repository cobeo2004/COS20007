using System;
namespace SwinAdventure
{
	public class Path : GameObject
	{
		private bool _isBlock;
		private Location _source, _destination;

		public Path(string[] identifier, string name, string description, Location source, Location dest) : base(identifier, name, description)
		{
			_source = source;
			_destination = dest;
			_isBlock = false;
		}

		public Location Destination
		{
			get
			{
				return _destination;
			}
		}

		public Location Source
		{
			get
			{
				return _source;
			}
		}

        public override string ShortDescription
		{
			get
			{
				return $"Location: {Name}";
			}
		}

		public bool IsBlocked
		{
			get
			{
				return _isBlock;
			}

			set
			{
				_isBlock = value;
			}
		}
    }
}

