
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

		public override Version Version => new Version(2, 4, 0);

		public override string Author => "TiBarification";

		public override Version RequiredExiledVersion => new Version(9, 0, 0);

		EventHandlers eventHandlers;

		public override void OnEnabled()
		{
			Instance = this;
			eventHandlers = new EventHandlers();
			if (!Config.IsEnabled) return;
			ServerEvent.RoundEnded += eventHandlers.RoundEnded;
			ServerEvent.RestartingRound += eventHandlers.RestartingRound;
		}

		public override void OnDisabled()
		{
			ServerEvent.RoundEnded -= eventHandlers.RoundEnded;
			ServerEvent.RestartingRound -= eventHandlers.RestartingRound;
			base.OnDisabled();
		}
	}
}
