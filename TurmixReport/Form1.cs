using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixReport
{
    public partial class Form1 : Form
    {

        private ReportDao reportDao = new ReportDao();

        public Form1()
        {
            InitializeComponent();
        }       

        private void atlagFogyEgy_Click(object sender, EventArgs e)
        {
            using (ReportViewerPanel rwp = new ReportViewerPanel(Feladat.FogyasztasIdoszak))
            {
                rwp.ShowDialog();
            }
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            using (SetterPanel sp = new SetterPanel())
            {
                sp.ShowDialog();
            }
        }

    }

    public enum Feladat
    {
        None, FogyasztasIdoszak
    }
}
