using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TurmixLog
{
	public class AppLogger
	{
		private static TextWriter writer;

		static AppLogger()
		{
			string path = string.Format("{0}\\log\\log.txt", System.Windows.Forms.Application.StartupPath);
			try
			{
				
				DirectoryInfo dirInfo = new DirectoryInfo(path);
				if (!dirInfo.Exists)
				{
					Directory.CreateDirectory(string.Format("{0}\\log", System.Windows.Forms.Application.StartupPath));
                    
				}
				FileInfo info = new FileInfo(path);
                FileMode mode = info.Length < 102400 ? FileMode.Append : FileMode.Truncate;
                FileStream fs = new FileStream(path, mode, FileAccess.Write, FileShare.Write);
				writer = new StreamWriter(fs);
				writer.WriteLine(string.Format("Dátum: {0}", DateTime.Now));
			}
			catch (Exception)
			{
				writer = new StreamWriter(path, true);
				writer.WriteLine(string.Format("Dátum: {0}", DateTime.Now));
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

		public static void WriteException(Exception e)
		{
			writer.WriteLine(string.Format("!! KIVÉTEL: {0}\n{1}", e.Message, e.StackTrace));
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

		public static void WriteAutoList(List<Auto> list)
		{
			foreach (Auto a in list)
			{
				writer.Write(a);
			}
			writer.WriteLine("--------------");
		}

		public static void WriteAuto(Auto a)
		{
			writer.Write(a);
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
