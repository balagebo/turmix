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
	public partial class SettingsPanel : Form
	{

        public static string UpdateURL
        {
            get
            {
                return Properties.Settings.Default.updateURL;
            }
        }

		public SettingsPanel()
		{
			InitializeComponent();

            fullSndLoc.Text = Properties.Settings.Default.fullSndLoc;
            saveSndLoc.Text = Properties.Settings.Default.saveSndLoc;
            fullSndEnable.Checked = Properties.Settings.Default.fullSndEnable;
            saveSndEnable.Checked = Properties.Settings.Default.saveSndEnable;
            hangoskodik.Checked = Properties.Settings.Default.hangoskodik;

            mentettAuto.Checked = Properties.Settings.Default.mentettAuto;
            mentettFold.Checked = Properties.Settings.Default.mentettFold;
            mentettKoord.Checked = Properties.Settings.Default.mentettKoord;
            
            updateURL.Text = Properties.Settings.Default.updateURL;
            
			userName.Text = Properties.Settings.Default.userName;
			password.Text = Properties.Settings.Default.password;

            dbserver.Text = Properties.Settings.Default.dbHost;
            dbname.Text = Properties.Settings.Default.dbName;
            dbuser.Text = Properties.Settings.Default.dbUser;
            dbpass.Text = Properties.Settings.Default.dbPass;

			kisAutoLimit.Value = (decimal)Properties.Settings.Default.kisAutoLimit;
			otkmlimit.Value = (decimal)Properties.Settings.Default.otkm;
			tizkmlimit.Value = (decimal)Properties.Settings.Default.tizkm;
			telit.Value = (decimal)Properties.Settings.Default.telitettCel;

			cso1.Value = (decimal)Properties.Settings.Default.cso1;
			cso2.Value = (decimal)Properties.Settings.Default.cso2;
			cso3.Value = (decimal)Properties.Settings.Default.cso3;
			cso4.Value = (decimal)Properties.Settings.Default.cso4;
			cso5.Value = (decimal)Properties.Settings.Default.cso5;
			cso6.Value = (decimal)Properties.Settings.Default.cso6;
			csoegyeb.Value = (decimal)Properties.Settings.Default.csoegyeb;

			sziv5.Value = (decimal)Properties.Settings.Default.sziv5;
			sziv10.Value = (decimal)Properties.Settings.Default.sziv10;
			sziv12.Value = (decimal)Properties.Settings.Default.sziv12;
			szivegyeb.Value = (decimal)Properties.Settings.Default.szivegyeb;

			ebedido.Value = (decimal)Properties.Settings.Default.ebedido;
			speed.Value = (decimal)Properties.Settings.Default.speed;
            foldSeb.Value = (decimal)Properties.Settings.Default.foldutSeb;
			bonus.Value = (decimal)Properties.Settings.Default.kettenUlnekBonus;

			benzinar.Value = (decimal)Properties.Settings.Default.benzinar;
			costbonus.Value = (decimal)Properties.Settings.Default.costbonus;
			costbonusactive.Checked = Properties.Settings.Default.costbonusactive;

			workDays.Value = (decimal)Properties.Settings.Default.workDays;

			kissoforber.Value = (decimal)Properties.Settings.Default.kissoforber;
			kissegedber.Value = (decimal)Properties.Settings.Default.kissegedber;
			kissoforjar.Value = (decimal)Properties.Settings.Default.kissoforjar;
			kissegedjar.Value = (decimal)Properties.Settings.Default.kissegedjar;

			nagysoforber.Value = (decimal)Properties.Settings.Default.nagysoforber;
			nagysegedber.Value = (decimal)Properties.Settings.Default.nagysegedber;
			nagysoforjar.Value = (decimal)Properties.Settings.Default.nagysoforjar;
			nagysegedjar.Value = (decimal)Properties.Settings.Default.nagysegedjar;

            nyomtatURL.Text = Properties.Settings.Default.nyomtatURL;
            nyomtatURL2.Text = Properties.Settings.Default.nyomtatURL2;

            updateURL2.Text = Properties.Settings.Default.updateURL2;

		}

		private void okBtn_Click(object sender, EventArgs e)
		{

			Properties.Settings.Default.updateURL = updateURL.Text;
            Properties.Settings.Default.updateURL2 = updateURL2.Text;

            Properties.Settings.Default.saveSndEnable = saveSndEnable.Checked;
            Properties.Settings.Default.fullSndEnable = fullSndEnable.Checked;
            Properties.Settings.Default.saveSndLoc = saveSndLoc.Text;
            Properties.Settings.Default.fullSndLoc = fullSndLoc.Text;
            Properties.Settings.Default.hangoskodik = hangoskodik.Checked;

            Properties.Settings.Default.mentettAuto = mentettAuto.Checked;
            Properties.Settings.Default.mentettFold = mentettFold.Checked;
            Properties.Settings.Default.mentettKoord = mentettKoord.Checked;

			Properties.Settings.Default.userName = userName.Text;
			Properties.Settings.Default.password = password.Text;
            Properties.Settings.Default.dbHost = dbserver.Text;
            Properties.Settings.Default.dbName = dbname.Text;
            Properties.Settings.Default.dbUser = dbuser.Text;
            Properties.Settings.Default.dbPass = dbpass.Text;

			Properties.Settings.Default.kisAutoLimit = (int)kisAutoLimit.Value;
			Properties.Settings.Default.otkm = (double)otkmlimit.Value;
			Properties.Settings.Default.tizkm = (double)tizkmlimit.Value;
			Properties.Settings.Default.telitettCel = (int)telit.Value;

			Properties.Settings.Default.cso1 = (float)cso1.Value;
			Properties.Settings.Default.cso2 = (float)cso2.Value;
			Properties.Settings.Default.cso3 = (float)cso3.Value;
			Properties.Settings.Default.cso4 = (float)cso4.Value;
			Properties.Settings.Default.cso5 = (float)cso5.Value;
			Properties.Settings.Default.cso6 = (float)cso6.Value;
			Properties.Settings.Default.csoegyeb = (float)csoegyeb.Value;

			Properties.Settings.Default.sziv5 = (float)sziv5.Value;
			Properties.Settings.Default.sziv10 = (float)sziv10.Value;
			Properties.Settings.Default.sziv12 = (float)sziv12.Value;
			Properties.Settings.Default.szivegyeb = (float)szivegyeb.Value;

			Properties.Settings.Default.ebedido = (float)ebedido.Value;
			Properties.Settings.Default.speed = (float)speed.Value;
            Properties.Settings.Default.foldutSeb = (float)foldSeb.Value;
			Properties.Settings.Default.kettenUlnekBonus = (float)bonus.Value;

			Properties.Settings.Default.benzinar = (float)benzinar.Value;
			Properties.Settings.Default.costbonus = (float)costbonus.Value;
			Properties.Settings.Default.costbonusactive = costbonusactive.Checked;

			Properties.Settings.Default.workDays = (int)workDays.Value;

			Properties.Settings.Default.kissoforber = (float)kissoforber.Value;
			Properties.Settings.Default.kissoforjar = (float)kissoforjar.Value;
			Properties.Settings.Default.kissegedber = (float)kissegedber.Value;
			Properties.Settings.Default.kissegedjar = (float)kissegedjar.Value;

			Properties.Settings.Default.nagysoforber = (float)nagysoforber.Value;
			Properties.Settings.Default.nagysoforjar = (float)nagysoforjar.Value;
			Properties.Settings.Default.nagysegedber = (float)nagysegedber.Value;
			Properties.Settings.Default.nagysegedjar = (float)nagysegedjar.Value;

            Properties.Settings.Default.nyomtatURL = nyomtatURL.Text;
            Properties.Settings.Default.nyomtatURL2 = nyomtatURL2.Text;

			Properties.Settings.Default.Save();

			Close();
		}

		private void SettingsPanel_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			Help.ShowHelp(this, Application.StartupPath + Properties.Settings.Default.helpPath, HelpNavigator.TopicId, "12");
		}

        private void savePlay_Click(object sender, EventArgs e)
        {
            WavPlayer.PlaySound(saveSndLoc.Text);
        }

        private void fullPlay_Click(object sender, EventArgs e)
        {
            WavPlayer.PlaySound(fullSndLoc.Text);
        }

        private void saveBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.AddExtension = ofd.CheckFileExists = ofd.CheckPathExists = true;
                ofd.Filter = "Wav hangok (*.wav)|*.wav";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    saveSndLoc.Text = ofd.FileName;
                }
            }
        }

        private void fullBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.AddExtension = ofd.CheckFileExists = ofd.CheckPathExists = true;
                ofd.Filter = "Wav hangok (*.wav)|*.wav";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fullSndLoc.Text = ofd.FileName;
                }
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.CheckFileExists = fd.CheckPathExists = true;
                fd.Filter = "Minden fájl|*.*";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    updateURL.Text = string.Format("file://{0}", fd.FileName);

                }
            }
        }

	}
}
