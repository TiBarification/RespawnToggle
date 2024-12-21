namespace RespawnToggle
{
	using System.ComponentModel;

	using Exiled.API.Interfaces;

	/// <inheritdoc cref="IConfig"/>
	public sealed class Config : IConfig
	{
		/// <inheritdoc/>
		[Description("Indicates whether the plugin is enabled or not")]
		public bool IsEnabled { get; set; } = true;
		public bool Debug { get; set; } = false;

	}
}
