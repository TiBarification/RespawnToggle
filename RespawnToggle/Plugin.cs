
namespace RespawnToggle
{
	using System;
	using Exiled.API.Features;
	using ServerEvent = Exiled.Events.Handlers.Server;

	public class Plugin : Plugin<Config>
	{
		/// <summary>
		/// Gets a static instance of the <see cref="Plugin"/> class.
		/// </summary>
		public static Plugin Instance { get; private set; }

		public override string Name => "RespawnToggle";

		public override Version Version => new Version(1, 0, 0);

		public override string Author => "TiBarification";

		public override Version RequiredExiledVersion => new Version(8, 0, 1);

		public EventHandlers eventHandlers;

		public bool NTFRespawnEnabled { get; set; } = true;

		public bool CIRespawnEnabled { get; set; } = true;

		public override void OnEnabled()
		{
			Instance = this;
			if (!Config.IsEnabled) return;

			RegisterEvents();
		}

		public override void OnDisabled()
		{
			UnregisterEvents();
			base.OnDisabled();
		}

		private void UnregisterEvents()
		{
			ServerEvent.RespawningTeam -= eventHandlers.RespawningTeam;
			ServerEvent.RoundEnded -= eventHandlers.RoundEnded;
		}

		private void RegisterEvents()
		{
			eventHandlers = new EventHandlers();

			ServerEvent.RespawningTeam += eventHandlers.RespawningTeam;
			ServerEvent.RoundEnded += eventHandlers.RoundEnded;
		}
	}
}
