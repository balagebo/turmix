using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KategóriaDetektor
{
    public partial class KategoriaDetektiv : Form
    {

        private MunkalapMySqlDao dao = new MunkalapMySqlDao();

        public KategoriaDetektiv()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fbd = new OpenFileDialog())
            {
                fbd.CheckFileExists = fbd.CheckPathExists = true;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    locationTx.Text = fbd.FileName;
                }
            }
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            errorGrid.Rows.Clear();

            using (ConvertProgress cp = new ConvertProgress(locationTx.Text, dao, isXls.Checked, (int)startfrom.Value))
            {
                cp.FormClosing += new FormClosingEventHandler(cp_FormClosing);
                cp.ShowDialog();
            }
        }

        void cp_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConvertProgress cp = sender as ConvertProgress;
            InsertInfo info = cp.InsertInfo;

            for (int a = 0; a < cp.Lines.Count; a += 3)
            {
                errorGrid.Rows.Add(cp.Lines[a], cp.Lines[a + 1], cp.Lines[a + 2]);
            }

            errorGrid.Rows.Add("INFO", string.Format("{0} sor a(z) {1} közül sikeresen feldolgozva.", info.UpdateCount + info.InsertCount, info.TotalCount), "");
            errorGrid.Rows.Add("INFO", string.Format("{0} sor lett beszúrva.", info.InsertCount), "");
            errorGrid.Rows.Add("INFO", string.Format("{0} sor lett frissítve.", info.UpdateCount), "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            errorGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            using (SetterPanel sp = new SetterPanel())
            {
                sp.ShowDialog();
            }
        }

    }
}
