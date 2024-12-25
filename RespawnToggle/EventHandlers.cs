using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespawnToggle
{
	public class EventHandlers
	{
		public void OnRoundRestarting()
		{
			RespawnControl.NoRespawn = false;
		}
	}
}
