using System;

namespace SwinAdventure
{
    public class Program
    {

        public static void Main()
        {
            string helpCommand = "List of commands:\n-look at inventory or look at me: Display what you are carrying in inventory\n-look at <item in inventory>: Get the description of that item\n-look at <bag>: Display what you are carrying in bag\n-look at <item> in <bag>: Get full description of item that is contained in the bag\n-look at location: Display current location, things on that location and path to next building\n-move <path | direction>: move to next location via path\n-exit or quit: Halt the program\n-help: Get command list\n";
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
            Item computer = new Item(new string[] { "computer" }, "a computer", "This is a BA computer");
            Item lift = new Item(new string[] { "lift" }, "a lift", "This is a EN lift");
            Item mouse = new Item(new string[] { "mouse" }, "a mouse", "This is a AGSE computer's mouse");
            Item television = new Item(new string[] { "television" }, "a television", "This is a ATC television");
            Bag playerBag = new Bag(new string[] { "bag" }, "a bag", "This is the player's bag");

            Location BABuilding = new Location("BA Building", "This is BA Building");
            Location ENBuilding = new Location("EN Building", "This is EN Building");
            Location ATCBuilding = new Location("ATC Building", "This is ATC Building");
            Location AGSEBuilding = new Location("AGSE Building", "This is AGSE Building");
            Path northPath = new Path(new string[] { "north" }, "AGSE Lane", "Lane that leads to AGSE from BA");
            Path westPath = new Path(new string[] { "west" }, "ATC Lane", "Hallway that leads to ATC from AGSE");
            Path eastPath = new Path(new string[] { "east" }, "EN Lane", "Hallway that leads to EN from ATC");

            northPath.EndLocation = AGSEBuilding;
            westPath.EndLocation = ATCBuilding;
            eastPath.EndLocation = ENBuilding;
            BABuilding.AddPathTo(northPath);
            AGSEBuilding.AddPathTo(westPath);
            ATCBuilding.AddPathTo(eastPath);

            player.CurrentLocation = BABuilding;
            BABuilding.inventory.Put(computer);
            ENBuilding.inventory.Put(lift);
            ATCBuilding.inventory.Put(mouse);
            AGSEBuilding.inventory.Put(television);

            playerBag.Inventory.Put(gun);
            player.Inventory.Put(mykiCard);
            player.Inventory.Put(phone);
            player.Inventory.Put(playerBag);

            string playerInput;

            while (true)
            {
                Console.Write("Input: ");
                playerInput = Console.ReadLine();

                if (playerInput.ToLower() == "exit" || playerInput.ToLower() == "quit")
                    break;

                else if (playerInput.ToLower() == "help")
                    Console.Write(helpCommand);

                else
                {
                    CommandProcessor cmdProcessor = new CommandProcessor();
                    Console.WriteLine(cmdProcessor.Execute(player, playerInput.Split()));
                }
            }
        }
    }
}
