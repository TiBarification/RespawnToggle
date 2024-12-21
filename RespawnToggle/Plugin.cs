
namespace RespawnToggle
{
	using System;
	using Exiled.API.Features;

	public class Plugin : Plugin<Config>
	{
		/// <summary>
		/// Gets a static instance of the <see cref="Plugin"/> class.
		/// </summary>
		public static Plugin Instance { get; private set; }

		public override string Name => "RespawnToggle";

		public override Version Version => new Version(2, 0, 0);

		public override string Author => "TiBarification";

		public override Version RequiredExiledVersion => new Version(9, 0, 0);

		public override void OnEnabled()
		{
			Instance = this;
			if (!Config.IsEnabled) return;
		}

		public override void OnDisabled()
		{
			base.OnDisabled();
		}
	}
}
