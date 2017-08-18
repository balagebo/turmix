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
	public partial class CimPanel : UserControl
	{
		private CimVariacio cv;

		public CimVariacio Cv
		{
			get { return cv; }
			set { cv = value; }
		}

		public CimPanel(CimVariacio cv)
		{
			this.cv = cv;
			InitializeComponent();

			string inf = string.Format("{0}\nInfo: {1}", cv.Cim, cv.Megjegyzes);

			cim.Text = cv.Cim;
			info.Text = cv.Megjegyzes;
			
			cimTip.SetToolTip(info, inf);
			//cimTip.SetToolTip(info, inf);
		}

		private void select_CheckedChanged(object sender, EventArgs e)
		{
			cv.Check = select.Checked;

			if (select.Checked)
			{
				cim.BackColor = info.BackColor = Color.LightBlue;
			}
			else
			{
				cim.BackColor = info.BackColor = Color.White;
			}
		}

		public bool Checked
		{
			get
			{
				return select.Checked;
			}
		}

		private void CimPanel_MouseEnter(object sender, EventArgs e)
		{
			if (!select.Checked)
			{
				info.BackColor = cim.BackColor = Color.PapayaWhip;
			}
		}

		private void CimPanel_MouseLeave(object sender, EventArgs e)
		{
			if (!select.Checked)
			{
				info.BackColor = cim.BackColor = Color.White;
			}
		}

		private void info_Click(object sender, EventArgs e)
		{
			select.Checked = !select.Checked;
		}
	}
}
