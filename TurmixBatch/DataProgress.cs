using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace TurmixBatch
{
	public partial class DataProgress : Form
	{
		private List<TenykobRecord> records;
        private string filename;

        public DataProgress(string filename)
		{
            this.filename = filename;
			InitializeComponent();
			
		}

		private void DataProgress_Shown(object sender, EventArgs e)
		{
			dataWorker.RunWorkerAsync();
		}

		private void cancBtn_Click(object sender, EventArgs e)
		{
			dataWorker.CancelAsync();
		}

		private void dataWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker bw = sender as BackgroundWorker;

			if (bw.CancellationPending)
			{
				e.Cancel = true;
			}

            records = new List<TenykobRecord>();
            FileHelpers.FileHelperAsyncEngine<TenykobRecord> engine = new FileHelpers.FileHelperAsyncEngine<TenykobRecord>();
            engine.Options.IgnoreFirstLines = 1;
            // Read
            using (engine.BeginReadFile(filename))
            {
                // The engine is IEnumerable
                int cnt = 0;
                foreach (TenykobRecord cust in engine)
                {
                    records.Add(cust);
                }
            }
		}

		private void dataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DialogResult = DialogResult.OK;

			if (e.Error != null)
            {
				DialogResult = DialogResult.Cancel;
                MessageBox.Show("A művelet nem sikerült.\nKérem győződjön meg róla, hogy a CSV fájl a megfelelő formátumban van.", "Feldolgozás nem sikerült", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);

				TurmixLog.AppLogger.WriteEvent(string.Format("Feldolgozás nem sikerült: {0} - {1}", e.Error.Message, e.Error.StackTrace));
            }
            else if (e.Cancelled)
            {
				DialogResult = DialogResult.Cancel;
            }

			Close();
		}

		private void dataWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			//progress.Value = e.ProgressPercentage;
		}

        public List<TenykobRecord> Records
        {
            get
            {
                return records;
            }
        }
	}
}
