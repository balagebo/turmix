using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DatabaseUpdater
{
    class UpdaterDao : TurmixUtils.MySqlDao
    {

        public override void Init()
        {
            MySqlCommand command = new MySqlCommand("DROP TABLE IF EXISTS tm3");
            command.Connection = connection;
            command.ExecuteNonQuery();

            command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS `tm3` (
                      `fhkod` varchar(10) NOT NULL,
                      `vonalkod` varchar(20) NOT NULL,
                      `szamla` varchar(20) NOT NULL,
                      `szamla_osszege` int(11) NOT NULL,
                      `mennyiseg` tinyint(4) NOT NULL,
                      `terulet` varchar(100) NOT NULL,
                      `tamogatas` varchar(20) NOT NULL,
                      `ceg` varchar(20) NOT NULL,
                      `datum` varchar(20) NOT NULL,
                      `alapdij` int(11) NOT NULL DEFAULT '0',
                      `alapdij_kezdet` varchar(20) NOT NULL,
                      `alapdij_veg` varchar(20) NOT NULL,
                      `megtakaritas` varchar(20) NOT NULL,
                      `sofor` varchar(100) NULL,
                      `rendszam` varchar(20) NULL  
                    ) CHARSET=utf8;
                    ";
            command.ExecuteNonQuery();
            Console.WriteLine("Az adatbázis frissítése kész. A folytatáshoz nyomjon meg egy billentyűt...");
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
                switch (ole.Number)
                {
                    case 1042:
                    case 1044:
                    case 1045:
                        Console.Write("A telepítéshez az adatbázis frissítésére van szükség.\nKívánja most frissíteni az adatbázis hozzáférést? (i/n):\n");
                        string result = Console.ReadLine();
                        if (result.ToLower() == "i")
                        {
                            UpdateSettings();
                            GetConnection();
                        }
                        else
                        {
                            throw;
                        }
                        break;
                    default:
                        throw;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Az adatbázis elérésekor a következő hiba történt:\n{0}\nA kilépéshez nyomjon meg egy billentyűt...", e.Message));
            }
        }

        private void UpdateSettings()
        {

            Console.Write("Adatbázis szervergép neve (pl. cpc-009):");
            Properties.Settings.Default.dbHost = Console.ReadLine();
            Console.Write("Adatbázis neve (pl. turmix):");
            Properties.Settings.Default.dbName = Console.ReadLine();
            Console.Write("Adatbázis felhasználó neve (pl. dev):");
            Properties.Settings.Default.dbUser = Console.ReadLine();
            Console.Write("Adatbázis jelszó:");
            Properties.Settings.Default.dbPass = Console.ReadLine();

            Properties.Settings.Default.Save();
        }
    }
}
