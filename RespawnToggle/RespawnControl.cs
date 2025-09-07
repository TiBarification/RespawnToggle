using Respawning.Waves;
using Respawning;
using System.Linq;

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
				foreach (TimeBasedWave wave in WaveManager.Waves.Where(w => w is TimeBasedWave))
				{
					if (value)
					{
						wave.Timer.Pause(float.MaxValue);
					}
					else
					{
						wave.Timer.Pause(0);
					}
				}

				noRespawn = value;
			}
		}

		public static void Reset()
		{
			noRespawn = false;
			foreach (TimeBasedWave wave in WaveManager.Waves.Where(w => w is TimeBasedWave))
			{
				wave.Timer.Reset(true);
				wave.Timer.Pause(0);
			}
		}
	}
}
