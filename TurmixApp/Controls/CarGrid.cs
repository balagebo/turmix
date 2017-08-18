using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixLog
{
	public partial class CarGrid : DataGridView
	{
		private bool reEntrent = false;

		protected override bool SetCurrentCellAddressCore(int columnIndex, int rowIndex, bool setAnchorCellAddress, bool validateCurrentCell, bool throughMouseClick)
		{
			bool rv = true;
			try
			{
				if (!reEntrent)
				{
					reEntrent = true;
					rv = base.SetCurrentCellAddressCore(columnIndex, rowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick);
					reEntrent = false;
				}
			}
			catch (Exception)
			{
				rv = false;
			}
			return rv;

		}

		protected override void OnLostFocus(EventArgs e)
		{
			if (SelectedCells.Count > 0)
			{
				InvalidateCell(CurrentCell);
			}
		}

	}
}
