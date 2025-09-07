
using System;
using CommandSystem;

namespace RespawnToggle.Commands.RespawnEvents
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class RespawnEventsCommand : ParentCommand, ICommand
	{
		public override string Command { get; } = "respawnwave";
		public override string[] Aliases { get; } = { "rw", "rwave" };

		public override string Description { get; } = "Control respawn waves for NTF/CI";

		public bool SanitizeResponse => false;

		public RespawnEventsCommand()
		{
			LoadGeneratedCommands();
		}

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new StatusCommand());
			RegisterCommand(new ToggleCommand());
		}

		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = "\nPlease enter a valid subcommand:\n";
			foreach (var command in AllCommands)
				if (sender.CheckPermission(PlayerPermissions.RespawnEvents))
				{
					var aliases = command.Aliases.Length > 0 ? $" ({string.Join(", ", command.Aliases)})" : "";
					response += $"\n- {command.Command}{aliases}";

				}
			return false;
		}
	}
}
