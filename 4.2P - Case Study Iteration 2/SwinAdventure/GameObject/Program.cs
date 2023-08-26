namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Player player = new Player("simon", "ngu");

            player.Inventory.Put(new Item(new string[] { "sword" }, "sword", "a sword"));

            Console.WriteLine(player.FullDescription);
        }
    }
}