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
	public partial class CimGyujto : Panel
	{

		public CimGyujto()
		{
			InitializeComponent();
			AutoScroll = true;
		}

		public void AddPane(CimVariacio cv)
		{
			CimPanel cp = new CimPanel(cv);

			Controls.Add(cp);
			cp.Dock = DockStyle.Top;

		}

		public List<CimVariacio> GetAllChecked()
		{
			CimPanel tmp;
			List<CimVariacio> var = new List<CimVariacio>();
			foreach (Control c in Controls)
			{
				if ((tmp = c as CimPanel) != null)
				{
					if (tmp.Checked)
						var.Add(tmp.Cv);
				}
			}
			return var;

		}

	}
}
