using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurmixLog;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TurmixBatch
{
    public class TenykobDao : TurmixUtils.MySqlDao
    {

        private MySqlCommand insertKobmeter;
        private MySqlCommand updateKobmeter;

        private string connectionString;

        public override void Init()
        {

            insertKobmeter = new MySqlCommand(@"insert into tm3 values (
                ?fhkod, ?vonalkod, ?szamla, ?szamlaossz, ?tm3, ?terulet, ?tamogatas, ?ceg, 
                ?datum, ?alapdij, ?alapkezdet, ?alapveg, ?megtak, ?sofor, ?rendszam)
            ;");

            insertKobmeter.Parameters.Add("?fhkod", MySqlDbType.VarChar, 10, "fhkod");
            insertKobmeter.Parameters.Add("?vonalkod", MySqlDbType.VarChar, 20, "vonalkod");
            insertKobmeter.Parameters.Add("?szamla", MySqlDbType.VarChar, 20, "szamla");
            insertKobmeter.Parameters.Add("?szamlaossz", MySqlDbType.Int32, 4, "szamla_osszege");
            insertKobmeter.Parameters.Add("?tm3", MySqlDbType.Int16, 2, "mennyiseg");
            insertKobmeter.Parameters.Add("?terulet", MySqlDbType.VarChar, 100, "terulet");
            insertKobmeter.Parameters.Add("?tamogatas", MySqlDbType.VarChar, 20, "tamogatas");
            insertKobmeter.Parameters.Add("?ceg", MySqlDbType.VarChar, 20, "ceg");
            insertKobmeter.Parameters.Add("?datum", MySqlDbType.VarChar, 20, "datum");
            insertKobmeter.Parameters.Add("?alapdij", MySqlDbType.Int32, 4, "alapdij");
            insertKobmeter.Parameters.Add("?alapkezdet", MySqlDbType.VarChar, 20, "alapdij_kezdet");
            insertKobmeter.Parameters.Add("?alapveg", MySqlDbType.VarChar, 20, "alapdij_veg");
            insertKobmeter.Parameters.Add("?megtak", MySqlDbType.VarChar, 20, "megtakaritas");
            insertKobmeter.Parameters.Add("?sofor", MySqlDbType.VarChar, 100, "sofor");
            insertKobmeter.Parameters.Add("?rendszam", MySqlDbType.VarChar, 20, "rendszam");

            insertKobmeter.Connection = connection;
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

        public void UpdateKobmeter(List<TenykobRecord> list)
        {
            MySqlTransaction trans = null;
            try
            {

                trans = connection.BeginTransaction();
                insertKobmeter.Transaction = trans;
                foreach (TenykobRecord wd in list)
                {
                    insertKobmeter.Parameters[0].Value = wd.FhKod;
                    insertKobmeter.Parameters[2].Value = wd.Szamla;
                    insertKobmeter.Parameters[1].Value = wd.Vonalkod;
                    insertKobmeter.Parameters[3].Value = wd.SzamlaOsszeg;
                    insertKobmeter.Parameters[4].Value = wd.Mennyiseg;
                    insertKobmeter.Parameters[5].Value = wd.Terulet;
                    insertKobmeter.Parameters[6].Value = wd.Tamogatas;
                    insertKobmeter.Parameters[7].Value = wd.Ceg;
                    insertKobmeter.Parameters[8].Value = wd.Datum;
                    insertKobmeter.Parameters[9].Value = wd.Alapdij;
                    insertKobmeter.Parameters[10].Value = wd.AlapdijKezdet;
                    insertKobmeter.Parameters[11].Value = wd.AlapdijVeg;
                    insertKobmeter.Parameters[12].Value = wd.Megtakaritas;
                    insertKobmeter.Parameters[13].Value = wd.Sofor;
                    insertKobmeter.Parameters[14].Value = wd.Rendszam;


                    try
                    {
                        insertKobmeter.ExecuteNonQuery();
                    }
                    catch (MySqlException ins)
                    {
                        if (ins.Number == 1062)
                        {
                            //már megvolt.
                            /*updateKobmeter.Parameters[1].Value = wd.Cim;
                            updateKobmeter.Parameters[0].Value = wd.TenylegesKobmeter;
                            updateKobmeter.Parameters[2].Value = date;

                            updateKobmeter.ExecuteNonQuery(); */
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                trans.Commit();
            }
            catch (Exception ole)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }

                MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        

    }


}
