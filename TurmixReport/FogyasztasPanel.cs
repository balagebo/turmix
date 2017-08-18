using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixReport
{
    public partial class FogyasztasPanel : UserControl
    {
        public FogyasztasPanel()
        {
            InitializeComponent();
        }

        public DateTime KezdoDatum
        {
            get
            {
                return kezdo.Value;
            }
        }

        public DateTime VegDatum
        {
            get
            {
                return veg.Value;
            }
        }
    }
}
