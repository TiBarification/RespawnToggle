
namespace RespawnToggle.Commands.RespawnEvents
{
	using System;
	using CommandSystem;
	using Exiled.API.Features.Pools;
	using Exiled.Permissions.Extensions;

	internal class ForceCommand : ICommand
	{
		public string Command { get; } = "force";

		public string[] Aliases { get; } = { "f" };

		public string Description { get; } = "Force specific wave for respawn";
		public bool SanitizeResponse { get; } = false;

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (!((CommandSender)sender).CheckPermission("respawntoggle.write"))
			{
				response = "You do not have permission to use this command";
				return false;
			}

			if (arguments.Count != 1)
			{
				response = "Usage: respawnwave force <wave number>";
				return false;
			}

			RespawnControl.NoRespawn = false;
			RespawnControl.ForceRespawn(int.Parse(arguments.At(0)), out string error);
			response = error ?? "Forced respawn wave";

			return true;
		}
	}
}
