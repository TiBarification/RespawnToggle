using System;
using CommandSystem;

namespace RespawnToggle.Commands.RespawnEvents
{
	internal class StatusCommand : ICommand
	{
		public string Command { get; } = "status";

		public string[] Aliases { get; } = { "s" };

		public string Description { get; } = "Get current status of waves";

		public bool SanitizeResponse { get; } = false;

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (!((CommandSender)sender).CheckPermission(PlayerPermissions.RespawnEvents))
			{
				response = "You do not have RespawnEvents permission to use this command";
				return false;
			}

			response = $"Respawn wave status: {!RespawnControl.NoRespawn}";
			return true;
		}
	}
}
