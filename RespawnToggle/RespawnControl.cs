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

		public static bool ForceRespawn(int waveNum, out string error)
		{
			error = null;
			if (waveNum < 0 || waveNum >= WaveManager.Waves.Count)
			{
				error = "Invalid wave number";
				return false;
			}
			try
			{
				var wave = WaveManager.Waves.ElementAt(waveNum);
				if (wave is TimeBasedWave timeWave)
				{
					timeWave.Timer.SetTime(float.MaxValue);
					return true;
				}
				error = "Wave is not time based";
				return false;
			}
			catch (ArgumentOutOfRangeException e)
			{
				error = e.Message;
			}
			catch (ArgumentNullException e)
			{
				error = e.Message;
			}

			return false;
		}
	}
}
