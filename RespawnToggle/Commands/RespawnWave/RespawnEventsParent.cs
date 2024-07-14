
namespace RespawnToggle.Commands.RespawnEvents
{
	using System;
	using CommandSystem;
	using Exiled.API.Features.Pools;
	using Respawning;

	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class RespawnEventsCommand : ParentCommand
	{
		public override string Command { get; } = "respawnwave";
		public override string[] Aliases { get; } = { "rw", "rwave" };

		public override string Description { get; } = "Control respawn waves for NTF/CI";

		public bool SanitizeResponse { get; } = false;

		public RespawnEventsCommand()
		{
			LoadGeneratedCommands();
		}

		public string FormatRespawnWaveStatusResponse(SpawnableTeamType team = SpawnableTeamType.None)
		{
			var Instance = Plugin.Instance;
			var NTFEnabled = Instance.NTFRespawnEnabled;
			var CIEnabled = Instance.CIRespawnEnabled;

			var sbp = StringBuilderPool.Pool.Get();
			sbp.AppendLine("Current status of Respawn waves:");

			if (team == SpawnableTeamType.None || team == SpawnableTeamType.NineTailedFox)
			{
				sbp.Append("NTF:");
				if (NTFEnabled)
				{
					sbp.AppendLine("Enabled");
				}
				else
				{
					sbp.AppendLine("Disabled");
				}
			}

			if (team == SpawnableTeamType.None || team == SpawnableTeamType.ChaosInsurgency)
			{
				sbp.Append("CI:");
				if (CIEnabled)
				{
					sbp.AppendLine("Enabled");
				}
				else
				{
					sbp.AppendLine("Disabled");
				}
			}

			return sbp.ToString();
		}

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new StatusCommand(this));
			RegisterCommand(new ToggleCommand(this));
		}

		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = $"Invalid SubCommand! available SubCommands: status (s) / toggle (t).";
			return false;
		}
	}
}
