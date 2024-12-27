using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respawning.Waves;
using Respawning;
using YamlDotNet.Core.Tokens;

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

		public static TimeBasedWave ForceRespawn(int waveNum, out string error)
		{
			error = null;
			if (waveNum < 0 || waveNum >= WaveManager.Waves.Count)
			{
				error = "Invalid wave number";
				return null;
			}
			try
			{
				var wave = WaveManager.Waves.ElementAt(waveNum);
				if (wave is TimeBasedWave timeWave)
				{
					NoRespawn = false;
					timeWave.Timer.SpawnIntervalSeconds = 0;
					timeWave.Timer.SetTime(float.MaxValue);
					return timeWave;
				}
				error = "Wave is not time based";
				return null;
			}
			catch (ArgumentOutOfRangeException e)
			{
				error = e.Message;
			}
			catch (ArgumentNullException e)
			{
				error = e.Message;
			}

			return null;
		}

		public static TimeBasedWave GetWave(int waveNum)
		{
			if (waveNum < 0 || waveNum >= WaveManager.Waves.Count)
			{
				return null;
			}
			var wave = WaveManager.Waves.ElementAt(waveNum);
			if (wave is TimeBasedWave timeWave)
			{
				return timeWave;
			}
			throw new ArgumentException("Wave is not time based");
		}
	}
}
