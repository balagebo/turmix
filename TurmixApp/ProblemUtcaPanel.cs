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
	public partial class ProblemUtcaPanel : AbstarctAdatPanel
	{
		public ProblemUtcaPanel() : base("problemutca")
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
						message = "'Utca' értéke nem megfelelő!";
						break;
				}
				MessageBox.Show(message, "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
				autoGrid.BeginEdit(true);
			}
		}

		protected override void CustomizeTableUI()
		{
			autoGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			Text = "Állandó problémás utcák";
		}
	}
}
