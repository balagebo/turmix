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
	public partial class ProblemAddressPanel : Form
	{

		private List<int> modifiedIds = new List<int>();

		public List<int> ModifiedIds
		{
			get { return modifiedIds; }
		}

		public ProblemAddressPanel(Repository repo)
		{
			InitializeComponent();
			
			int ind;
			for (int a = 0; a < 3; a++)
			{
				foreach (WorkData data in repo.GetNapszakAdat(a).Values)
				{
					//if (!data.Jozsai)
					{
						ind = streetGrid.Rows.Add(data.WorksheetNumber, data.Cim, data.Megjegyzes, data.Problematic);
						streetGrid.Rows[ind].Tag = data;
					}
				}
			}
		}

		private void streetGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			WorkData w1 = streetGrid.Rows[e.RowIndex1].Tag as WorkData,
					 w2 = streetGrid.Rows[e.RowIndex2].Tag as WorkData;
			switch (e.Column.Index)
			{
				case 0:
					e.SortResult = w1.WorksheetNumber.CompareTo(w2.WorksheetNumber);
					break;
				case 1:
					e.SortResult = w1.Cim.CompareTo(w2.Cim);
					break;
			}
			e.Handled = true;
		}

		private void ProblemAddressPanel_Load(object sender, EventArgs e)
		{
			streetGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void ProblemAddressPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				WorkData wd;
				foreach (DataGridViewRow row in streetGrid.Rows)
				{
					wd = row.Tag as WorkData;
					bool nval;
					if ((nval = (bool)row.Cells[3].EditedFormattedValue) != wd.Problematic)
					{
						wd.Problematic = nval;
						modifiedIds.Add(wd.Number);
					}
				}
			}
		}
	}
}
