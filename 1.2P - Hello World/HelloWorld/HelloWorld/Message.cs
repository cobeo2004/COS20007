using System;
namespace HelloWorld
{
	public class Message
	{
		private string _text;
		public Message(string txt)
		{
			_text = txt;
		}
		public void Print()
		{
			Console.WriteLine(this._text);
		}
	}
}

