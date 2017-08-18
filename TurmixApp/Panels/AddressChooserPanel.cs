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
	public partial class MultiChoice : Form
	{

		public MultiChoice(List<CimVariacio> cimv)
		{
			InitializeComponent();

			foreach (CimVariacio v in cimv)
			{
				cimek.AddPane(v);
			}
		}

		public List<CimVariacio> GetAllChecked()
		{
			return cimek.GetAllChecked();
		}
	}


}
