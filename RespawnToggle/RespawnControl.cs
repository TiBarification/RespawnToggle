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
							timeWave.Timer.Pause(0);
						}
					}
				}

				noRespawn = value;
			}
		}

		public static void Reset()
		{
			noRespawn = false;
			foreach (var wave in WaveManager.Waves)
			{
				if (wave is TimeBasedWave timeWave)
				{
					timeWave.Timer.Reset(true);
				}
			}
		}
	}
}
