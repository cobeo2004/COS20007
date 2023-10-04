using System;

namespace SwinAdventure
{
    public class Program
    {
        private static void ExecuteLookCommand(Player player, Command command, string playerInput)
        {
            Console.WriteLine(command.Execute(player, playerInput.Split()));
        }

        public static void Main()
        {
            string helpCommand = "List of commands:\n-look or look at me: Display what you are carrying in inventory\n-look at <item in inventory>: Get the description of that item\n-look at <bag>: Display what you are carrying in bag\n-look at <item> in <bag>: Get full description of item that is contained in the bag\n-exit or quit: Halt the program\n-help: Get command list\n";
            Console.WriteLine("Welcome To SwinAdventure, a game that is created by Swinburne.");
            Console.WriteLine("Now let's go and setting up our character!");
            Console.Write("Your player name: ");
            string playerName = Console.ReadLine();
            Console.Write("\nYour player description: ");
            string playerDescription = Console.ReadLine();
            Player player = new Player(playerName, playerDescription);

            Item gun = new Item(new string[] { "gun" }, "a gun", "This is ak47, a gun");
            Item phone = new Item(new string[] { "phone" }, "a phone", "This is Iphone 15 Pro Max, a phone");
            Item mykiCard = new Item(new string[] { "myki" }, "a myki card", "This is MyKi card, use for public transportations in Victoria");
            Bag playerBag = new Bag(new string[] { "bag" }, "a bag", "This is the player's bag");

            playerBag.Inventory.Put(gun);
            player.Inventory.Put(mykiCard);
            player.Inventory.Put(phone);
            player.Inventory.Put(playerBag);

            string playerInput;
            Command command = new LookCommand();

            while (true)
            {
                Console.Write("Input: ");
                playerInput = Console.ReadLine();

                if (playerInput.ToLower() == "exit" || playerInput.ToLower() == "quit")
                {
                    break;
                }
                else if (playerInput.ToLower() == "help")
                {
                    Console.Write(helpCommand);
                }
                else
                {
                    ExecuteLookCommand(player, command, playerInput);
                }
            }
        }
    }
}

