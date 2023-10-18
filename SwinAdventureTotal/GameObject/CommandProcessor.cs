using System;
namespace SwinAdventure
{
	public class CommandProcessor : Command
	{
		private Command[] _commands = new Command[2];
		public CommandProcessor() : base(new string[] {"commandProcessor"})
		{
			_commands[0] = new LookCommand();
			_commands[1] = new MoveCommand();
		}

        public override string Execute(Player player, string[] text)
        {
			foreach (Command cmd in _commands)
				if (cmd.AreYou(text[0].ToLower()))
					return cmd.Execute(player, text);
			return "Wrong command input!, press 'help' for more about command";

        }
    }
}

