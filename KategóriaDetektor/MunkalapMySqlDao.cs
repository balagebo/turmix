using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KategóriaDetektor
{
    public class MunkalapMySqlDao : TurmixUtils.MySqlDao
    {

        private MySqlCommand insertNet;
        private MySqlCommand updateNet;

        private MySqlCommand insertXls;
        private MySqlCommand updateXls;
    
        public override void Init()
        {

            insertNet = new MySqlCommand("insert into fkodok (fkod, net, irsz, helyseg, utca, hsz) values (?fkod, ?net, ?irsz, ?helyseg, "+
                "?utca, ?hsz)");
            updateNet = new MySqlCommand("update fkodok set net = ?net, irsz = ?irsz, helyseg = ?helyseg, utca = ?utca, hsz = ?hsz where fkod = ?fkod");

            insertXls = new MySqlCommand("insert into fkodxls values (?utca, ?kat)");
            updateXls = new MySqlCommand("update fkodxls set kat = ?kat where utca = ?utca");

            insertNet.Connection = updateNet.Connection = updateXls.Connection = insertXls.Connection = connection;

            insertNet.Parameters.Add("?fkod", MySqlDbType.VarChar, 6, "fkod");
            insertNet.Parameters.Add("?net", MySqlDbType.UByte, 1, "net");
            insertNet.Parameters.Add("?irsz", MySqlDbType.UInt16, 2, "irsz");
            insertNet.Parameters.Add("?helyseg", MySqlDbType.VarChar, 30, "helyseg");
            insertNet.Parameters.Add("?utca", MySqlDbType.VarChar, 30, "utca");
            insertNet.Parameters.Add("?hsz", MySqlDbType.VarChar, 15, "hsz");

            updateNet.Parameters.Add("?net", MySqlDbType.UByte, 1, "net");
            updateNet.Parameters.Add("?irsz", MySqlDbType.UInt16, 2, "irsz");
            updateNet.Parameters.Add("?helyseg", MySqlDbType.VarChar, 30, "helyseg");
            updateNet.Parameters.Add("?utca", MySqlDbType.VarChar, 30, "utca");
            updateNet.Parameters.Add("?hsz", MySqlDbType.VarChar, 15, "hsz");
            updateNet.Parameters.Add("?fkod", MySqlDbType.VarChar, 6, "fkod");

            insertXls.Parameters.Add("?utca", MySqlDbType.VarChar, 30, "utca");
            insertXls.Parameters.Add("?kat", MySqlDbType.UByte, 1, "kat");

            updateXls.Parameters.Add("?kat", MySqlDbType.UByte, 1, "kat");
            updateXls.Parameters.Add("?utca", MySqlDbType.VarChar, 30, "utca");
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
                AppLogger.WriteException(e);
            }
        }

        public void InsertOrUpdateNet(Entity et, InsertInfo info)
        {

            try
            {

                insertNet.Parameters[0].Value = et.Fkod;
                insertNet.Parameters[1].Value = et.Kategoria;
                insertNet.Parameters[2].Value = et.IranyitoSzam;
                insertNet.Parameters[3].Value = et.Helyseg;
                insertNet.Parameters[4].Value = et.Utca;
                insertNet.Parameters[5].Value = et.HazSzam;

                try
                {
                    insertNet.ExecuteNonQuery();
                    info.InsertCount++;
                }
                catch (MySqlException ins)
                {
                    if (ins.Number == 1062)
                    {
                        //már megvolt.

                        
                        updateNet.Parameters[0].Value = et.Kategoria;
                        updateNet.Parameters[1].Value = et.IranyitoSzam;
                        updateNet.Parameters[2].Value = et.Helyseg;
                        updateNet.Parameters[3].Value = et.Utca;
                        updateNet.Parameters[4].Value = et.HazSzam;
                        updateNet.Parameters[5].Value = et.Fkod;

                        updateNet.ExecuteNonQuery();
                        info.UpdateCount++;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.WriteException(ex, et.Fkod);
            }
        }

        internal void InsertOrUpdateXls(Entity wd, InsertInfo info)
        {
            try
            {
                insertXls.Parameters[0].Value = wd.Utca;
                insertXls.Parameters[1].Value = wd.Kategoria;
                
                insertXls.ExecuteNonQuery();
                info.InsertCount++;
            }
            catch (MySqlException me)
            {
                if (me.Number == 1062)
                {

                    updateXls.Parameters[0].Value = wd.Kategoria;
                    updateXls.Parameters[1].Value = wd.Fkod;

                    updateXls.ExecuteNonQuery();
                    info.UpdateCount++;

                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                AppLogger.WriteException(ex, wd.Fkod);
            }
        }
    }
}
