using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixBatch
{
    public partial class SetterPanel : Form
    {
        public SetterPanel()
        {
            InitializeComponent();
        }

        private void SetterPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.dbHost = dbserver.Text;
                Properties.Settings.Default.dbName = dbname.Text;
                Properties.Settings.Default.dbUser = dbuser.Text;
                Properties.Settings.Default.dbPass = dbpass.Text;

                Properties.Settings.Default.Save();
            }
        }

        private void SetterPanel_Load(object sender, EventArgs e)
        {
            dbserver.Text = Properties.Settings.Default.dbHost;
            dbname.Text = Properties.Settings.Default.dbName;
            dbuser.Text = Properties.Settings.Default.dbUser;
            dbpass.Text = Properties.Settings.Default.dbPass;
        }
    }
}
