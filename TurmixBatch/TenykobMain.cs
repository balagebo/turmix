using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixBatch
{
    public partial class TenykobMain : Form
    {
        private TenykobDao dao = new TenykobDao();
        private List<TenykobRecord> records;

        public TenykobMain()
        {
            InitializeComponent();
        }

        private void openDir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.AddExtension = ofd.CheckFileExists = ofd.CheckPathExists = ofd.SupportMultiDottedExtensions = true;
                ofd.Multiselect = false;
                ofd.Filter = "CSV állományok|*.csv";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    openDirTx.Text = ofd.FileName;
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (openDirTx.Text == "")
            {
                MessageBox.Show("Kérem válassza ki a CSV-t", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (DataProgress dp = new DataProgress(openDirTx.Text))
                {
                    dp.FormClosing += new FormClosingEventHandler(dp_FormClosing);
                    DialogResult result = dp.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        int count = records != null ? records.Count : 0;
                        if (count > 0)
                        {
                            dao.UpdateKobmeter(records);
                            historyBox.Items.Add(string.Format("{0} db sor importálva innen: {1}", count, openDirTx.Text));
                        }
                        else
                        {
                            MessageBox.Show("Nincs importálandó adat", "Feldolgozás nem sikerült", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    openDirTx.Text = "";
                }
            }
        }

        private void dp_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataProgress dp = sender as DataProgress;
            records = dp.Records;
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            using (SetterPanel sp = new SetterPanel())
            {
                sp.ShowDialog();
            }
        }

        private void TenykobMain_Load(object sender, EventArgs e)
        {
            if (dao.Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Az adatbázis nem érhető el.\nAz alkalmazás kilép", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
