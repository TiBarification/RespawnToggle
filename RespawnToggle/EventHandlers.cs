using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.CustomHandlers;

namespace RespawnToggle
{
	public class EventHandlers: CustomEventsHandler
	{
		public override void OnServerRoundEnded(RoundEndedEventArgs ev)
		{
			RespawnControl.Reset();
		}

		public override void OnServerRoundRestarted()
		{
			RespawnControl.Reset();
		}
	}
}
