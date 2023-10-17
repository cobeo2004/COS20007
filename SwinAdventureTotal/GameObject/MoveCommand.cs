using System;
namespace SwinAdventure
{
	public class MoveCommand : Command
	{
		public MoveCommand() : base(new string[] {"move"})
		{
		}

        public override string Execute(Player p, string[] text)
        {
            string err = "Error occured in move input:\n";
            string direction;

            switch(text.Length)
            {
                case 1:
                    return err + "Select location that you wanted to move!\n";
                case 2:
                    direction = text[1].ToLower();
                    break;
                case 3:
                    direction = text[2].ToLower();
                    break;
                default:
                    return err;
            }

            GameObject path = p.CurrentLocation.Locate(direction);

            if (path == null)
                return err + "Got null when finding direction!\n";
            else
            {
                if (path.GetType() == typeof(Path))
                {
                    p.Move(path as Path);
                    return "You have moved to " + path.FirstId + "via " + path.Name + "to the " + p.CurrentLocation.Name + ".\r\n" + "Description: " + p.CurrentLocation.FullDescription;
                }
                else
                    return err + "Could not find the given path: " + path.Name;
            }
        }
    }
}

