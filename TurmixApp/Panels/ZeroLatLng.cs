using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixLog
{
    public delegate void CoordinateClickDelegate(int id, string utca);

    public partial class ZeroLatLng : Form
    {
        protected List<WorkData> adatok;
        protected KiosztasDao dao;

        public event CoordinateClickDelegate BeginCoordinateEdit;

        public ZeroLatLng()
        {
        }

		public ZeroLatLng(List<WorkData> adatok, KiosztasDao dao)
		{
            this.dao = dao;
            this.adatok = adatok;
            

			InitializeComponent();

            FillData();
			
		}

        protected virtual void FillData()
        {
            DataGridViewButtonCell button;
            foreach (WorkData ma in adatok)
            {
                button = new DataGridViewButtonCell();

                int row = csoGrid.Rows.Add();
                csoGrid[Cim.Index, row].Value = ma;
                csoGrid[Megjegyzes.Index, row].Value = ma.Megjegyzes;
                csoGrid[Lat.Index, row].Value = ma.Lat.ToString();
                csoGrid[Lng.Index, row].Value = ma.Lng.ToString();
                csoGrid[Koord.Index, row] = button;
            }
        }

        private void ZeroLatLng_Load(object sender, EventArgs e)
        {
            csoGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void csoGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                WorkData ma = csoGrid[0, e.RowIndex].Value as WorkData;

                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = ma.Cim;
                        break;
                }
                e.FormattingApplied = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void csoGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            WorkData wd;
            double val;
            switch (e.ColumnIndex)
            {
                case 2:
                    wd = csoGrid[0, e.RowIndex].Value as WorkData;
                    try
                    {
                        val = double.Parse((string)csoGrid[2, e.RowIndex].Value);
                        wd.Lat = val;
                    }
                    catch (FormatException)
                    {
                        csoGrid[2, e.RowIndex].Value = wd.Lat;
                    }
                    break;
                case 3:
                    wd = csoGrid[0, e.RowIndex].Value as WorkData;
                    try
                    {
                        val = double.Parse((string)csoGrid[3, e.RowIndex].Value);
                        wd.Lng = val;
                    }
                    catch (FormatException)
                    {
                        csoGrid[3, e.RowIndex].Value = wd.Lng;
                    }
                    break;
            }
        }

        private void ZeroLatLng_FormClosing(object sender, FormClosingEventArgs e)
        {
            WorkData ma;
            if (DialogResult == DialogResult.OK)
            {
                for (int a = 0; a < csoGrid.RowCount; a++)
                {
                    ma = (WorkData)csoGrid[0, a].Value;
                    dao.GetLatLngProb(ma);
                    dao.InsertLatLng(ma);
                }

            }
            else
            {
                for (int a = 0; a < csoGrid.RowCount; a++)
                {
                    ma = (WorkData)csoGrid[0, a].Value;
                    ma.Lat = ma.Lng = 0;
                }
            }
        }
        private void csoGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void csoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == Koord.Index && BeginCoordinateEdit != null)
            {
                WorkData ma = (WorkData)csoGrid[0, e.RowIndex].Value;
                BeginCoordinateEdit(ma.Number, ma.Utca);
                DialogResult = DialogResult.Abort;
                Close();
            }
        }
    }
}
