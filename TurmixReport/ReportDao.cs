using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace TurmixReport
{
    public class ReportDao : TurmixUtils.MySqlDao
    {

        public string ConnectionString
        {
            get
            {
                return connection.ConnectionString;
            }
        }

        public override void Init()
        {
            
        }

        protected override void GetConnection()
        {
            try
            {
                connection = new MySqlConnection(string.Format("server={0};database={1};uid={2};password={3}",
                    Properties.Settings.Default.dbHost, Properties.Settings.Default.dbName,
                    Properties.Settings.Default.dbUser, Properties.Settings.Default.dbPass));
                connection.Open();
            }

            catch (MySqlException ole)
            {
                DialogResult dr = DialogResult.No;
                switch (ole.Number)
                {
                    case 1042:
                        dr = MessageBox.Show(string.Format("A megadott adatbázis szerver ({0}) nem elérhető.\nLehet, hogy hibásan adta meg a szerver nevét.\nKívánja módosítani a beállításokat?",
                            Properties.Settings.Default.dbHost), "Hiba", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        break;
                    case 1044:
                        dr = MessageBox.Show(string.Format("A megadott adatbázis név ({0}) hibás.\nLehet, hogy hibásan adta meg a nevet.\nKívánja módosítani a beállításokat?",
                            Properties.Settings.Default.dbName), "Hiba", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        break;
                    case 1045:
                        dr = MessageBox.Show("A megadott adatbázis felhasználó vagy jelszó hibás.\nKívánja módosítani a beállításokat?",
                            "Hiba", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        break;
                    default:
                        throw;
                }
                if (dr == DialogResult.Yes)
                {
                    using (SetterPanel set = new SetterPanel())
                    {
                        if (set.ShowDialog() == DialogResult.OK)
                        {
                            GetConnection();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Az adatbázis elérésekor a következő hiba történt:\n{0}", e.Message), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
