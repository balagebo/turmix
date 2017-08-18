using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KategóriaDetektor
{
	public class AppLogger
	{
		private static TextWriter writer;

		static AppLogger()
		{
			string path = string.Format("{0}\\buntilog.txt", System.Windows.Forms.Application.StartupPath);
			try
			{

				FileInfo info = new FileInfo(path);
                FileMode mode = info.Length < 102400 ? FileMode.Append : FileMode.Truncate;
                FileStream fs = new FileStream(path, mode, FileAccess.Write, FileShare.Write);
				writer = new StreamWriter(fs);
			}
			catch (Exception)
			{
				writer = new StreamWriter(path, true);
			}
		}

		public static void WriteMapping(string rsz, string cim)
		{
			writer.WriteLine(string.Format("Hozzárendelés: {0}, {1}", rsz, cim));
		}

		public static void WriteSelect(string cim, bool sel)
		{
			writer.WriteLine(string.Format("Kiválasztva: {0} - {1}", cim, sel));
		}

		public static void WriteUnmapping(string rsz, int menet)
		{
			writer.WriteLine(string.Format("Törlés: {0} , Menet: {1}", rsz, menet));
		}

		public static void WriteException(Exception e, string munkalap)
		{
			writer.WriteLine(string.Format("!! Hiba a {0} fkódnál: {1}\nTrace:{2}", munkalap, e.Message, e.StackTrace));
		}

        public static void WriteException(Exception e)
        {
            writer.WriteLine(string.Format("!! Hiba : {0}\nTrace:{1}", e.Message, e.StackTrace));
        }

		public static void WriteOpen(string file)
		{
			writer.WriteLine(string.Format("Megnyitás: {0}", file));
		}

		public static void WriteSave(string file)
		{
			writer.WriteLine(string.Format("Mentés: {0}", file));
		}

		public static void WriteEvent(string val)
		{
			writer.WriteLine(val);
		}

		public static void WriteAutoChange(string rsz, string prop, string old, string neval)
		{
			writer.WriteLine(string.Format("{0} tulajdonsága változott: {1} :: {2} --> {3}", rsz, prop, old, neval));
		}

		public static void CloseLog()
		{
			try
			{
				writer.Flush();
				writer.Close();
			}
			catch (Exception)
			{
			}
		}
	}
}
