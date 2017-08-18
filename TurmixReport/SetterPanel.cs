using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace TurmixReport
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

                Configuration config = ConfigurationManager.OpenExeConfiguration("TurmixReport.EXE");
                config.ConnectionStrings.ConnectionStrings["TurmixReport.Properties.Settings.connectionString"].ConnectionString = string.Format("server={0};user id={1};Password={2};database={3}",
                    dbserver.Text, dbuser.Text, dbpass.Text, dbname.Text);
                
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");

                FormClosed += new FormClosedEventHandler(SetterPanel_FormClosed);    
            }
        }

        private void SetterPanel_Load(object sender, EventArgs e)
        {
            dbserver.Text = Properties.Settings.Default.dbHost;
            dbname.Text = Properties.Settings.Default.dbName;
            dbuser.Text = Properties.Settings.Default.dbUser;
            dbpass.Text = Properties.Settings.Default.dbPass;
        }

        private void SetterPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("A változtatások érvényesítéséhez az alkalmazás újraindul.", "Újraindítás szükséges", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}
