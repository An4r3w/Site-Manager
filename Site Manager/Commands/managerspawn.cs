using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MEC;

namespace Site_Manager.Commands
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	internal class SpawnSCP343 : ICommand
	{

		public string Command { get; } = "spawnmanager";

		public string[] Aliases { get; } = new string[]
		{
			"manager",
			"managerspawn"
		};

        public string Description { get; set; } = "Spawns the facility Manager";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player;
            if (!sender.CheckPermission("manager.spawn"))
            {
                response = "You don't have enough permissions.";
                return false;
            }
            else if (arguments.Count != 1 || !int.TryParse(arguments.At(0), out int id))
            {
                response = "Incorrect arguments. Try: spawnmanager";
                return false;
            }
            else if ((player = Player.Get(id)) == null)
            {
                response = $"Player with the id {id} can't be found.";
                return false;
            }
            else if (EventHandlers.manager.Count != 0)
            {
                response = "There is already a Manager in this facility!";
                return false;
            }
            else
            Timing.CallDelayed(1f, delegate ()
            {
                EventHandlers.spawnmanager(player);
             });
            response = $"Done, {player.Nickname} is now the Manager!!";
            return true;
        }
    }
}
