using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Xml;

namespace TurmixLog
{
	public partial class MainForm
	{
		/// <summary>
		/// A kiosztás aktuális állapotát XML formátumban mentjük. Az XML 3 részből áll:
		/// - járműhöz rendelt címek
		/// - hozzárendeletlen címek
		/// - számlálók értékei
		/// </summary>
		/// <param name="filename">A mentés után előálló állomány neve.</param>
		public void SaveState(string destFile)
		{

			try
			{
				Dictionary<int, WorkData> allData = fullRepo.GetOsszAdat();

				using (CustomXmlWriter xml = new CustomXmlWriter(destFile))
				{
					xml.Formatting = Formatting.Indented;
					xml.IndentChar = '\t';

					xml.WriteStartDocument();
					xml.WriteStartElement("mapping");
					xml.WriteAttributeString("date", dateChooser.Value.ToShortDateString());
					xml.WriteStartElement("mappedData");

					foreach (Auto car in vehicles)
					{
						xml.WriteStartElement("vehicle");
						xml.WriteAttributeString("idString", car.Rendszam);
						xml.WriteAttributeString("capacity", car.Kapacitas.ToString());
						xml.WriteAttributeString("maxFirstPeriod", car.GetNapszakFordulok(0).ToString());
						xml.WriteAttributeString("maxSecondPeriod", car.GetNapszakFordulok(1).ToString());
						xml.WriteAttributeString("maxThirdPeriod", car.GetNapszakFordulok(2).ToString());
						xml.WriteAttributeString("vehicleIndex", car.Index.ToString());
						xml.WriteAttributeString("driver", car.Sofor);
						xml.WriteAttributeString("helper", car.Seged);
						xml.WriteAttributeString("leasingCost", car.Lizingdij.ToString());
						xml.WriteAttributeString("fuelIntake", car.Fogyasztas.ToString());

						for (int period = 0; period < 3; period++)
						{
							for (int a = 0; a < car.NapszakForduloSzam(period); a++)
							{
								xml.WriteStartElement("workUnitGroup");
								xml.WriteAttributeString("distance", car.FuvarHossz(period, a).ToString());

								foreach (WorkData wd in car.GetFuvarAt(period, a))
								{
									try
									{
										wd.WriteXmlTo(xml);
										allData.Remove(wd.Number);
									}
									catch (Exception ex)
									{
										AppLogger.WriteException(ex);
										AppLogger.WriteEvent("A kivétel elkapva");
									}
								}
								xml.WriteEndElement();
							}
						}

						xml.WriteEndElement();	//vehicle
					}

					xml.WriteEndElement();

					//Még nem hozzárendelt címek
					xml.WriteStartElement("unmappedData");

					foreach (WorkData wd in allData.Values)
					{
						wd.WriteXmlTo(xml);
					}

					xml.WriteEndElement();
					xml.WriteEndElement();
					xml.Flush();
					xml.Close();

					statlabel.Text = string.Format("{0} mentése kész, idő: {1}", destFile, DateTime.Now.ToShortTimeString());
					savedState = 0;
				}

				AppLogger.WriteSave(destFile);
				WavPlayer.PlaySound(SoundType.MentésKész);
			}
			catch (Exception ex)
			{
				MessageBox.Show("A mentés sikertelen!\nEllenőrizze, más nem dolgozik-e az állományon!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void RestoreState(string sourceFile)
		{

			Reset();
			fileName = sourceFile;
			List<WorkData> allWork = new List<WorkData>();

			Auto car;
			XmlDocument sourceDoc = new XmlDocument();
			WorkData wd;

			int maxVehIndex = 0;

			try
			{
                FileStream fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				sourceDoc.Load(fs);

				DateTime sourceDate = DateTime.Parse(sourceDoc.DocumentElement.Attributes["date"].Value);
				dateChooser.Value = sourceDate;

				//Autók
				XmlNode xmlNode = sourceDoc.DocumentElement.ChildNodes[0];
				List<WorkData> workList = new List<WorkData>();
				int dest;

				foreach (XmlNode node in xmlNode.ChildNodes)
				{

					car = new Auto(node.Attributes[0].Value);
                    
					car.Kapacitas = int.Parse(node.Attributes[1].Value);
                    car.Lizingdij = float.Parse(node.Attributes[8].Value);
                    car.Fogyasztas = float.Parse(node.Attributes[9].Value);

					car.SetNapszakFordulok(0, int.Parse(node.Attributes[2].Value));
					car.SetNapszakFordulok(1, int.Parse(node.Attributes[3].Value));
					car.SetNapszakFordulok(2, int.Parse(node.Attributes[4].Value));

					car.Index = int.Parse(node.Attributes[5].Value);
					if (car.Index > maxVehIndex)
						maxVehIndex = car.Index;

					car.Sofor = node.Attributes[6].Value;
					car.Seged = node.Attributes[7].Value;

					

					//Fordulók
					 
					foreach (XmlNode groupNode in node.ChildNodes)
					{
						workList.Clear();
						dest = int.Parse(groupNode.Attributes[0].Value);
						foreach (XmlNode workNode in groupNode.ChildNodes)
						{

							wd = new WorkData();
							wd.ParseFromXml(workNode);

                            wd.ParseFold(workNode);
                            wd.ParseKoord(workNode);

							summary.UpdateWith(wd);

							workList.Add(wd);
							allWork.Add(wd);

                            
						}

						car.AddFuvar(workList, dest);
					}

					vehicles.Add(car);

				}

                if (!Properties.Settings.Default.mentettAuto)
                {
                    dao.GetAutoAdat(vehicles);
                }

				Auto.AutoIndex = maxVehIndex + 1;

				//Csórikák
				xmlNode = sourceDoc.DocumentElement.ChildNodes[1];

				foreach (XmlNode cimNode in xmlNode.ChildNodes)
				{
					wd = new WorkData();
					wd.ParseFromXml(cimNode);

                    wd.ParseFold(cimNode);
                    wd.ParseKoord(cimNode);

					summary.UpdateWith(wd);
					allWork.Add(wd);

                    if (wd.WorkCapacity <= WorkData.BigCapacityLimit)
                    {
                        if (!wd.Jozsai)
                        {
                            unfive[wd.Napszak - 1]++;
                            m3small[0] += wd.WorkCapacity;
                        }
                        else
                        {
                            unfive[wd.Napszak + 2]++;
                            m3small[1] += wd.WorkCapacity;
                        }
                    }
                    else
                    {
                        if (!wd.Jozsai)
                        {
                            unbig[wd.Napszak - 1]++;
                            m3big[0] += wd.WorkCapacity;
                        }
                        else
                        {
                            unbig[wd.Napszak + 2]++;
                            m3big[1] += wd.WorkCapacity;
                        }
                    }
                    

				}

                if (!Properties.Settings.Default.mentettFold)
                {
                    dao.GetFoldLatLng(allWork);
                }
                if (!Properties.Settings.Default.mentettKoord)
                {
                    dao.GetLatLng(allWork);
                }

				Properties.Settings.Default.lastDir = sourceFile.Substring(0, sourceFile.LastIndexOf('\\'));
				LoadMarkersFromData(allWork);

			}
			catch (Exception ex)
			{
				MessageBox.Show("Állomány megnyitása sikertelen.\nEz a verzió valószínűleg nem kompatibilis a régebbi mentésekkel.",
					"Megnyitás sikertelen", MessageBoxButtons.OK, MessageBoxIcon.Error);

				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
				Reset();

			}

			AppLogger.WriteOpen(fileName);
		}

        void fsw_Changed(object sender, FileSystemEventArgs e)
        {

            /*if (e.FullPath == fileName && lastSaved != DateTime.MinValue)
            {
                try
                {
                    FileInfo info = new FileInfo(fileName);
                    if (info.LastWriteTime > lastSaved)
                    {
                        if (MessageBox.Show("A megnyitott mentés az eredeti helyén megváltozott.\nLehetséges, hogy más is dolgozik az állománnyal.\nKívánja a mentést újból megnyitni?",
                            "Mentés megváltozott", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            RestoreState(fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.WriteException(ex);
                }
            }*/
        }

	}
}