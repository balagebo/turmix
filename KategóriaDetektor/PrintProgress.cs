using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KategóriaDetektor
{

	public partial class ConvertProgress : Form
	{

        

        private List<string> lines = new List<string>();
        private WebClient client = new WebClient();

        private Regex regex = new Regex(@"<option value=""(\d)"" selected>");
        private Regex ucca = new Regex(@"<div class=""tfej"">(.*)&nbsp;");
        private Regex szam = new Regex(@"(\d{4})");
        private Match match;

        public List<string> Lines
        {
            get { return lines; }
        }

        private MunkalapMySqlDao dao;
        private string file;

        private int start;

        private InsertInfo insertInfo = new InsertInfo();

        private bool isXlsMode;
        

        public InsertInfo InsertInfo
        {
            get { return insertInfo; }
        }

        public ConvertProgress(string file, MunkalapMySqlDao dao, bool isXlsMode, int start)
        {
            this.isXlsMode = isXlsMode;
            this.dao = dao;
            this.file = file;
            this.start = start;

            InitializeComponent();

            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            client.Headers.Set("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("vizmu:vizmu")));
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

			int cnt = 0;

			try
			{

                if (isXlsMode)
                {
                    
                        if (bw.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        ConvertXLS();

                    
                }
                else
                {
                    for (int a = start; a < 999999; a++ )
                    {
                        if (bw.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        cnt++;
                        GetData(a);
                        bw.ReportProgress(a * 100 / 999999);

                    }
                }
			}
			catch (Exception ex)
			{
			}
		}

		private void downloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DialogResult = DialogResult.OK;

			if (e.Error != null)
            {
				DialogResult = DialogResult.Cancel;
                MessageBox.Show("A művelet nem sikerült.\nKérem győződjön meg róla, az internet-kapcsolat él.", "A művelet nem sikerült", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
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

        private void ConvertXLS()
        {
            string line;
            int lineCnt = 0;
            string[] array;
            int index;
            Entity wd;
            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {

                    while (!sr.EndOfStream)
                    {
                        wd = new Entity();
                        
                        line = sr.ReadLine().Replace('ő', 'õ').Replace('ű', 'û').Replace('Ő', 'Õ').Replace('Ű', 'Û');
                        array = line.Split(';');
                        if (array.Length < 2)
                            continue;
                        insertInfo.TotalCount++;
                        try
                        {
                            wd.Utca = array[0].Trim().Replace("utca", "U");
                            
                        }
                        catch (Exception)
                        {

                            AddParseError("Fkód", array[0]);

                        }
                        try
                        {
                            wd.Kategoria = byte.Parse(array[1].Trim());
                            
                        }
                        catch (Exception)
                        {

                            AddParseError("Kategória", array[1]);

                        }

                        if (wd.Utca != null)
                            dao.InsertOrUpdateXls(wd, insertInfo);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.WriteException(ex);
            }
        }

        private void AddParseError(string munkalap, string mezo)
        {
            lines.Add(munkalap.ToString());
            lines.Add(string.Format("{0} beolvasása nem sikerült a következő adatból: {1}", munkalap, mezo));
            lines.Add(file);
        }

        private void GetData(int num)
        {

            insertInfo.TotalCount++;
            Entity et = new Entity();

            try
            {
                et.Fkod = num.ToString("000000");
                
                using (StreamReader sr = new StreamReader(client.OpenRead(string.Format("https://213.178.99.161/new/kategoria.php?fhkod={0}&ok=OK",
                    et.Fkod)), Encoding.UTF7))
                {
                    string resp = sr.ReadToEnd();
                    resp = resp.Replace('Õ', 'Ő').Replace('Û', 'Ű');
                    if ((match = ucca.Match(resp)).Success)
                    {
                        string utc = match.Groups[1].Value;
                        string[] reszek = utc.Trim().Split(' ');
                        et.IranyitoSzam = UInt16.Parse(reszek[0]);
                        et.Helyseg = reszek[1];
                        et.HazSzam = reszek[reszek.Length - 1];
                        utc = "";
                        for (int a = 2; a < reszek.Length - 1; a++)
                        {
                            utc += reszek[a].Trim() + " ";
                        }
                        et.Utca = utc.TrimEnd();
                    }
                    if ((match = regex.Match(resp)).Success)
                    {
                        et.Kategoria = byte.Parse(match.Groups[1].Value);
                    }
                }
                if (!et.IsEmpty)
                {
                    dao.InsertOrUpdateNet(et, insertInfo);
                }
                
            }
            catch (Exception ex)
            {
                AppLogger.WriteException(ex);
            }
        }

	}
    public class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(
        ServicePoint srvPoint
        , System.Security.Cryptography.X509Certificates.X509Certificate certificate
        , WebRequest request
        , int certificateProblem)
        {

            //Return True to force the certificate to be accepted.
            return true;

        } // end CheckValidationResult
    }
}
