
namespace RespawnToggle.Commands.RespawnEvents
{
	using System;
	using CommandSystem;

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
			RegisterCommand(new ForceCommand());
		}

		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = $"Invalid SubCommand! available SubCommands: status (s) / toggle (t) / force (f).";
			return false;
		}
	}
}
