namespace RespawnToggle
{
	using Exiled.API.Features;
	using Exiled.Events.EventArgs.Map;
	using Exiled.Events.EventArgs.Server;
	using Respawning;
	public class EventHandlers
	{
		public void RespawningTeam(RespawningTeamEventArgs ev)
		{
			switch (ev.NextKnownTeam)
			{
				case SpawnableTeamType.NineTailedFox:
					{
						ev.IsAllowed = Plugin.Instance.NTFRespawnEnabled;
						Log.Debug($"NTF spawn: {ev.IsAllowed}");
						return;
					}
				case SpawnableTeamType.ChaosInsurgency:
					{
						ev.IsAllowed = Plugin.Instance.CIRespawnEnabled;
						Log.Debug($"CI spawn: {ev.IsAllowed}");
						return;
					}
			}
		}

		public void RoundEnded(RoundEndedEventArgs ev)
		{
			if (!Plugin.Instance.Config.KeepStateOnNextRound)
			{
				Plugin.Instance.NTFRespawnEnabled = true;
				Plugin.Instance.CIRespawnEnabled = true;
			}
		}

		public void SpawningTeamVehicle(SpawningTeamVehicleEventArgs ev)
		{
			switch (ev.Team)
			{
				case SpawnableTeamType.NineTailedFox:
					{
						ev.IsAllowed = Plugin.Instance.NTFRespawnEnabled;
						Log.Debug($"NTF spawn: {ev.IsAllowed}");
						return;
					}
				case SpawnableTeamType.ChaosInsurgency:
					{
						ev.IsAllowed = Plugin.Instance.CIRespawnEnabled;
						Log.Debug($"CI spawn: {ev.IsAllowed}");
						return;
					}
			}
		}
	}
}
