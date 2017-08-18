using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using MySql.Data.MySqlClient;

namespace TurmixLog 
{
    public delegate void EmptyDelegate();

    public class KiosztasDao : TurmixUtils.MySqlDao
    {

        public event EmptyDelegate ExceptionOccured;

        private MySqlCommand updateCar;

        private MySqlCommand allCars;

        private MySqlCommand getRealVolume;

        private MySqlCommand getLatLongData;

        private MySqlCommand insertCar;
        private MySqlCommand deleteCar;

        private MySqlCommand insertLatLng;
        private MySqlCommand updateLatLng;
        private MySqlCommand getCar;

        private MySqlCommand allUtca;

        private MySqlCommand selectProbCim;
        private MySqlCommand selectProbUtca;

        private MySqlCommand selectFold;
        private MySqlCommand updateFold;
        private MySqlCommand insertFold;

        private Regex digit = new Regex("\\d+");

        public override void Init()
        {

            try
            {
                updateCar = new MySqlCommand("UPDATE auto SET kapacitas = ?kapa, koltseg = ?koltseg, lizing = ?lizing WHERE rendszam = ?rendszam;");

                allCars = new MySqlCommand("select * from auto order by rendszam;");

                getRealVolume = new MySqlCommand("select avg(tm3) from tm3 where cim = ?r_cim;");

                getLatLongData = new MySqlCommand("select lat, lng from latlng2 where utca = ?latutca;");

                insertCar = new MySqlCommand("insert into auto (rendszam, kapacitas, lizing, koltseg)" +
                    "values (?rsz, ?kap, ?lizing, ?koltseg);");
                deleteCar = new MySqlCommand("delete from auto where rendszam = ?rsz;");

                insertLatLng = new MySqlCommand("insert into latlng2 (utca, lat, lng) values (?ujutca, ?ujlat, ?ujlng);");
                updateLatLng = new MySqlCommand("update latlng2 set lat = ?uplat, lng = ?uplng where utca = ?uputca;");
                getCar = new MySqlCommand("select kapacitas, koltseg, lizing from auto where rendszam = ?getrsz");

                allUtca = new MySqlCommand("select utca from latlng2 order by utca;");

                selectProbCim = new MySqlCommand("select * from problematic where cim = ?prcim");
                selectProbUtca = new MySqlCommand("select * from problemutca where utca = ?prutca");

                selectFold = new MySqlCommand("select foldlat, foldlng, foldhossz from latlng2 where utca = ?fcim");
                updateFold = new MySqlCommand("update latlng2 set foldlat = ?flat, foldlng = ?flng, foldhossz = ?fhossz where utca = ?fcim");

                updateCar.Connection = connection;
                getLatLongData.Connection = connection;
                getRealVolume.Connection = connection;
                insertCar.Connection = connection;
                deleteCar.Connection = connection;

                insertLatLng.Connection = connection;
                updateLatLng.Connection = connection;

                getCar.Connection = connection;
                allCars.Connection = connection;

                allUtca.Connection = connection;

                selectProbUtca.Connection = connection;
                selectProbCim.Connection = connection;

                selectFold.Connection = connection;
                updateFold.Connection = connection;

                updateCar.Parameters.Add("?kapa", MySqlDbType.UByte, 1, "kapacitas");
                updateCar.Parameters.Add("?koltseg", MySqlDbType.Float, 4, "koltseg");
                updateCar.Parameters.Add("?lizing", MySqlDbType.Float, 4, "lizing");
                updateCar.Parameters.Add("?rendszam", MySqlDbType.VarChar, 10, "rendszam");

                getRealVolume.Parameters.Add("?r_cim", MySqlDbType.VarChar, 255, "cim");

                insertCar.Parameters.Add("?rsz", MySqlDbType.VarChar, 10, "rendszam");
                insertCar.Parameters.Add("?kap", MySqlDbType.UByte, 1, "kapacitas");
                insertCar.Parameters.Add("?lizing", MySqlDbType.Float, 4, "lizing");
                insertCar.Parameters.Add("?koltseg", MySqlDbType.Float, 4, "koltseg");

                getLatLongData.Parameters.Add("?latutca", MySqlDbType.VarChar, 255, "utca");

                deleteCar.Parameters.Add("?rsz", MySqlDbType.VarChar, 10, "rendszam");

                insertLatLng.Parameters.Add("?ujutca", MySqlDbType.VarChar, 255, "utca");
                insertLatLng.Parameters.Add("?ujlat", MySqlDbType.Double, 8, "lat");
                insertLatLng.Parameters.Add("?ujlng", MySqlDbType.Double, 8, "lng");

                updateLatLng.Parameters.Add("?uplat", MySqlDbType.Double, 8, "lat");
                updateLatLng.Parameters.Add("?uplng", MySqlDbType.Double, 8, "lng");
                updateLatLng.Parameters.Add("?uputca", MySqlDbType.VarChar, 255, "utca");

                getCar.Parameters.Add("?getrsz", MySqlDbType.VarChar, 10, "rendszam");

                selectProbCim.Parameters.Add("?prcim", MySqlDbType.VarChar, 255, "cim");
                selectProbUtca.Parameters.Add("?prutca", MySqlDbType.VarChar, 255, "utca");

                selectFold.Parameters.Add("?fcim", MySqlDbType.VarChar, 50, "cim");

                updateFold.Parameters.Add("?flat", MySqlDbType.Double, 8, "foldlat");
                updateFold.Parameters.Add("?flng", MySqlDbType.Double, 8, "foldlang");
                updateFold.Parameters.Add("?fhossz", MySqlDbType.Int32, 4, "foldhossz");
                updateFold.Parameters.Add("?fcim", MySqlDbType.VarChar, 50, "cim");

            }
            catch (Exception e)
            {
                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
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
                    using (SettingsPanel set = new SettingsPanel())
                    {
                        set.tabControl1.SelectedIndex = 1;
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

        public List<WorkData> GetWorkData(DateTime date, out List<Auto> autok, out CimOsszesito osszCim)
        {
            DateTime tempDate;
            object realm3;
            float rm3;

            string auth = "";
            string host;
            string tmpRsz;
            string tmpRow;

            List<WorkData> data = new List<WorkData>();
            WorkData tempData = null;

            Dictionary<string, Auto> autoData = new Dictionary<string, Auto>();

            autok = new List<Auto>();
            osszCim = new CimOsszesito();

            MySqlDataReader latReader = null;
            MySqlDataReader kapReader = null;

            MySqlTransaction trans = null;

            Auto fordAuto;
            int forduloszam;
            int kapacitas;
            int counter = 0;

            if (connection == null)
            {
                Init();
            }

            try
            {
                Auto.AutoIndex = 0;

                

                host = SettingsPanel.UpdateURL;
                bool isSecure = host.StartsWith("https://");
                //if (isSecure)
                {
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    auth = string.Format("{0}:{1}", Properties.Settings.Default.userName, Properties.Settings.Default.password);
                }

                try
                {

                    using (WebClient client = new WebClient(), cl2 = new WebClient())
                    {
                        //if (isSecure)
                        {
                            cl2.Headers.Set("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth)));
                            client.Headers.Set("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth)));
                        }

                        using (StreamReader reader = new StreamReader(cl2.OpenRead(new Uri(string.Format("{0}{1}", Properties.Settings.Default.updateURL2, date.ToString("yyyy-MM"))))))
                        {

                        }
                        using (Stream dataStream = client.OpenRead(host))
                        {
                            

                            using (StreamReader reader = new StreamReader(dataStream, Encoding.UTF7))
                            {

                                while (!reader.EndOfStream)
                                {
                                    tmpRow = reader.ReadLine().Replace('õ', 'ő').Replace('û', 'ű').Replace('Õ', 'Ő').Replace('Û', 'Ű');

                                    string[] parts = tmpRow.Split('\t');

                                    if (parts.Length == 1)
                                    {
                                        if (parts[0].Trim() == "")
                                            continue;
                                        if (tempData != null)
                                        {
                                            tempData.Megjegyzes += " " + parts[0];
                                        }
                                    }
                                    if (parts.Length < 12)
                                    {
                                        continue;
                                    }

                                    try
                                    {
                                        tempDate = DateTime.Parse(parts[4]);
                                    }
                                    catch (FormatException)
                                    {
                                        continue;
                                    }
                                    if (tempDate.Date > date.Date)
                                    {
                                        break;
                                    }
                                    if (tempDate.Date == date.Date)
                                    {

                                        tempData = new WorkData();
                                        tempData.WorksheetNumber = long.Parse(parts[0]);
                                        tempData.Number = counter;
                                        tmpRsz = parts[1];

                                        if (tmpRsz == "")
                                            tmpRsz = "???";
                                        try
                                        {
                                            kapacitas = int.Parse(parts[8]);
                                        }
                                        catch (Exception)
                                        {
                                            kapacitas = 5;
                                        }
                                        if (autoData.ContainsKey(tmpRsz))
                                        {
                                            fordAuto = autoData[tmpRsz];
                                        }
                                        else
                                        {
                                            fordAuto = new Auto(tmpRsz);
                                            getCar.Parameters[0].Value = tmpRsz;

                                            kapReader = getCar.ExecuteReader();
                                            if (kapReader.Read())
                                            {
                                                fordAuto.Kapacitas = kapReader.GetByte(0);
                                                fordAuto.Fogyasztas = kapReader.GetFloat(1);
                                                fordAuto.Lizingdij = kapReader.GetFloat(2);
                                            }
                                            else
                                            {
                                                fordAuto.Kapacitas = kapacitas;
                                            }
                                            kapReader.Close();

                                            fordAuto.Index = Auto.AutoIndex++;

                                            fordAuto.Sofor = parts[2];
                                            fordAuto.Seged = parts[3];

                                            autoData.Add(tmpRsz, fordAuto);
                                        }
                                        try
                                        {
                                            tempData.IranyitoSzam = int.Parse(parts[5]);
                                        }
                                        catch (FormatException)
                                        {
                                        }

                                        tempData.Utca = parts[6];
                                        tempData.HazSzam = parts[7];

                                        try
                                        {
                                            selectProbUtca.Parameters[0].Value = tempData.Utca;
                                            if (selectProbUtca.ExecuteScalar() != null)
                                            {
                                                tempData.Problematic = true;
                                            }
                                            else
                                            {
                                                selectProbCim.Parameters[0].Value = tempData.Cim;
                                                if (selectProbCim.ExecuteScalar() != null)
                                                {
                                                    tempData.Problematic = true;
                                                }
                                            }

                                        }
                                        catch (MySqlException hadit)
                                        {
                                        }

                                        getRealVolume.Parameters[0].Value = tempData.Cim;
                                        realm3 = getRealVolume.ExecuteScalar();

                                        try
                                        {
                                            rm3 = (realm3 == DBNull.Value || realm3 == null) ? 0 : float.Parse(realm3.ToString());
                                        }
                                        catch (FormatException)
                                        {
                                            rm3 = 0;
                                        }

                                        tempData.TenylegesKobmeter = (int)Math.Ceiling(rm3);
                                        tempData.WorkCapacity = kapacitas;

                                        try
                                        {
                                            tempData.Napszak = int.Parse(parts[11]);
                                        }
                                        catch (FormatException)
                                        {

                                        }
                                        if (tempData.Napszak > 3 || tempData.Napszak < 1)
                                        {
                                            using (NapszakCorrector nc = new NapszakCorrector(tempData))
                                            {
                                                nc.ShowDialog();
                                            }
                                        }
                                        try
                                        {
                                            tempData.CsoHossz = int.Parse(parts[9]);
                                        }
                                        catch (FormatException)
                                        {
                                        }
                                        tempData.CsoStr = parts[9];

                                        if (parts.Length >= 14)
                                            tempData.Megjegyzes = parts[13];

                                        

                                        osszCim.UpdateWith(tempData);

                                        /*if (tempData.Jozsai)
                                        {
                                            forduloszam = fordAuto.GetNapszakFordulok(tempData.Napszak - 1);
                                            fordAuto.SetNapszakFordulok(tempData.Napszak - 1, forduloszam + 1);
                                            fordAuto.AddJozsaiFuvar(tempData);
                                        }*/

                                        GetLatLng(tempData, trans);

                                        data.Add(tempData);
                                        counter++;

                                    }
                                }
                            }
                        }
                    }
                    foreach (string s in autoData.Keys)
                    {
                        autok.Add(autoData[s]);
                    }
                }
                catch (WebException se)
                {
                    MessageBox.Show("A program nem tudja az állományt megnyitni.\nEllenőrízze az internetkapcsolatot (vagy az állomány nincs-e más alkalmazással megnyitva) és a Beállítások panelen levő értékeket!",
                        "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

            }
            catch (Exception e)
            {

                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
                data.Clear();
                osszCim = new CimOsszesito();
                if (ExceptionOccured != null)
                    ExceptionOccured();
            }
            finally
            {
                if (latReader != null)
                    latReader.Close();
                if (kapReader != null)
                    kapReader.Close();
            }
            return data;
        }

        public List<WorkData> ReadMassData(string file, out List<Auto> autok, out CimOsszesito[] osszCim)
        {
            
            object realm3;
            float rm3;

            string tmpRow;

            List<WorkData> data = new List<WorkData>();
            WorkData tempData = null;

            Dictionary<string, Auto> autoData = new Dictionary<string, Auto>();

            autok = new List<Auto>();
            autok.Add(new Auto("TMX-000"));
            autok.Add(new Auto("TRZ-000"));
            osszCim = new CimOsszesito[2];         

            MySqlDataReader latReader = null;
            MySqlDataReader kapReader = null;

            MySqlTransaction trans = null;

            int kapacitas;
            int counter = 0;

            if (connection == null)
            {
                Init();
            }

            try
            {

                try
                {

                    using (StreamReader reader = new StreamReader(file, Encoding.UTF7))
                    {


                        while (!reader.EndOfStream)
                        {
                            tmpRow = reader.ReadLine().Replace('õ', 'ő').Replace('û', 'ű').Replace('Õ', 'Ő').Replace('Û', 'Ű');

                            string[] parts = tmpRow.Split('\t');

                            if (parts.Length == 1)
                            {
                                if (parts[0].Trim() == "")
                                    continue;
                                if (tempData != null)
                                {
                                    tempData.Megjegyzes += " " + parts[0];
                                }
                            }
                            if (parts.Length < 14)
                            {
                                continue;
                            }

                            tempData = new WorkData();
                            tempData.WorksheetNumber = long.Parse(parts[0]);
                            tempData.Number = counter;

                            try
                            {
                                tempData.IranyitoSzam = int.Parse(parts[5]);
                            }
                            catch (FormatException)
                            {
                            }

                            tempData.Utca = parts[6];
                            tempData.HazSzam = parts[7];

                            try
                            {
                                selectProbUtca.Parameters[0].Value = tempData.Utca;
                                if (selectProbUtca.ExecuteScalar() != null)
                                {
                                    tempData.Problematic = true;
                                }
                                else
                                {
                                    selectProbCim.Parameters[0].Value = tempData.Cim;
                                    if (selectProbCim.ExecuteScalar() != null)
                                    {
                                        tempData.Problematic = true;
                                    }
                                }

                            }
                            catch (MySqlException hadit)
                            {
                            }

                            getRealVolume.Parameters[0].Value = tempData.Cim;
                            realm3 = getRealVolume.ExecuteScalar();

                            try
                            {
                                rm3 = (realm3 == DBNull.Value || realm3 == null) ? 0 : float.Parse(realm3.ToString());
                            }
                            catch (FormatException)
                            {
                                rm3 = 0;
                            }

                            tempData.TenylegesKobmeter = (int)Math.Ceiling(rm3);
                            try
                            {
                                tempData.WorkCapacity = int.Parse(parts[8]);
                            }
                            catch (Exception)
                            {
                                tempData.WorkCapacity = 5;
                            }

                            try
                            {
                                tempData.Napszak = int.Parse(parts[11]);
                            }
                            catch (FormatException)
                            {

                            }
                            if (tempData.Napszak > 3 || tempData.Napszak < 1)
                            {
                                using (NapszakCorrector nc = new NapszakCorrector(tempData))
                                {
                                    nc.ShowDialog();
                                }
                            }
                            try
                            {
                                tempData.CsoHossz = int.Parse(parts[9]);
                            }
                            catch (FormatException)
                            {
                            }
                            tempData.CsoStr = parts[9];

                            tempData.Megjegyzes = parts[13];

                            tempData.Szolgaltato = parts[10];

                            if (tempData.IsTranzit)
                            {
                                osszCim[1].UpdateWith(tempData);
                            }
                            else
                            {
                                osszCim[0].UpdateWith(tempData);
                            }

                            /*if (tempData.Jozsai)
                            {
                                forduloszam = fordAuto.GetNapszakFordulok(tempData.Napszak - 1);
                                fordAuto.SetNapszakFordulok(tempData.Napszak - 1, forduloszam + 1);
                                fordAuto.AddJozsaiFuvar(tempData);
                            }*/

                            GetLatLng(tempData, trans);

                            data.Add(tempData);
                            counter++;

                        }
                    }
                }              
                catch (MySqlException ex)
                {
                    MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

            }
            catch (Exception e)
            {

                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
                data.Clear();
                osszCim = new CimOsszesito[2];
                if (ExceptionOccured != null)
                    ExceptionOccured();
            }
            finally
            {
                if (latReader != null)
                    latReader.Close();
                if (kapReader != null)
                    kapReader.Close();
            }
            return data;
        }

        public void GetLatLng(WorkData tempData, MySqlTransaction tr)
        {
            MySqlDataReader latReader = null;

            if (connection == null)
            {
                Init();
            }

            try
            {

                if (tr != null)
                {
                    getLatLongData.Transaction = tr;
                }

                getLatLongData.Parameters[0].Value = tempData.Utca;


                latReader = getLatLongData.ExecuteReader();
                if (latReader.Read())
                {

                    tempData.Lat = latReader.GetDouble(0);

                    tempData.Lng = latReader.GetDouble(1);
                }
            }
            catch (MySqlException ole)
            {

            }
            finally
            {
                if (latReader != null && !latReader.IsClosed)
                    latReader.Close();
            }
        }

        public GLatLng GetLatLng(string utca)
        {
            GLatLng ret = new GLatLng();
            MySqlDataReader latReader = null;

            if (connection == null)
            {
                Init();
            }

            try
            {

                getLatLongData.Parameters[0].Value = utca;

                latReader = getLatLongData.ExecuteReader();
                if (latReader.Read())
                {

                    ret.Lat = latReader.GetDouble(0);
                    ret.Lng = latReader.GetDouble(1);
                }
            }
            catch (MySqlException ole)
            {

            }
            finally
            {
                if (latReader != null && !latReader.IsClosed)
                    latReader.Close();
            }
            return ret;
        }

        public bool GetLatLngProb(WorkData tempData)
        {
            bool success = false;
            MySqlDataReader latReader = null;

            if (connection == null)
            {
                Init();
            }

            try
            {
                selectProbCim.Parameters[0].Value = tempData.Cim;
                tempData.Problematic = selectProbCim.ExecuteScalar() != null;

                getLatLongData.Parameters[0].Value = tempData.Utca;

                latReader = getLatLongData.ExecuteReader();
                if (latReader.Read() && tempData.Lat == 0 && tempData.Lng == 0)
                {

                    tempData.Lat = latReader.GetDouble(0);

                    tempData.Lng = latReader.GetDouble(1);
                    success = true;
                }
            }
            catch (MySqlException ole)
            {

            }
            finally
            {
                if (latReader != null && !latReader.IsClosed)
                    latReader.Close();
            }
            return success;
        }

        public List<Auto> GetCars()
        {

            MySqlTransaction trans = null;
            MySqlDataReader kapReader = null;
            List<Auto> ret = new List<Auto>();
            Auto tmp;

            try
            {
                if (connection == null)
                {
                    Init();
                }

                kapReader = allCars.ExecuteReader();
                while (kapReader.Read())
                {
                    tmp = new Auto(kapReader.GetString(0));

                    tmp.Kapacitas = kapReader.GetByte(1);
                    tmp.Fogyasztas = kapReader.GetFloat(3);
                    tmp.Lizingdij = kapReader.GetFloat(2);

                    ret.Add(tmp);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppLogger.WriteException(ex);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            catch (InvalidOperationException inv)
            {

            }
            catch (Exception e)
            {

                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            finally
            {

                if (kapReader != null)
                    kapReader.Close();
                trans = null;


            }

            return ret;
        }

        public List<string> GetUtcak()
        {

            MySqlTransaction trans = null;
            MySqlDataReader kapReader = null;
            List<string> ret = new List<string>();

            try
            {
                if (connection == null)
                {
                    Init();
                }

                kapReader = allUtca.ExecuteReader();

                while (kapReader.Read())
                {
                    ret.Add(kapReader.GetString(0));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppLogger.WriteException(ex);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            catch (InvalidOperationException inv)
            {

            }
            catch (Exception e)
            {

                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            finally
            {

                if (kapReader != null)
                    kapReader.Close();
                trans = null;


            }

            return ret;
        }

        

        public void GetFoldLatLng(List<WorkData> data)
        {

            MySqlDataReader kapReader = null;

            try
            {
                if (connection == null)
                {
                    Init();
                }

                foreach (WorkData wd in data)
                {
                    selectFold.Parameters[0].Value = wd.Utca;
                    kapReader = selectFold.ExecuteReader();
                    
                    if (kapReader.Read())
                    {
                        wd.FoldLat = kapReader.GetDouble(0);
                        wd.FoldLng = kapReader.GetDouble(1);
                        wd.FoldHossz = kapReader.GetInt32(2);
                    }
                    kapReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppLogger.WriteException(ex);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            catch (Exception e)
            {

                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            finally
            {

                if (kapReader != null)
                    kapReader.Close();

            }
        }

        public void GetLatLng(List<WorkData> data)
        {

            MySqlDataReader kapReader = null;

            try
            {
                if (connection == null)
                {
                    Init();
                }

                foreach (WorkData wd in data)
                {
                    getLatLongData.Parameters[0].Value = wd.Utca;
                    kapReader = getLatLongData.ExecuteReader();

                    if (kapReader.Read())
                    {
                        wd.Lat = kapReader.GetDouble(0);
                        wd.Lng = kapReader.GetDouble(1);
                    }
                    kapReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppLogger.WriteException(ex);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            catch (Exception e)
            {

                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            finally
            {

                if (kapReader != null)
                    kapReader.Close();

            }
        }

        public void GetAutoAdat(List<Auto> data)
        {

            MySqlDataReader kapReader = null;

            try
            {
                if (connection == null)
                {
                    Init();
                }

                foreach (Auto au in data)
                {
                    getCar.Parameters[0].Value = au.Rendszam;
                    kapReader = getLatLongData.ExecuteReader();

                    if (kapReader.Read())
                    {
                        au.Kapacitas = kapReader.GetByte(0);
                        au.Fogyasztas = kapReader.GetFloat(1);
                        au.Lizingdij = kapReader.GetFloat(2);
                    }
                    kapReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppLogger.WriteException(ex);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            catch (Exception e)
            {

                AppLogger.WriteException(e);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            finally
            {

                if (kapReader != null)
                    kapReader.Close();

            }
        }

        public void UpdateKoltseg(List<Auto> cars)
        {

            MySqlTransaction trans = null;

            if (connection == null)
            {
                Init();
            }

            try
            {

                trans = connection.BeginTransaction();
                updateCar.Transaction = trans;

                foreach (Auto a in cars)
                {
                    updateCar.Parameters[0].Value = a.Kapacitas;
                    updateCar.Parameters[1].Value = a.Fogyasztas;
                    updateCar.Parameters[2].Value = a.Lizingdij;
                    updateCar.Parameters[3].Value = a.Rendszam;

                    updateCar.ExecuteNonQuery();
                }
                trans.Commit();

            }
            catch (MySqlException ole)
            {
                MessageBox.Show("Az adatbázis frissítése nem sikerült.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trans.Rollback();

                AppLogger.WriteException(ole);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            catch (Exception ex)
            {
                AppLogger.WriteException(ex);
                AppLogger.WriteEvent("A kivétel elkapva.");
            }
            finally
            {
                trans = null;

            }
        }

        public void InsertCar(Auto auto)
        {
            if (connection == null)
            {
                Init();
            }

            try
            {

                insertCar.Parameters[0].Value = auto.Rendszam;
                insertCar.Parameters[1].Value = auto.Kapacitas;
                insertCar.Parameters[2].Value = auto.Lizingdij;
                insertCar.Parameters[3].Value = auto.Fogyasztas;

                insertCar.ExecuteNonQuery();

            }
            catch (MySqlException ole)
            {
                if (ole.Number == 1062)
                {
                    //Az autó már megvolt.
                }
                else
                {
                    MessageBox.Show("A költségek frissítése nem sikerült.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppLogger.WriteException(ole);
                    AppLogger.WriteEvent("A kivétel elkapva.");
                }
            }
        }

        public void DeleteCar(ListBox.SelectedObjectCollection rendsz)
        {

            MySqlTransaction trans = null;

            if (connection == null)
            {
                Init();
            }

            try
            {


                trans = connection.BeginTransaction();
                deleteCar.Transaction = trans;

                foreach (string rsz in rendsz)
                {
                    deleteCar.Parameters[0].Value = rsz;
                    deleteCar.ExecuteNonQuery();
                }

                trans.Commit();

            }
            catch (MySqlException)
            {

                trans.Rollback();
                MessageBox.Show("Az adatbázis frissítése nem sikerült.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                trans = null;

            }
        }

        public void InsertLatLng(WorkData wd)
        {
            int res = 0;
            if (connection == null)
            {
                Init();
            }

            try
            {
                insertLatLng.Parameters[0].Value = wd.Utca;
                insertLatLng.Parameters[1].Value = wd.Lat;
                insertLatLng.Parameters[2].Value = wd.Lng;

                res = insertLatLng.ExecuteNonQuery();
            }
            catch (MySqlException ole)
            {
                if (ole.Number == 1062)
                {
                    if (MessageBox.Show("A bejegyzés már szerepel: " + wd.Utca + "\nKívánja felülírni a koordinátákat?",
                    "Létező bejegyzés", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        try
                        {
                            updateLatLng.Parameters[0].Value = wd.Lat;
                            updateLatLng.Parameters[1].Value = wd.Lng;
                            updateLatLng.Parameters[2].Value = wd.Utca;

                            res = updateLatLng.ExecuteNonQuery();
                        }
                        catch (MySqlException ole2)
                        {
                            AppLogger.WriteException(ole2);
                            AppLogger.WriteEvent("A kivétel elkapva.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppLogger.WriteException(ole);
                    AppLogger.WriteEvent("A kivétel elkapva.");
                }
            }
            /*if (res == 1)
            {
                MessageBox.Show("Az adatbázisban a következő bejegyzés módosult:\nUtca: " + wd.Utca +
                    "\nSzélesség: " + wd.Lat + "\nHosszúság: " + wd.Lng, "Sikeres frissítés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        public void InsertLatLng(string utca, double lat, double lng)
        {
            int res = 0;
            if (connection == null)
            {
                Init();
            }

            try
            {
                insertLatLng.Parameters[0].Value = utca;
                insertLatLng.Parameters[1].Value = lat;
                insertLatLng.Parameters[2].Value = lng;

                res = insertLatLng.ExecuteNonQuery();
            }
            catch (MySqlException ole)
            {
                if (ole.Number == 1062)
                {
                    if (MessageBox.Show("A bejegyzés már szerepel: " + utca + "\nKívánja felülírni a koordinátákat?",
                    "Létező bejegyzés", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        try
                        {
                            updateLatLng.Parameters[0].Value = lat;
                            updateLatLng.Parameters[1].Value = lng;
                            updateLatLng.Parameters[2].Value = utca;

                            res = updateLatLng.ExecuteNonQuery();
                        }
                        catch (MySqlException ole2)
                        {
                            AppLogger.WriteException(ole2);
                            AppLogger.WriteEvent("A kivétel elkapva.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppLogger.WriteException(ole);
                    AppLogger.WriteEvent("A kivétel elkapva.");
                }
            }
            if (res == 1)
            {
                MessageBox.Show("Az adatbázisban a következő bejegyzés módosult:\nUtca: " + utca +
                    "\nSzélesség: " + lat + "\nHosszúság: " + lng, "Sikeres frissítés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UpdateFoldRow(string utca, double lat, double lng, int hossz)
        {
            if (connection == null)
            {
                Init();
            }

            try
            {

                updateFold.Parameters[0].Value = lat;
                updateFold.Parameters[1].Value = lng;
                updateFold.Parameters[2].Value = hossz;
                updateFold.Parameters[3].Value = utca;

                updateFold.ExecuteNonQuery();


            }
            catch (MySqlException ole)
            {
                
                MessageBox.Show("A földút-adatok frissítése nem sikerült.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppLogger.WriteException(ole);
                AppLogger.WriteEvent("A kivétel elkapva.");

            }
        }

    }



    public class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(
        ServicePoint srvPoint
        , System.Security.Cryptography.X509Certificates.X509Certificate certificate
        , WebRequest request
        , int certificateProblem)
        {

            //Return True to force the certificate to be accepted.
            return true;

        } // end CheckValidationResult
    }
}
