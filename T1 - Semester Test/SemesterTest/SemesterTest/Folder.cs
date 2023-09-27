using System;
namespace SemesterTest
{
	public class Folder : Thing
	{
		private List<Thing> _contents;

		public Folder(string name) : base(name)
		{
			_contents = new List<Thing>();
		}

		public void Add(Thing toAdd)
		{
			_contents.Add(toAdd);
		}

		public override int Size()
		{
			int totalSize = 0;
			foreach(File file in _contents)
			{
				totalSize += file.Size();
			}

			return totalSize;
		}

		public override void Print()
		{
			if(Size() != 0)
				Console.WriteLine($"The folder '{Name}' contains {Size()} bytes total:");
			else
                Console.WriteLine($"The folder '{Name}' is empty!");

            foreach (File file in _contents)
			{
				file.Print();
			}
		}
	}
}

