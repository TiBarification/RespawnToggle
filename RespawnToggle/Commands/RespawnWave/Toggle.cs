
namespace RespawnToggle.Commands.RespawnEvents
{
	using System;
	using CommandSystem;
	using Exiled.Permissions.Extensions;

	internal class ToggleCommand : ICommand
	{
		public string Command { get; } = "toggle";

		public string[] Aliases { get; } = { "t" };

		public string Description { get; } = "Toggle all or selected team wave";
		public bool SanitizeResponse { get; } = false;

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (!((CommandSender)sender).CheckPermission(PlayerPermissions.RespawnEvents))
			{
				response = "You do not have RespawnEvents permission to use this command";
				return false;
			}

			RespawnControl.NoRespawn = !RespawnControl.NoRespawn;
			response = $"Respawn wave status: {!RespawnControl.NoRespawn}";

			return true;
		}
	}
}
