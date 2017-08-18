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
	public partial class TenylegesM3Panel : AbstarctAdatPanel
	{
		public TenylegesM3Panel() : base("tm3")
		{
		}

		protected override void autoGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			string message = "";
			if (e.Exception.GetType() == typeof(FormatException))
			{
				switch (e.ColumnIndex)
				{
					case 0:
						message = "'Cím' értéke nem megfelelő!";
						break;
					case 1:
						message = "A tényleges köbméter értéke 0 és 255 közé eső szám lehet!";
						break;
				}
				MessageBox.Show(message, "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
				autoGrid.BeginEdit(true);
			}
		}

		protected override void CustomizeTableUI()
		{
			autoGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			autoGrid.Columns[0].HeaderText = "Cím";
			autoGrid.Columns[1].HeaderText = "Tényleges m3";

			Text = "Tényleges kapacitás adatok";
		}
	}
}
