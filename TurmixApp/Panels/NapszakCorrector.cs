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
	public partial class NapszakCorrector : Form
	{

		public WorkData adat;

		public NapszakCorrector(WorkData adat)
		{

			InitializeComponent();

			this.adat = adat;
			cimBox.Text = adat.GetInfo(true, true, true, false);
			info.Text = adat.Megjegyzes;
			napszak.SelectedIndex = 0;
		}

		private void NapszakCorrector_FormClosing(object sender, FormClosingEventArgs e)
		{
			adat.Napszak = napszak.SelectedIndex + 1;
		}

	}
}
