
namespace RespawnToggle.Commands.RespawnEvents
{
	using System;
	using CommandSystem;
	using Exiled.API.Features.Pools;
	using Exiled.Permissions.Extensions;

	internal class ToggleCommand : ICommand
	{
		public string Command { get; } = "toggle";

		public string[] Aliases { get; } = { "t" };

		public string Description { get; } = "Toggle all or selected team wave";
		public bool SanitizeResponse { get; } = false;

		private RespawnEventsCommand parent = null;

		public ToggleCommand(RespawnEventsCommand parent)
		{
			this.parent = parent;
		}

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (!((CommandSender)sender).CheckPermission("respawntoggle.write"))
			{
				response = "You do not have permission to use this command";
				return false;
			}

			if (arguments.Count == 0)
			{
				response = $"Usage: rw {Command} all/ntf/ci";
				return false;
			}

			var team = arguments.At(0);

			switch (team)
			{
				case "all":
					{
						Plugin.Instance.NTFRespawnEnabled = !Plugin.Instance.NTFRespawnEnabled;
						Plugin.Instance.CIRespawnEnabled = !Plugin.Instance.CIRespawnEnabled;

						response = parent.FormatRespawnWaveStatusResponse();
						break;
					}
				case "ntf":
					{
						Plugin.Instance.NTFRespawnEnabled = !Plugin.Instance.NTFRespawnEnabled;
						
						response = parent.FormatRespawnWaveStatusResponse(Respawning.SpawnableTeamType.NineTailedFox);
						break;
					}
				case "ci":
					{
						Plugin.Instance.CIRespawnEnabled = !Plugin.Instance.CIRespawnEnabled;

						response = parent.FormatRespawnWaveStatusResponse(Respawning.SpawnableTeamType.ChaosInsurgency);
						break;
					}
				default:
					{
						response = $"Usage: rw {Command} all/ntf/ci";
						break;
					}
			}

			return true;
		}
	}
}
