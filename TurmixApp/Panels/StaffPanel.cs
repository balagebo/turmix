using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace TurmixLog
{
	public partial class StaffPane : Form
	{

		private Auto au;

		public StaffPane(Auto au)
		{
			this.au = au;

			InitializeComponent();

			sofor.Text = au.Sofor;
			seged.Text = au.Seged;

		}

		private void StaffPane_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{

				if (sofor.Text.Trim() == "")
				{
					MessageBox.Show("Adja meg a jármű vezetőjét!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Cancel = true;
				}
				else
				{
					au.Sofor = sofor.Text;
					au.Seged = seged.Text;
				}
			}
		}
	}
}
