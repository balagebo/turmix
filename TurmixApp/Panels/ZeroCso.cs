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
	public partial class ZeroCso : Form
	{

        private KiosztasDao kdao;

		public ZeroCso(List<WorkData> adat, KiosztasDao kdao)
		{
			DataGridViewComboBoxCell combo;

			InitializeComponent();

            this.kdao = kdao;
            List<string> utcanevek = kdao.GetUtcak();

			foreach (WorkData ma in adat)
			{
				if (ma.CsoHossz == 0)
				{
					combo = new DataGridViewComboBoxCell();
					foreach (string ns in utcanevek) 
						combo.Items.Add(ns);

					try
					{
						combo.Value = ma.Utca.ToUpper();
					}
					catch (Exception)
					{
						combo.Value = utcanevek[0];
					}

					int row = csoGrid.Rows.Add();
					csoGrid[Cim.Index, row].Value = ma;
					csoGrid[ValosCsohossz.Index, row].Value = 0;
					csoGrid[ValosCim.Index, row] = combo;
                    csoGrid[ValosHsz.Index, row].Value = ma.HazSzam;
                    csoGrid[CsoStr.Index, row].Value = ma.CsoStr;
				}
			}
			
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void csoGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			try
			{
				WorkData ma = csoGrid[0, e.RowIndex].Value as WorkData;

				switch (e.ColumnIndex)
				{
					case 0:
						e.Value = string.Format("{0} - Info: {1}", ma.Cim, ma.Megjegyzes);
						break;
                    case 3:
                        e.Value = ma.HazSzam;
                        break;
					case 4:
						e.Value = ma.CsoHossz.ToString();
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
			
			WorkData ma = (WorkData)csoGrid[0, e.RowIndex].Value;

			switch (e.ColumnIndex)
			{
                case 2:
                    string ujutca = csoGrid[ValosCim.Index, e.RowIndex].Value.ToString();
                    if (ma.Utca != ujutca)
                    {
                        ma.Utca = ujutca;
                    }
                    break;
                case 3:
                    ma.HazSzam = csoGrid[ValosHsz.Index, e.RowIndex].Value.ToString();
                    break;
				case 4:
					int newal = ma.CsoHossz;
					try
					{
						newal = int.Parse(csoGrid[ValosCsohossz.Index, e.RowIndex].Value.ToString());
						if (newal < 0)
							throw new FormatException();
						ma.CsoHossz = newal;
					}
					catch (FormatException fe)
					{
						MessageBox.Show("A csőhossz pozitív egész szám kell hogy legyen!", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
						csoGrid[ValosCsohossz.Index, e.RowIndex].Value = ma.CsoHossz;
					}
					break;
				
			}
			
		}

        private void ZeroCso_FormClosing(object sender, FormClosingEventArgs e)
        {

            WorkData ma;

            for (int a = 0; a < csoGrid.RowCount; a++)
            {
                ma = (WorkData)csoGrid[0, a].Value;
                kdao.GetLatLngProb(ma);
            }

        }

		private void ZeroCso_Shown(object sender, EventArgs e)
		{

		}

		private void csoGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.ThrowException = false;
		}

		private void ZeroCso_Load(object sender, EventArgs e)
		{
			csoGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
	}
}
