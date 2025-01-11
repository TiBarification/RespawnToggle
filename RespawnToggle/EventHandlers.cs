using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs.Server;

namespace RespawnToggle
{
	public class EventHandlers
	{
		public void RoundEnded(RoundEndedEventArgs ev)
		{
			RespawnControl.Reset();
		}

		public void RestartingRound()
		{
			RespawnControl.Reset();
		}
	}
}
