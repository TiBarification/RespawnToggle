using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respawning.Waves;
using Respawning;

namespace RespawnToggle
{
	public static class RespawnControl
	{
		private static bool noRespawn;

		public static bool NoRespawn
		{
			get => noRespawn;
			set
			{
				foreach (var wave in WaveManager.Waves)
				{
					if (wave is TimeBasedWave timeWave)
					{
						if (value)
						{
							timeWave.Timer.Pause(float.MaxValue);
						}
						else
						{
							timeWave.Timer.Reset();
						}
					}
				}

				noRespawn = value;
			}
		}
	}
}
