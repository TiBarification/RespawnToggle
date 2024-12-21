
namespace RespawnToggle.Commands.RespawnEvents
{
	using System;
	using CommandSystem;
	using Exiled.Permissions.Extensions;

	internal class StatusCommand : ICommand
	{
		public string Command { get; } = "status";

		public string[] Aliases { get; } = { "s" };

		public string Description { get; } = "Get current status of waves";

		public bool SanitizeResponse { get; } = false;

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (!((CommandSender)sender).CheckPermission("respawntoggle.read"))
			{
				response = "You do not have permission to use this command";
				return false;
			}

			response = $"Respawn wave status: {!RespawnControl.NoRespawn}";
			return true;
		}
	}
}
