using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace TurmixLog
{

	static class Program
	{
		private static MainForm app;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				app = new MainForm(Environment.GetCommandLineArgs());

				Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
				Application.Run(app);
			}
			catch (Exception ex)
			{
				try
				{
					MessageBox.Show("A programban hiba történt, ezért befejezi a működését.",
						"Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
					AppLogger.WriteException(ex);
					AppLogger.WriteEvent("A kivétel elkapva.");
				}
				catch (Exception)
				{
				}
			}
						
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			try
			{
				AppLogger.WriteException(e.Exception);
				string filename = string.Format("{0}\\log\\{1}_save.tmx", Application.StartupPath, DateTime.Now.ToShortDateString());
				MessageBox.Show(string.Format("A programban hiba történt, ezért befejezi a működését.\nAz aktuális munka mentésre kerül ide: {0}",
					filename), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);


				app.SaveState(filename);
				app.CloseUp();
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
			
			Application.Exit();
		}

	}
}
