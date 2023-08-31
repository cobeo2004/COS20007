namespace SwinAdventure
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            Bag b = new Bag(new string[] { "bag" }, "bagger", "a bag");
            Item[] multipleItems = {
                new Item(new string[] { "sword" }, "sword", "a sword"),
                new Item(new string[] { "firework" }, "firework", "a firework")
            };
            foreach (Item i in multipleItems)
                b.Inventory.Put(i);

            Console.WriteLine(b.FullDescription);
        }
    }
}