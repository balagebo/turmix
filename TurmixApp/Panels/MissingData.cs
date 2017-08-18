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
	public partial class MissingData : Form
	{
		public MissingData(Dictionary<int, WorkData> adat, int ossz)
		{
			InitializeComponent();

			label2.Text = string.Format("{0} db cím; a generált CSV {1} sort fog tartalmazni", adat.Count, ossz);

			foreach (WorkData ma in adat.Values)
			{
				errorbox.Items.Add(ma.GetInfo(true, true, true, false));
			}
		}
	}
}
