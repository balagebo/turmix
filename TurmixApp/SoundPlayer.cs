using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace TurmixLog
{
	public static class WavPlayer
	{
		private static SoundPlayer player = new SoundPlayer();

		public static void PlaySound(SoundType type) {
            string path = "";
			try
			{
				player.Stop();
				if (!Properties.Settings.Default.hangoskodik)
					return;
				switch (type)
				{
					case SoundType.AutóMegtelt:
                        if (Properties.Settings.Default.fullSndEnable)
                        {
                            path = Properties.Settings.Default.fullSndLoc;
                        }
						break;
					case SoundType.MentésKész:
                        if (Properties.Settings.Default.saveSndEnable)
                        {
                            path = Properties.Settings.Default.saveSndLoc;
                        }
						break;
				}
				player.SoundLocation = path;
				player.Play();
			}
			catch (Exception e)
			{
				AppLogger.WriteException(e);
				AppLogger.WriteEvent("A kivétel elkapva");
			}
		}

        public static void PlaySound(string path) {
            try
            {
                player.Stop();
                player.SoundLocation = path;
                player.Play();
            }
            catch (Exception e)
            {
                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva");
            }
        }
	}

	public enum SoundType {
		MentésKész, AutóMegtelt
	}
}
