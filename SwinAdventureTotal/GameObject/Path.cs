using System;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _dest;
        public Path(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        public Location EndLocation
        {
            get
            {
                return _dest;
            }
            set
            {
                _dest = value;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"Passing through {Name.ToLower()}({base.FullDescription})...\nArrived at {_dest.Name}!";
            }
        }

        public override string ShortDescription
        {
            get
            {
                return Name;
            }
        }
    }
}