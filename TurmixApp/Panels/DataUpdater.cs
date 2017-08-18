using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace TurmixLog
{
    public partial class DataUpdater : Form
    {
        private KiosztasDao kdao;
		private DateTime date;
		private List<WorkData> workData;

		public List<WorkData> WorkData
		{
			get { return workData; }
			set { workData = value; }
		}
		private List<Auto> autok;

		public List<Auto> Autok
		{
			get { return autok; }
			set { autok = value; }
		}
		private CimOsszesito osszCim;

		public CimOsszesito Cimosszesito
		{
			get { return osszCim; }
			set { osszCim = value; }
		}

        public DataUpdater(DateTime date, KiosztasDao kdao)
        {
            this.kdao = kdao;
			this.date = date;
            InitializeComponent();
           
        }

        private void DataUpdater_Shown(object sender, EventArgs e)
        {
			kdao.ExceptionOccured += new EmptyDelegate(dao_ExceptionOccured);

			updateWorker.RunWorkerAsync();
        }

		private void cancBtn_Click(object sender, EventArgs e)
		{
			updateWorker.CancelAsync();
		}

		private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker bw = sender as BackgroundWorker;

			if (bw.CancellationPending)
			{
				e.Cancel = true;
			}
			
			workData = kdao.GetWorkData(date, out autok, out osszCim);
		}

		void dao_ExceptionOccured()
		{
			updateWorker.CancelAsync();
		}

		private void updateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DialogResult = DialogResult.OK;

			if (e.Error != null)
			{
				DialogResult = DialogResult.Cancel;
				MessageBox.Show("A művelet nem sikerült.\nKérem győződjön meg róla, hogy a beállítások helyesek és az internetkapcsolat él.", "Letöltés nem sikerült", MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				AppLogger.WriteEvent(string.Format("Letöltés nem sikerült: {0} - {1}", e.Error.Message, e.Error.StackTrace));
			}
			else if (e.Cancelled)
			{
				DialogResult = DialogResult.Cancel;

			}

			Close();
		}

		private void updateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			
		}

		private void DataUpdater_FormClosing(object sender, FormClosingEventArgs e)
		{
			kdao.ExceptionOccured -= dao_ExceptionOccured;
		}
    }
}
