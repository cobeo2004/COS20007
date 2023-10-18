using System;
namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string direction;

            switch (text.Length)
            {
                case 1:
                    if (AreYou(text[0]) == false)
                        return "Error, command should be: move, go, head, leave\n";
                    return "Select location that you wanted to move!\n";
                case 2:
                    direction = text[1].ToLower();
                    break;
                case 3:
                    direction = text[2].ToLower();
                    break;
                default:
                    return "Invalid move command!";
            }

            GameObject path = p.CurrentLocation.Locate(direction);

            if (path == null)
                return "Error\n" + "Got null when finding direction!\n";
            else
            {
                if (path.GetType() == typeof(Path))
                {
                    p.Move((Path) path);
                    //return "You have moved to " + path.FirstId + " via " + path.Name + " to the " + p.CurrentLocation.Name + ".\r\n" + "Description: " + p.CurrentLocation.FullDescription;
                    return $"\nCurrent location: {path.Name}\nDescription: {p.CurrentLocation.FullDescription}";
                }
                else
                    return "Error: " + "Could not find the given path: " + path.Name;
            }
        }
    }
}
