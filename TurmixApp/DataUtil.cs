using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace TurmixLog
{
	public delegate void EmptyDelegate();

	public class KiosztasDao : TurmixUtils.OleDao
	{

		public  event EmptyDelegate ExceptionOccured;

		private  OleDbCommand updateCar = new OleDbCommand("UPDATE Auto SET Kapacitas = ?, Koltseg = ?, Lizing = ? WHERE Rendszam = ?;");

		private  OleDbCommand allCars = new OleDbCommand("select * from Auto;");

		private  OleDbCommand getRealVolume = new OleDbCommand("select avg(Tm3) from Tm3 where Cim = ?;");
        private  OleDbCommand insertKobmeter = new OleDbCommand("insert into Tm3 values (?, ?, ?);");
        private  OleDbCommand updateKobmeter = new OleDbCommand("update Tm3 set Tm3 = ? where Cim = ? and Datum = ?;");

		private  OleDbCommand getLatLongData = new OleDbCommand("select Lat, Lng from latlng2 where Utca = ?;");

		private  OleDbCommand insertCar = new OleDbCommand("insert into Auto (Rendszam, Kapacitas, Lizing, Koltseg)" +
			"values (?, ?, ?, ?);");
		private  OleDbCommand deleteCar = new OleDbCommand("delete from Auto where Rendszam = ?;");

		private  OleDbCommand insertLatLng = new OleDbCommand("insert into latlng2 " +
			"values (?, ?, ?);");
        private  OleDbCommand updateLatLng = new OleDbCommand("update latlng2 " +
            "set Lat = ?, Lng = ? where Utca = ?;");
		private  OleDbCommand getCar = new OleDbCommand("select Kapacitas, Koltseg, Lizing from Auto where Rendszam = ?");

		private  OleDbCommand allUtca = new OleDbCommand("select distinct Utca from latlng2 order by Utca;");


		private  OleDbCommand selectProbCim = new OleDbCommand("select * from Problematic where Cim = ?");
		private  OleDbCommand selectProbUtca = new OleDbCommand("select * from ProblemUtca where Utca = ?");

		private  Regex digit = new Regex("\\d+");

		private System.Globalization.CultureInfo cultInfo = System.Globalization.CultureInfo.CreateSpecificCulture("HU-hu");

		private string connectionString;

		public override void Init()
		{

			try
			{

				cultInfo.DateTimeFormat.DateSeparator = "-";
				cultInfo.NumberFormat.NumberDecimalSeparator = ".";
				cultInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
               
				updateCar.Connection = connection;
				getLatLongData.Connection = connection;
				getRealVolume.Connection = connection;
				insertCar.Connection = connection;
				deleteCar.Connection = connection;

                insertKobmeter.Connection = updateKobmeter.Connection = connection;

				insertLatLng.Connection = connection;
                updateLatLng.Connection = connection;

				getCar.Connection = connection;
				allCars.Connection = connection;

				allUtca.Connection = connection;

				selectProbUtca.Connection = connection;
				selectProbCim.Connection = connection;

				updateCar.Parameters.Add("@kapa", OleDbType.UnsignedTinyInt, 1, "Kapacitas");
				updateCar.Parameters.Add("@koltseg", OleDbType.Integer, 4, "Koltseg");
				updateCar.Parameters.Add("@lizing", OleDbType.Integer, 4, "Lizing");
				updateCar.Parameters.Add("@rendszam", OleDbType.VarChar, 10, "Rendszam");

				getRealVolume.Parameters.Add("@r_cim", OleDbType.VarChar, 255, "Cim");

				insertCar.Parameters.Add("@rsz", OleDbType.VarChar, 10, "Rendszam");
				insertCar.Parameters.Add("@kap", OleDbType.UnsignedTinyInt, 1, "Kapacitas");
				insertCar.Parameters.Add("@ilizing", OleDbType.Single, 4, "Lizing");
				insertCar.Parameters.Add("@ikoltseg", OleDbType.Single, 4, "Koltseg");
				
				getLatLongData.Parameters.Add("@latutca", OleDbType.VarChar, 255, "Utca");

				deleteCar.Parameters.Add("@rsz", OleDbType.VarChar, 10, "Rendszam");

				insertLatLng.Parameters.Add("@ujutca", OleDbType.VarChar, 255, "Utca");
				insertLatLng.Parameters.Add("@ujlat", OleDbType.Double, 8, "Lat");
				insertLatLng.Parameters.Add("@ujlng", OleDbType.Double, 8, "Lng");
                
                updateLatLng.Parameters.Add("@uplat", OleDbType.Double, 8, "Lat");
                updateLatLng.Parameters.Add("@uplng", OleDbType.Double, 8, "Lng");
                updateLatLng.Parameters.Add("@uputca", OleDbType.VarChar, 255, "Utca");

				getCar.Parameters.Add("@getrsz", OleDbType.VarChar, 10, "Rendszam");

				selectProbCim.Parameters.Add("@prcim", OleDbType.VarChar, 255, "Cim");
				selectProbUtca.Parameters.Add("@prutca", OleDbType.VarChar, 255, "Utca");

                insertKobmeter.Parameters.Add("@tmi_cim", OleDbType.VarChar, 255, "Cim");
                insertKobmeter.Parameters.Add("@tmi_tm3", OleDbType.UnsignedSmallInt, 2, "Tm3");
                insertKobmeter.Parameters.Add("@tmi_dat", OleDbType.DBDate, 16, "Datum");

                updateKobmeter.Parameters.Add("@tmu_tm3", OleDbType.UnsignedSmallInt, 2, "Tm3");
                updateKobmeter.Parameters.Add("@tmu_cim", OleDbType.VarChar, 255, "Cim");
                updateKobmeter.Parameters.Add("@tmu_dat", OleDbType.DBDate, 16, "Datum");
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
                string cstr = TurmixLog.Properties.Settings.Default.dbHost;
                connectionString = cstr == null ? "\\\\spc-001\\halozati munka_net\\vir\\data.mde" : cstr;

                connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + connectionString);
                connection.Open();
            }
            catch (OleDbException ole)
            {
                if (ole.Errors.Count > 0 && ole.Errors[0].SQLState == "3044" || ole.Errors[0].SQLState == "3024")
                {
                    string message = string.Format("Az adatbázis: {0} inicializálása sikertelen.\nSzeretné az adatbázis helyét megadni?",
                    connectionString);
                    if (MessageBox.Show(message, "Hiba", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        using (OpenFileDialog ofd = new OpenFileDialog())
                        {
                            ofd.AddExtension = ofd.CheckFileExists = ofd.CheckPathExists = true;
                            ofd.Filter = "MDE adabázis|*.mde";


                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                connectionString = TurmixLog.Properties.Settings.Default.dbHost = ofd.FileName;
                                TurmixLog.Properties.Settings.Default.Save();
                                GetConnection();
                            }
                            else
                            {
                                MessageBox.Show("Az adatbázis nem érhető el.\nA nem mentett adatok elvesznek.",
                                    "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }
                else
                {
                    throw;
                }

            }
        }

		public  List<WorkData> GetWorkData(DateTime date, out List<Auto> autok, out CimOsszesito osszCim)
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

			OleDbDataReader latReader = null;
			OleDbDataReader kapReader = null;

			OleDbTransaction trans = null;

			Auto fordAuto;
			int forduloszam;
			int kapacitas;
			int counter = 0;

			if (connection == null)
			{
				GetConnection();
			}

			try
			{
				Auto.AutoIndex = 0;
				
				System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

				//if (Properties.Settings.Default.userName != "" && Properties.Settings.Default.password != "")
				{
					auth = string.Format("{0}:{1}", Properties.Settings.Default.userName, Properties.Settings.Default.password);
				}
				host = string.Format("{0}{1}&ok=OK", Properties.Settings.Default.updateURL, date.ToString("yyyy-MM"));

				try
				{
					
					using (WebClient client = new WebClient(), cl2 = new WebClient())
					{
						cl2.Headers.Set("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth)));
						client.Headers.Set("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth)));

						using (StreamReader reader = new StreamReader(cl2.OpenRead(new Uri(string.Format("https://213.178.99.161/new/letoltes.php?honap={0}&ok=OK", date.ToString("yyyy-MM"))))))
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
									if (parts.Length != 14)
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
										catch (OleDbException hadit)
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
					MessageBox.Show("A program nem tudott kapcsolatba lépni a távoli géppel.\nEllenőrízze az internetkapcsolatot és a Beállítások panelen levő értékeket!",
						"Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
					throw;
				}
				catch (OleDbException ex)
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

		public  void GetLatLng(WorkData tempData, OleDbTransaction tr)
		{
			OleDbDataReader latReader = null;

			if (connection == null)
			{
				GetConnection();
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
			catch (OleDbException ole)
			{

			}
			finally
			{
				if (latReader != null && !latReader.IsClosed)
					latReader.Close();
			}
		}

        public  bool GetLatLngProb(WorkData tempData)
        {
            bool success = false;
            OleDbDataReader latReader = null;

            if (connection == null)
            {
                GetConnection();
            }

            try
            {
                selectProbCim.Parameters[0].Value = tempData.Cim;
                tempData.Problematic = selectProbCim.ExecuteScalar() != null;

                getLatLongData.Parameters[0].Value = tempData.Utca;

                latReader = getLatLongData.ExecuteReader();
                if (latReader.Read())
                {

                    tempData.Lat = latReader.GetDouble(0);

                    tempData.Lng = latReader.GetDouble(1);
                    success = true;
                }
            }
            catch (OleDbException ole)
            {

            }
            finally
            {
                if (latReader != null && !latReader.IsClosed)
                    latReader.Close();
            }
            return success;
        }

		public  List<Auto> GetCars()
		{

			OleDbTransaction trans = null;
			OleDbDataReader kapReader = null;
			List<Auto> ret = new List<Auto>();
			Auto tmp;

			try
			{
				if (connection == null)
				{
					GetConnection();
				}



				trans = connection.BeginTransaction();
				allCars.Transaction = trans;

				kapReader = allCars.ExecuteReader();
				while (kapReader.Read())
				{
					tmp = new Auto(kapReader.GetString(0));

					tmp.Kapacitas = kapReader.GetByte(1);
					tmp.Fogyasztas = kapReader.GetFloat(3);
					tmp.Lizingdij = kapReader.GetFloat(2);

					ret.Add(tmp);
				}

				trans.Commit();
			}
			catch (OleDbException ex)
			{
				MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
				trans.Rollback();
			}
			catch (InvalidOperationException inv)
			{

			}
			catch (Exception e)
			{

				AppLogger.WriteException(e);
				AppLogger.WriteEvent("A kivétel elkapva.");

				trans.Rollback();
			}
			finally
			{

				if (kapReader != null)
					kapReader.Close();
				trans = null;


			}

			return ret;
		}

		public  List<string> GetUtcak()
		{

			OleDbTransaction trans = null;
			OleDbDataReader kapReader = null;
			List<string> ret = new List<string>();

			try
			{
				if (connection == null)
				{
					GetConnection();
				}


				trans = connection.BeginTransaction();
				allUtca.Transaction = trans;

				kapReader = allUtca.ExecuteReader();

				while (kapReader.Read())
				{
					ret.Add(kapReader.GetString(0));
				}

				trans.Commit();
			}
			catch (OleDbException ex)
			{
				MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
				trans.Rollback();
			}
			catch (InvalidOperationException inv)
			{

			}
			catch (Exception e)
			{

				AppLogger.WriteException(e);
				AppLogger.WriteEvent("A kivétel elkapva.");

				trans.Rollback();
			}
			finally
			{

				if (kapReader != null)
					kapReader.Close();
				trans = null;


			}

			return ret;
		}

		public  void UpdateKoltseg(List<Auto> cars)
		{

			OleDbTransaction trans = null;

			if (connection == null)
			{
				GetConnection();
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
			catch (OleDbException ole)
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

		public  void InsertCar(Auto auto)
		{
			if (connection == null)
			{
				GetConnection();
			}

			try
			{

				insertCar.Parameters[0].Value = auto.Rendszam;
				insertCar.Parameters[1].Value = auto.Kapacitas;
				insertCar.Parameters[2].Value = auto.Lizingdij;
				insertCar.Parameters[3].Value = auto.Fogyasztas;

				insertCar.ExecuteNonQuery();

			}
			catch (OleDbException ole)
			{
				if (ole.Errors.Count > 0 && ole.Errors[0].SQLState == "3022")
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

		public  void DeleteCar(ListBox.SelectedObjectCollection rendsz)
		{

			OleDbTransaction trans = null;

			if (connection == null)
			{
				GetConnection();
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
			catch (OleDbException)
			{

				trans.Rollback();
				MessageBox.Show("Az adatbázis frissítése nem sikerült.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				trans = null;

			}
		}

		public  void InsertLatLng(WorkData wd)
		{
            int res = 0;
			if (connection == null)
			{
				GetConnection();
			}

			try
			{
				insertLatLng.Parameters[0].Value = wd.Utca;
				insertLatLng.Parameters[1].Value = wd.Lat;
				insertLatLng.Parameters[2].Value = wd.Lng;

				res = insertLatLng.ExecuteNonQuery();
			}
			catch (OleDbException ole)
			{
                if (ole.Errors.Count > 0 && ole.Errors[0].SQLState == "3022") {

                    if (wd.Lat > 0 && wd.Lng > 0 && MessageBox.Show("A bejegyzés már szerepel: " + wd.Utca + "\nKívánja felülírni a koordinátákat?",
                    "Létező bejegyzés", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        try
                        {
                            updateLatLng.Parameters[0].Value = wd.Lat;
                            updateLatLng.Parameters[1].Value = wd.Lng;
                            updateLatLng.Parameters[2].Value = wd.Utca;

                            res = updateLatLng.ExecuteNonQuery();
                        }
                        catch (OleDbException ole2)
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
                MessageBox.Show("Az adatbázisban a következő bejegyzés módosult:\nUtca: " + wd.Utca +
                    "\nSzélesség: " + wd.Lat + "\nHosszúság: " + wd.Lng, "Sikeres frissítés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
		}

        public  void InsertLatLng(string utca, double lat, double lng)
        {
            int res = 0;
            if (connection == null)
            {
                GetConnection();
            }

            try
            {
                insertLatLng.Parameters[0].Value = utca;
                insertLatLng.Parameters[1].Value = lat;
                insertLatLng.Parameters[2].Value = lng;

               res = insertLatLng.ExecuteNonQuery();
            }
            catch (OleDbException ole)
            {
                if (ole.Errors.Count > 0 && ole.Errors[0].SQLState == "3022") {
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
                        catch (OleDbException ole2)
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

        public  void UpdateKobmeter(List<WorkData> list, DateTime date)
        {
            if (connection == null)
            {
                GetConnection();
            }

            OleDbTransaction trans = null;

            try
            {
                trans = connection.BeginTransaction();
                insertKobmeter.Transaction = updateKobmeter.Transaction = trans;
                foreach (WorkData wd in list)
                {
                    insertKobmeter.Parameters[0].Value = wd.Cim;
                    insertKobmeter.Parameters[1].Value = wd.TenylegesKobmeter;
                    insertKobmeter.Parameters[2].Value = date;

                    try
                    {
                        insertKobmeter.ExecuteNonQuery();
                    }
                    catch (OleDbException ins)
                    {
                        if (ins.Errors.Count > 0 && ins.Errors[0].SQLState == "3022")
                        {
                            //már megvolt.
                            updateKobmeter.Parameters[1].Value = wd.Cim;
                            updateKobmeter.Parameters[0].Value = wd.TenylegesKobmeter;
                            updateKobmeter.Parameters[2].Value = date;

                            updateKobmeter.ExecuteNonQuery();
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
                if (trans != null) {
                    trans.Rollback();
                }

                MessageBox.Show("Adatbázis elérési hiba.\nKérem ellenőrizze, hogy az adatbázist más alkalmazás nem használja-e!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
