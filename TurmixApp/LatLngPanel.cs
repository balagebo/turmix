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
	public partial class LatLngPanel : AbstarctAdatPanel
	{

		public LatLngPanel() : base("latlng2")
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
						message = "A szélességi koordináta értéke nem megfelelő!";
						break;
					case 2:
						message = "A hosszúsági koordináta értéke nem megfelelő!";
						break;

				}
				MessageBox.Show(message, "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
				autoGrid.BeginEdit(true);
			}
		}

		protected override void CustomizeTableUI()
		{

			Text = "Koordináta adatok";
            autoGrid.Columns[3].Visible = autoGrid.Columns[4].Visible = autoGrid.Columns[5].Visible = false;
		}
	}
}
