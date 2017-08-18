using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TurmixLog
{

    public delegate void FoldutDelegate(string utca, double flat, double flng);

    public partial class FoldutPanel : AbstarctAdatPanel
    {

        public event FoldutDelegate BeginCoordinateEdit;

        public FoldutPanel() : base("latlng2")
        {
            autoGrid.CellContentClick += new DataGridViewCellEventHandler(autoGrid_CellContentClick);

            Button copyBtn = new Button();
            copyBtn.Text = "Másol";
            copyBtn.Dock = DockStyle.Left;
            copyBtn.Click += new EventHandler(copyBtn_Click);

            Button pasteBtn = new Button();
            pasteBtn.Text = "Beilleszt";
            pasteBtn.Dock = DockStyle.Left;
            pasteBtn.Click += new EventHandler(pasteBtn_Click);

            //panel1.Controls.Add(pasteBtn);
            //panel1.Controls.Add(copyBtn);

            Width = 600;
        }

        void pasteBtn_Click(object sender, EventArgs e)
        {
            try
            {

                DataObject obj = (DataObject)Clipboard.GetDataObject();
                string[] dr = (string[])obj.GetData(typeof(string[]));

                int index = autoGrid.SelectedCells[0].RowIndex;
                for (int a = 0; a < dr.Length; a++)
                {
                    autoGrid[a + 4, index].Value = dr[a];
                    
                }

                //Clipboard.Clear();
            }
            catch (Exception ex)
            {
            }
        }

        void copyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] rowData = new string[3];
                for (int a = 0; a < 3; a++)
                {
                    rowData[a] = autoGrid[a + 4, autoGrid.SelectedCells[0].RowIndex].Value.ToString();
                }

                DataObject data = new DataObject();
                data.SetData(typeof(string[]), rowData);
                Clipboard.SetDataObject(data, true);
            }
            catch (Exception ex)
            {
            }
        }

        void autoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0 && BeginCoordinateEdit != null)
            {
                
                if (autoGrid[1, e.RowIndex].Value == DBNull.Value) {
                    MessageBox.Show("Először adjon meg egy utcanevet!", "Hiányos adatok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string utca = (string)autoGrid[1, e.RowIndex].Value;
                BeginCoordinateEdit(utca, (double)autoGrid[4, e.RowIndex].Value, (double)autoGrid[5, e.RowIndex].Value);
                DialogResult = DialogResult.Abort;
                Close();
            }
        }

        protected override void CustomizeTableUI()
        {
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.Text = "...";
            bcol.ToolTipText = "Koordináták módosítása";
            bcol.UseColumnTextForButtonValue = true;
            bcol.Width = 30;

            autoGrid.Columns.Add(bcol);
           
            autoGrid.Columns[1].Visible = autoGrid.Columns[2].Visible = false;
            autoGrid.Columns[3].HeaderText = "Földútpont-szélesség";
            autoGrid.Columns[4].HeaderText = "Földútpont-hosszúság";
            autoGrid.Columns[5].HeaderText = "Földút hossza [km]";
            //autoGrid.Columns[5].ReadOnly = true;

            Text = "Földútpontok";
        }

        protected override void searchTx_TextChanged(object sender, EventArgs e)
        {
            string filterTx = autoGrid.Columns[1].Name + " like '" + searchTx.Text + "%'";
            dataView.RowFilter = filterTx;
            
        }

        protected override void AbstarctAdatPanel_Load(object sender, EventArgs e)
        {
            autoGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
