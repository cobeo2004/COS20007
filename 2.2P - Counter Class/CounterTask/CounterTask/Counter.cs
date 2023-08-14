using System;
namespace CounterTask
{
	public class Counter
	{
		private int _count;
		private string _name;

		public Counter(string name)
		{
			_name = name;
			_count = 0;
		}

		public Counter(string name, int count)
		{
			_name = name;
			_count = count;
		}

		public void Increment()
		{
			_count += 1;
		}

		public void Reset()
		{
			_count = 0;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public int Ticks
		{
			get
			{
				return _count;
			}
		}
	}
}

