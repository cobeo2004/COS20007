using System;
using System.Threading;
namespace ClockClassMain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Clock c = new Clock();
            while(true)
            {
                Console.WriteLine(c.CurrentTime + "\n");
                c.Tick();
                Thread.Sleep(1000);
                    
            }
        }
    }
}