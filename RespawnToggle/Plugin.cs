using System;

namespace RespawnToggle
{
	public class RespawnTogglePlugin : LabApi.Loader.Features.Plugins.Plugin
	{
		/// <summary>
		/// Gets a static instance of the <see cref="Plugin"/> class.
		/// </summary>
		public static RespawnTogglePlugin Instance { get; private set; }

		public override string Name => "RespawnToggle";
		public override string Description => "Provides a way to disable wave spawn";
		public override Version Version => new Version(3, 0, 0);
		public override string Author => "TiBarification";
		public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;


		EventHandlers eventHandlers;

		public override void Enable()
		{
			Instance = this;
			eventHandlers = new EventHandlers();
			LabApi.Events.CustomHandlers.CustomHandlersManager.RegisterEventsHandler(eventHandlers);
		}

		public override void Disable()
		{
			LabApi.Events.CustomHandlers.CustomHandlersManager.UnregisterEventsHandler(eventHandlers);
			eventHandlers = null;
			Instance = null;
		}
	}
}
