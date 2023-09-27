using System;
namespace SemesterTest
{
	public abstract class Thing
	{
		private string _name;

		public Thing(string name)
		{
			_name = name;
		}

		public abstract int Size();
		public abstract void Print();
		public string Name {get => _name;}
	}
}

