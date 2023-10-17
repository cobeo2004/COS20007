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
                return err + "\n" + "Must be the 'look' keyword";
            }
            
            switch(text.Length)
            {
                case 1:
                    containerInventory = player;
                    itemID = "me";
                    break;
                case 3:
                    if (text[1].ToLower() != "at")
                        return err + "\n" + "Must be the 'at' keyword";
                    else if (text[2].ToLower() == "")
                        return "Which one do you want to look at ?";
                    else
                    {
                        containerInventory = player;
                        itemID = text[2];
                    }
                    break;
                case 5:
                    if (text[3].ToLower() != "in")
                        return err + "\n" + "Must be the 'in' keyword";
                    else if (text[4].ToLower() == "")
                        return $"Which one do you want to look at?";
                    else
                    {
                        containerInventory = FetchContainer(player, text[4]);
                        if (containerInventory == null)
                        {
                            return "Could not find Item: " + text[4];
                        }
                        itemID = text[2];
                    }
                    break;
                default:
                    return err;
            }

            return LookAtIn(itemID, containerInventory);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }

        private string LookAtIn(string thingId, IHaveInventory containter)
        {
            if (containter.Locate(thingId) == null)
                return $"Could not find items: {thingId}";
            return containter.Locate(thingId).FullDescription;
        }

    }
}

