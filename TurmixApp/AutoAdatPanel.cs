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
	public partial class AutoAdatPanel : AbstarctAdatPanel
	{
		public AutoAdatPanel() : base("auto")
		{
			
		}

		protected override void CustomizeTableUI()
		{
			autoGrid.Columns[0].HeaderText = "Rendszám";
			autoGrid.Columns[1].HeaderText = "Kapacitás";
			autoGrid.Columns[2].HeaderText = "Havi lízingdíj";
			autoGrid.Columns[3].HeaderText = "Fogyasztás";

			autoGrid.Columns[2].DefaultCellStyle.BackColor = autoGrid.Columns[3].DefaultCellStyle.BackColor = Color.AntiqueWhite;

			Text = "Járművek adattáblája";
		}

		protected override void autoGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			string message = "";
			if (e.Exception.GetType() == typeof(FormatException))
			{
				switch (e.ColumnIndex)
				{
					case 0:
						message = "'Rendszám' értéke csak szabványos rendszám lehet!";
						break;
					case 1:
						message = "'Kapacitás' értéke 0 és 255 közé eső szám lehet!";
						break;
					case 2:
						message = "'Lízing' értéke csak nemnegatív szám lehet!";
						break;
					case 3:
						message = "'Fogyasztás' értéke csak nemnegatív szám lehet!";
						break;

				}
				MessageBox.Show(message, "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
				autoGrid.BeginEdit(true);
			}
		}
	}
}
