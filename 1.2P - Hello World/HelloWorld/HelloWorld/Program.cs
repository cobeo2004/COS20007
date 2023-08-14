using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Message myMessage = new Message("Hello World - from Message Object");
            Message[] messages =
            {
                new Message("Welcome back!"),
                new Message("What a lovely name"),
                new Message("Great name"),
                new Message("Oh hi!"),
                new Message("That is a silly name")
            };
            myMessage.Print();

            while (true)
            {
                Console.WriteLine("Enter name: ");
                string input_name = Console.ReadLine()!;
                switch (input_name.ToLower())
                {
                    case "mark":
                        messages[0].Print();
                        break;
                    case "fred":
                        messages[1].Print();
                        break;
                    case "wilma":
                        messages[2].Print();
                        break;
                    case "alice":
                        messages[3].Print();
                        break;
                    default:
                        messages[4].Print();
                        break;
                }
            }
        }
    }
}
