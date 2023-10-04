using System;
namespace SwinAdventure
{
	public class LookCommand : Command
	{
		public LookCommand() : base(new string[] { "look" })
		{
		}

        public override string Execute(Player player, string[] text)
        {
            IHaveInventory containerInventory;
            string itemID;
            string err = "Error at look command!";

            if (text[0].ToLower() != "look")
            {
                return err;
            }

            switch(text.Length)
            {
                case 1:
                    containerInventory = player;
                    itemID = "me";
                    break;
                case 3:
                    if (text[1].ToLower() != "at")
                    {
                        return "Which one do you want to look at ?";
                    }
                    containerInventory = player;
                    itemID = text[2];
                    break;
                case 5:
                    if (text[3].ToLower() != "in")
                        return "Which one do you want to look at ?";

                    containerInventory = FetchContainer(player, text[4]);
                    if(containerInventory == null)
                    {
                        return "Could not find Item: " + text[4];
                    }
                    itemID = text[2];
                    break;
                default:
                    return err;
            }

            return LookAtIn(itemID, containerInventory);
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }

        public string LookAtIn(string thingId, IHaveInventory containter)
        {
            if (containter.Locate(thingId) == null)
                return $"Could not find items: {thingId}";
            return containter.Locate(thingId).FullDescription;
        }

    }
}

