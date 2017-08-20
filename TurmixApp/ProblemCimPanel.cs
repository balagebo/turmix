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
	public partial class ProblemCimPanel : AbstarctAdatPanel
	{
		public ProblemCimPanel() : base("Problematic")
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
				}
				MessageBox.Show(message, "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
				autoGrid.BeginEdit(true);
			}
		}

		protected override void CustomizeTableUI()
		{
			autoGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			autoGrid.Columns[0].HeaderText = "Cím";

			Text = "Állandó problémás címek";
		}
	}
}
