using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace TurmixLog
{
	public partial class PrintProgress : Form
	{
		private List<WorkData> list;

		public PrintProgress(List<WorkData> malist)
		{
			list = malist;

			InitializeComponent();

			
		}

		private void PrintProgress_Shown(object sender, EventArgs e)
		{
			downloadWorker.RunWorkerAsync();
		}

		private void cancBtn_Click(object sender, EventArgs e)
		{
			downloadWorker.CancelAsync();
		}

		private void downloadWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker bw = sender as BackgroundWorker;

			if (bw.CancellationPending)
			{
				e.Cancel = true;
			}

			System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
			int cnt = 0;

			WebClient client = new WebClient();
			client.Headers.Set("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("vizmu:vizmu")));

			PdfMerge merger = new PdfMerge();

			try
			{

				foreach (WorkData ma in list)
				{
                    client.DownloadData(string.Format("{0}{1}", Properties.Settings.Default.nyomtatURL, ma.WorksheetNumber));
                    merger.AddDocument(client.OpenRead(string.Format("{0}{1}", Properties.Settings.Default.nyomtatURL2, ma.WorksheetNumber)));
					bw.ReportProgress((++cnt) * 100 / list.Count);
				}

				merger.Merge(string.Format("{0}\\munkalapok.pdf", Environment.GetFolderPath
    (Environment.SpecialFolder.DesktopDirectory)));
			}
			catch (NullReferenceException nu)
			{
			}
		}

		private void downloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DialogResult = DialogResult.OK;

			if (e.Error != null)
            {
				DialogResult = DialogResult.Cancel;
                MessageBox.Show("A művelet nem sikerült.\nKérem győződjön meg róla, hogy vannak munkalapok kiválasztva.", "Letöltés nem sikerült", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);

				AppLogger.WriteEvent(string.Format("Letöltés nem sikerült: {0} - {1}", e.Error.Message, e.Error.StackTrace));
            }
            else if (e.Cancelled)
            {
				DialogResult = DialogResult.Cancel;
            }

			Close();
		}

		private void downloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progress.Value = e.ProgressPercentage;
		}
	}
}
