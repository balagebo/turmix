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

namespace TurmixLog
{
	public partial class MainForm
	{

		private Color[] napszakColors = new Color[] { Color.FromArgb(252, 127, 113), Color.FromArgb(2, 219, 219), Color.Blue };
        private List<WorkData> nulls = new List<WorkData>();

		private void InitializeData()
		{

		}

		private void FillSingleCarData()
		{
			TreeNode tm2;
			int b;
			int row = 0;
			int fuvarCim;

			try
			{

				workTree.Nodes.Clear();
				workTree.BeginUpdate();

				Auto auto = (Auto)statview.Tag;
				List<WorkData> ids;

				for (int nsz = 0; nsz < 3; nsz++)
				{
					b = 1;
					fuvarCim = 1;
					groupIndex[nsz] = row;
					for (int a = 0; a < auto.NapszakForduloSzam(nsz); a++)
					{
						ids = auto.GetFuvarAt(nsz, a);
						
						foreach (WorkData ma in ids)
						{
							
							tm2 = workTree.Nodes.Add(auto.Info, string.Format("{0}.{1} {2}", fuvarCim++, b, 
								ma.GetInfo(WorkData.ShowWorksheetNumber, true, true, true)));
							tm2.BackColor = napszakColors[nsz];
							tm2.ForeColor = nsz > 1 ? Color.White : Color.Black;
							tm2.ContextMenuStrip = contextMenuStrip1;
							tm2.Tag = a;
							row++;

							browser.Document.InvokeScript("setAutoInfo", new object[] { ma.Number, auto.Index, b });
						}
						if (ids.Count > 0)
							b++;
					}
				}

				workTree.EndUpdate();

			}
			catch (Exception ex)
			{
			}
		}

		private void FillCarData()
		{
			int rowCnt = 0;

			try
			{

				statview.Rows.Clear();

				foreach (Auto auto in vehicles)
				{
					statview.Rows.Add();
					if (auto.IsJozsaiAuto)
					{
						statview.Rows[rowCnt].DefaultCellStyle.ForeColor = Color.Red;
					}

					if (auto.KettenUlnek)
					{
						statview.Rows[rowCnt].DefaultCellStyle.Font = boldFont;
					}
					rowCnt++;
				}


				workTree.EndUpdate();
				if (workTree.Nodes.Count > 0)
					workTree.Nodes[0].ExpandAll();

			}
			catch (Exception ex)
			{
			}
		}

		private void LoadMapData(object sender, FormClosingEventArgs e)
		{
			DataUpdater updater = sender as DataUpdater;

			try
			{

				Reset();

				List<WorkData> tmp = updater.WorkData;

                
				//Mégse gomb meg lett nyomva
				if (tmp == null)
					return;

                dao.GetFoldLatLng(tmp);

				vehicles = updater.Autok;
				summary = updater.Cimosszesito;

				if (vehicles.Count == 0)
				{
					MessageBox.Show("Nincs megjelenítendő adat.", "Nincs adat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					ResetLabels();
				    UpdateBottomPanel();
					return;

				}
				else
				{
					using (ZeroCso zcs = new ZeroCso(tmp, dao))
					{
						zcs.ShowDialog();
					}

					vehicles.Sort();
					using (CarDataGridPane cu = new CarDataGridPane(vehicles, summary, true, dao))
					{
						if (cu.ShowDialog() == DialogResult.Cancel)
						{
							return;
						}
					}
				}

				unbig[0] = summary.ElsofuvarNagyDeb;
				unbig[1] = summary.DelelottNagyDeb;
				unbig[2] = summary.DelutanNagyDeb;
                unbig[3] = summary.ElsoTizesJozsa;
                unbig[4] = summary.DeTizesJozsa;
                unbig[5] = summary.DuTizesJozsa;

				unfive[0] = summary.ElsofuvarKisDeb;
				unfive[1] = summary.DelelottKisDeb;
				unfive[2] = summary.DelutanKisDeb;
                unfive[3] = summary.ElsoLE5Jo;
                unfive[4] = summary.DeLE5Jo;
                unfive[5] = summary.DuLE5Jo;

                m3small[0] = summary.Kism3Deb;
                m3small[1] = summary.Kism3Jozsa;
                m3big[0] = summary.Nagym3Deb;
                m3big[1] = summary.Nagym3Jozsa;

                

				LoadMarkersFromData(tmp);

				AppLogger.WriteEvent(string.Format("Kiosztás: {0}", dateChooser.Value.ToShortDateString()));
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void LoadMarkersFromData(List<WorkData> tmp)
		{
			Comparison<WorkData> flapComp = new Comparison<WorkData>(WorkData.CompareByNumber);
			tmp.Sort(flapComp);

			worksTotal = tmp.Count;

			distances = new double[worksTotal + 1, worksTotal + 1];
			int a, b;
			HashSet<int> multip;
			WorkData data;
            

			for (a = 0; a < worksTotal; a++)
			{
				data = tmp[a];
				fullRepo.Add(data);
				multip = new HashSet<int>();
				for (b = a + 1; b < worksTotal; b++)
				{
					distances[a, b] = Distance(data.Lat, data.Lng, tmp[b].Lat, tmp[b].Lng);
					distances[b, a] = distances[a, b];

				}

				distances[a, worksTotal] = Distance(data.Lat, data.Lng, urx, ury);
				distances[worksTotal, a] = distances[a, worksTotal];

				for (b = 0; b < worksTotal; b++)
				{
					if (a != b && distances[a, b] == 0
						&& data.Napszak == tmp[b].Napszak
						//&& !data.Jozsai && !tmp[b].Jozsai
						&& data.Lat > 0 && tmp[b].Lat > 0)
					{
						multip.Add(b);
					}
				}

				if (multip.Count > 0)
				{
					multip.Add(a);
					multipleAddress.Add(a, multip);
				}

                if (tmp[a].Lat == 0)
                {
                    nulls.Add(tmp[a]);
                }
				
				browser.Document.InvokeScript("addMarker",
									new object[] { data.Lat, data.Lng, data.WorkCapacity, data.TenylegesKobmeter, 
									 data.Napszak, data.Number, data.Kiosztott, data.CsoHossz, 
									data.Megjegyzes, data.AutoAdat, data.TempFordulo, data.Problematic});

			}

			FillCarData();

			ToggleMenuItems(true);

			ResetLabels();

			NapszakSelect();

			CheckImageState();

			if (leftTab.SelectedIndex == 0)
				UpdateStat();
		}

        private void LoadMarker(WorkData data)
        {
            int a = data.Number, b;

            Dictionary<int, WorkData> adat = fullRepo.GetOsszAdat();
            for (b = 0; b < worksTotal; b++)
            {
                distances[a, b] = Distance(data.Lat, data.Lng, adat[b].Lat, adat[b].Lng);
                distances[b, a] = distances[a, b];

            }

            distances[a, worksTotal] = Distance(data.Lat, data.Lng, urx, ury);
            distances[worksTotal, a] = distances[a, worksTotal];

            WorkData tmp;
            HashSet<int> mult = new HashSet<int>();

            if (multipleAddress.ContainsKey(a) && distances[a, multipleAddress[a].ElementAt(0)] != 0)
            {
                //megszüntetjük
                foreach (int key in multipleAddress[a])
                {
                    multipleAddress[key].Remove(a);
                }
                multipleAddress.Remove(a);
            }

            for (b = 0; b < worksTotal; b++)
            {
                tmp = fullRepo.Find(b);
                if (a != b && distances[a, b] == 0
                        && data.Napszak == tmp.Napszak
                        //&& !data.Jozsai && !tmp.Jozsai
                        && data.Lat > 0 && tmp.Lat > 0)
                {
                    if (multipleAddress.ContainsKey(b))
                    {
                        foreach (int key in multipleAddress[b])
                        {
                            multipleAddress[key].Add(a);
                        }
                        try
                        {
                            multipleAddress.Add(a, multipleAddress[b]);
                        }
                        catch (ArgumentException)
                        {
                        }
                        break;
                    }
                    else
                    {
                        mult.Add(a);
                        mult.Add(b);
                        multipleAddress.Add(a, mult);
                        multipleAddress.Add(b, mult);
                        break;
                    }
                }
            }

            browser.Document.InvokeScript("setLatLng", new object[] { a, data.Lat, data.Lng, data.Problematic, data.Napszak });
            CheckImageState();
        }

		private void ResetLabels()
		{
			//5m3

			smallToGoEFDeb.Text = unfive[0].ToString();
			smallToGoDEDeb.Text = unfive[1].ToString();
			smallToGoDUDeb.Text = unfive[2].ToString();
            smallToGoEFJo.Text = unfive[3].ToString();
            smallToGoDEJo.Text = unfive[4].ToString();
            smallToGoDUJo.Text = unfive[5].ToString();

			smallEFDeb.Text = summary.ElsofuvarKisDeb.ToString();
			smallDEDeb.Text = summary.DelelottKisDeb.ToString();
			smallDUDeb.Text = summary.DelutanKisDeb.ToString();
			smallOsszDeb.Text = summary.OsszLE5Deb.ToString();
            smallEFJo.Text = summary.ElsoLE5Jo.ToString();
            smallDEJo.Text = summary.DeLE5Jo.ToString();
            smallDUJo.Text = summary.DuLE5Jo.ToString();
            smallOsszJo.Text = summary.OsszLE5Jozsa.ToString();

            //smallToGoM3Deb.Text = m3small[0].ToString();
            smallM3Deb.Text = summary.Kism3Deb.ToString();
            //smallToGoM3Jo.Text = m3small[1].ToString();
            smallM3Jo.Text = summary.Kism3Jozsa.ToString();

			//10m3

			bigToGoEFDeb.Text = unbig[0].ToString();
			bigToGoDEDeb.Text = unbig[1].ToString();
			bigToGoDUDeb.Text = unbig[2].ToString();
            bigToGoEFJo.Text = unbig[3].ToString();
            bigToGoDEJo.Text = unbig[4].ToString();
            bigToGoDUJo.Text = unbig[5].ToString();

			bigEFDeb.Text = summary.ElsofuvarNagyDeb.ToString();
			bigDEDeb.Text = summary.DelelottNagyDeb.ToString();
			bigDUDeb.Text = summary.DelutanNagyDeb.ToString();
			bigOsszDeb.Text = summary.OsszTizesDeb.ToString();
            bigEFJo.Text = summary.ElsoTizesJozsa.ToString();
            bigDEJo.Text = summary.DeTizesJozsa.ToString();
            bigDUJo.Text = summary.DuTizesJozsa.ToString();
            bigOsszJo.Text = summary.OsszTizesJozsa.ToString();

			//bigToGoM3Deb.Text = m3big[0].ToString();
            bigM3Deb.Text = summary.Nagym3Deb.ToString();
            //bigToGoM3Jo.Text = m3big[1].ToString();
            bigM3Jo.Text = summary.Nagym3Jozsa.ToString();

			//Ossz

			allEFDeb.Text = summary.ElsofuvarOsszDeb.ToString();
			allDEDeb.Text = summary.DelelottOsszDeb.ToString();
			allDUDeb.Text = summary.DelutanOsszDeb.ToString();
			allOsszDeb.Text = summary.OsszDebrecen.ToString();
            allM3Deb.Text = summary.Osszm3Deb.ToString();
            allM3Jo.Text = summary.Osszm3Jo.ToString();

			//Jozsa

			allEFJo.Text = summary.ElsofuvarOsszJozsa.ToString();
			allDEJo.Text = summary.DelelottOsszJozsa.ToString();
			allDUJo.Text = summary.DelutanOsszJozsa.ToString();
			allOsszJo.Text = summary.OsszJozsai.ToString();

            sumEF.Text = summary.Elsofuvar.ToString();
            sumDE.Text = summary.Delelott.ToString();
            sumDU.Text = summary.Delutan.ToString();
            sumOssz.Text = summary.OsszEgesz.ToString();
            sumM3.Text = summary.Osszm3.ToString();

			driverTxt.Text = helperTxt.Text = "";
			availableWorkTxt.Text = fullTav.Text = allkoltseg.Text = fajlagosTav.Text = "0";
			atlagMunkaVege.Text = "06:00";
			fajlagosIdo.Text = cumiteny.Text = "0:00:00";
			infotext.Text = "";
            fajcso.Text = "0";

            nomapButton.Visible = nulls.Count > 0;
		}

		private double Distance(double x1, double y1, double x2, double y2)
		{
			if (x1 == 0 || x2 == 0)
				return 0;

			double tmp = Math.Abs(x2 - x1) * 111.3;
			double tmp2 = Math.Abs(y2 - y1) * 111.3;

			return Math.Sqrt(tmp * tmp + tmp2 * tmp2);
		}

		private void Reset()
		{
			try
			{
				fileName = null;
				vehicles.Clear();
				actualWorkSet.Clear();
                nulls.Clear();
				clickedGroup.Items.Clear();
				workTree.Nodes.Clear();
				fullRepo.Clear();
				savedState = 0;
				statview.Rows.Clear();
				cimGrid.Rows.Clear();
				statview.Tag = null;
				multipleAddress.Clear();
				infoÜzemmódToolStripMenuItem.Checked = false;
				alertGroup.Checked = false;

				statlabel.Text = "Kész";

				for (int a = 0; a < unbig.Length; a++)
				{
					unbig[a] = unfive[a] = 0;
				}

                for (int a = 0; a < m3big.Length; a++)
                {
                    m3big[a] = m3small[a] = 0;
                }

				summary = new CimOsszesito();
				ResetLabels();

				ToggleMenuItems(false);

				if (browser.Document != null)
					browser.Document.InvokeScript("reset");
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private int Uthossz(int[] ids)
		{
			/*double otherDist = 0;
			if (ids.Length > 0)
			{
				double min = distances[ids[0], worksTotal];

				int index = 0;
				int a;

				for (a = 1; a < ids.Length; a++)
				{
					if (distances[ids[a], worksTotal] < min)
					{
						min = distances[ids[a], worksTotal];
						index = a;
					}

				}
				otherDist = min;

				int c;

				for (int b = 0; b < ids.Length - 1; b++)
				{
					min = double.MaxValue;

					c = ids[index];
					ids[index] = -1;
					index = 0;

					for (a = 0; a < ids.Length; a++)
					{

						if (ids[a] != -1 && distances[ids[a], c] < min)
						{
							min = distances[ids[a], c];
							index = a;
						}

					}

					otherDist += min;
				}
				otherDist += distances[ids[index], worksTotal];
			}
			return (int)Math.Round(otherDist);*/

            double dist = 0d;

            foreach (int id in ids)
            {
                dist += distances[id, worksTotal];
            }

            return (int)Math.Round(dist) * 2;

		}

		private void CloseWithMultiCheck(object sender, EventArgs e)
		{

			int idInt = (int)browser.Document.InvokeScript("dosome");

			CimVariacio item;
			List<CimVariacio> cimek = new List<CimVariacio>();
            WorkData wd;

			if (remaining == 0)
			{

				MessageBox.Show("Az aktív járműnek nincs szabad címe a napszakban.\nVálasszon másik járművet.", "Nincs szabad cím",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				browser.Document.InvokeScript("undo", new object[] { idInt });
                RestoreJunction(idInt);
				return;
			}

            if (multipleAddress.ContainsKey(idInt))
            {
                foreach (int id in multipleAddress[idInt])
                {
                    wd = partialRepo[id];
                    if (wd.Kiosztott || wd.Processed ||
                    (alertGroup.Checked && !wd.Problematic) || (visibleGroup > 0 && wd.Csoport != visibleGroup))
                    {
                        continue;
                    }
                    item = new CimVariacio();
                    item.Id = id;
                    item.Cim = wd.GetInfo(true, true, true, true);
                    item.Kob = wd.WorkCapacity;
                    item.Megjegyzes = wd.Megjegyzes;
                    cimek.Add(item);
                }

            }

			if (cimek.Count > 1)
			{
				
				using (MultiChoice ch = new MultiChoice(cimek))
				{
					if (ch.ShowDialog() == DialogResult.OK)
					{
						foreach (CimVariacio cv in ch.GetAllChecked())
						{
							AddFuvar(cv, false);
						}
					}

				}
			}
			else
			{

				item = new CimVariacio();
				item.Id = idInt;
				item.Cim = partialRepo[idInt].GetInfo(true, true, true, true);
				item.Check = true;
				AddFuvar(item, false);
			}

			fixateBtn_Click(fixateBtn, null);
		}

		private void AddWithMultiCheck(object sender, EventArgs e)
		{

			int idInt = (int)browser.Document.InvokeScript("dosome");
			CimVariacio item;
			List<CimVariacio> cimek = new List<CimVariacio>();
			bool bennevan = false;
            WorkData wd;

			if (remaining == 0)
			{

				MessageBox.Show("Az aktív járműnek nincs szabad címe a napszakban.\nVálasszon másik járművet.", "Nincs szabad cím",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				browser.Document.InvokeScript("undo", new object[] { idInt });
                RestoreJunction(idInt);
				return;
			}

            if (multipleAddress.ContainsKey(idInt))
            {

                foreach (int id in multipleAddress[idInt])
                {
                    wd = partialRepo[id];
                    if (wd.Kiosztott || wd.Processed ||
                    (alertGroup.Checked && !wd.Problematic) || (visibleGroup > 0 && wd.Csoport != visibleGroup))
                    {
                        continue;
                    }
                    item = new CimVariacio();
                    item.Id = id;
                    item.Cim = wd.GetInfo(true, true, true, true);
                    item.Kob = wd.WorkCapacity;
                    item.Megjegyzes = wd.Megjegyzes;
                    cimek.Add(item);
                }

            }

			if (cimek.Count > 1)
			{
				using (MultiChoice ch = new MultiChoice(cimek))
				{
					if (ch.ShowDialog() == DialogResult.OK)
					{
						
						foreach (CimVariacio cv in ch.GetAllChecked())
						{

							if (cv.Id == idInt)
								bennevan = true;
							AddFuvar(cv, true);
							cimek.Remove(cv);
							
						}
						if (!bennevan)
							browser.Document.InvokeScript("undo", new object[] { idInt });
					}
					else
					{
                        browser.Document.InvokeScript("undo", new object[] { idInt });
					}
                    
				}
			}
			else
			{

				item = new CimVariacio();
				item.Id = idInt;
				item.Cim = partialRepo[idInt].GetInfo(true, true, true, true);
				item.Kob = partialRepo[idInt].WorkCapacity;
				AddFuvar(item, true);
			}
            RestoreJunction(idInt);
		}

		private void RestoreJunction(int idInt)
		{
			int maxId = 0, cnt = 0;
			WorkData ma;
            bool problemas;
			
			if (multipleAddress.ContainsKey(idInt))
			{
                problemas = false;
                foreach (int id in multipleAddress[idInt])
                {
                    
                    ma = fullRepo.Find(id);
                    if (ma.Kiosztott || ma.Processed ||
                    (alertGroup.Checked && !ma.Problematic) || (visibleGroup > 0 && ma.Csoport != visibleGroup))
                    {
                        continue;
                    }
                    if (ma.Problematic)
                        problemas = true;
                    cnt++;
                    if (id > maxId)
                        maxId = id;

                }
				if (cnt > 1)
					browser.Document.InvokeScript("setJunction", new object[] { maxId, problemas });
				else
				{
					browser.Document.InvokeScript("setProblematic", new object[] { maxId, fullRepo.Find(maxId).Problematic });
				}
			}			
			
		}

		private void AddFuvar(CimVariacio cv, bool ui)
		{
			

			int m3 = partialRepo[cv.Id].WorkCapacity;

			if (!actualWorkSet.Add(cv.Id))
			{
				if (!cv.Check)
				{
					groupCapacity += m3;
					actualWorkSet.Remove(cv.Id);

					partialRepo[cv.Id].Processed = false;
					RemoveFromAktivak(cv.Id);
				}

			}
			else
			{

				groupCapacity -= m3;
				if (ui)
				{
					browser.Document.InvokeScript("doid", new object[] { cv.Id });
					clickedGroup.Items.Add(cv);

					AppLogger.WriteSelect(cv.Cim, true);

				}
				partialRepo[cv.Id].Processed = true;
			}
		}

		private void RemoveFromAktivak(int p)
		{
			foreach (CimVariacio cv in clickedGroup.Items)
			{
				if (cv.Id == p)
				{
					clickedGroup.Items.Remove(cv);
					return;
				}
			}
		}

		private void NapszakSelect()
		{
			try
			{
				if (statview.SelectedRows.Count > 0)
				{
					
					partialRepo = fullRepo.GetNapszakAdat(activePeriod);

					Auto aktivAuto = (Auto)statview.Tag;
					
					remaining = aktivAuto.SzabadCimek(activePeriod);
					availableWorkTxt.Text = remaining.ToString();

					browser.Document.InvokeScript("showGroup", new object[] { activePeriod + 1 });
				}

				actualWorkSet.Clear();

				if (leftTab.SelectedIndex == 1)
				{
					UpdateCimlista();
				}

			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void CheckAbandonState()
		{
			if (statview.Tag != null)
			{

				if (actualWorkSet.Count > 0)
				{

					if (MessageBox.Show("Az aktuális forduló nincs lezárva!\n Lezárjam?", "Aktuális forduló nincs lezárva",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						fixateBtn_Click("0", null);
					}
					else
					{
						fuvarTörléseToolStripMenuItem_Click(null, null);
					}

				}

			}
		}

		private void UpdateBottomPanel()
		{
			try
			{
				float cumi = GetCumiAtlag(true);
				float osszido = cumi * vehicles.Count;
				double tav = GetFullTav();
				allkoltseg.Text = GetFullKtg();

				int osszcimek = GetOsszCimszam();
                int osszCso = GetOsszCsohossz();

				DateTime dt = DateTime.Now.Date.AddMinutes(cumi);

				fullTav.Text = tav.ToString();
				cumiteny.Text = dt.ToString("H:mm:ss");

				if (osszcimek > 0)
				{
					dt = DateTime.Now.Date.AddMinutes(osszido / osszcimek);

					fajlagosIdo.Text = dt.ToString("H:mm:ss");
					fajlagosTav.Text = (tav / osszcimek).ToString("F2");
                    
				}
				else
				{
					fajlagosTav.Text = "0";
					fajlagosIdo.Text = "0:00:00";
				}
				
				dt = DateTime.Now.Date.AddHours(6).AddMinutes(cumi);

				if (dt.Hour >= 12)
					dt = dt.AddMinutes(Properties.Settings.Default.ebedido);

				atlagMunkaVege.Text = dt.ToString("HH:mm");

                fajcso.Text = (osszcimek == 0 || osszCso == 0) ? "0" : ((float)osszCso / osszcimek).ToString("F2");
			}
			catch (Exception ex)
			{

			}
		}

		private void UpdateStat()
		{
			float cumi = GetCumiAtlag(true);
			Auto au;
			for (int a = 0; a < statview.Rows.Count; a++)
			{
				au = statview[0, a].Value == null ? vehicles[a] : findByInfo(statview[0, a].Value.ToString());
				if (au != null)
				{
                    statview.Rows[a].DefaultCellStyle.ForeColor = au.IsJozsaiAuto ? Color.Red : Color.Black;

					statview[0, a].Value = au.Info;
					statview[1, a].Value = au.OsszM3.ToString();
					statview[2, a].Value = string.Format("{0}/{1}", au.KicsiCim.ToString(), au.NagyCim.ToString());
					statview[3, a].Value = au.OsszTavolsag.ToString();
					statview[4, a].Value = au.Csohossz.ToString();
					statview[5, a].Value = au.OsszKoltseg.ToString();
					statview[6, a].Value = cumi == 0 ? "0" : ((int)Math.Round(au.CumiTenyezo / cumi * 100 - 100)).ToString();

					statview[7, a].Value = au.MikorVegezStr;

				}
			}

			UpdateBottomPanel();
		}

		

		private void UpdateCimlista()
		{
			cimGrid.Rows.Clear();

			CimVariacio cv;
			if (partialRepo != null)
			{
				foreach (int id in partialRepo.Keys)
				{
					if (!partialRepo[id].Kiosztott && (partialRepo[id].Csoport == visibleGroup || visibleGroup == 0))
					{
						if (alertGroup.Checked && !partialRepo[id].Problematic)
							continue;
						cv = new CimVariacio();
						cv.Cim = partialRepo[id].GetInfo(false, true, true, true);
						cv.Info = partialRepo[id].GetInfo(false, false, true, true);
						cv.Kob = partialRepo[id].WorkCapacity;
						cv.Id = id;
						cv.Check = partialRepo[id].Lat == 0;
						cimGrid.Rows.Add(cv, partialRepo[id].WorkCapacity);
					}
					
				}
			}
			if (cimGrid.SortOrder != SortOrder.None)
			{
				cimGrid.Sort(cimGrid.SortedColumn, cimGrid.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending :
					ListSortDirection.Descending);
			}

			if (cimGrid.Rows.Count > 0)
				cimGrid.Rows[0].Selected = true;

			UpdateBottomPanel();

		}

		private int GetOsszCimszam()
		{
			int cnt = 0;
			foreach (Auto a in vehicles)
			{
				cnt += a.OsszCim;
			}
			return cnt;
		}

		private double GetFullTav()
		{
			double tav = 0;
			foreach (Auto a in vehicles)
			{
				tav += a.OsszTavolsag;
			}
			return tav;
		}

        private int GetOsszCsohossz()
        {
            int csh = 0;
            foreach (Auto a in vehicles)
            {
                csh += a.Csohossz;
            }
            return csh;
        }

		private string GetFullKtg()
		{
			int ktg = 0;
			foreach (Auto a in vehicles)
			{
				ktg += a.OsszKoltseg;
			}
			return ktg.ToString();
		}

		private float GetCumiAtlag(bool avg)
		{
			float ktg = 0;

			if (vehicles.Count == 0)
				return 0f;

			foreach (Auto a in vehicles)
			{
				ktg += a.CumiTenyezo;
			}
			
			return avg ? ktg / vehicles.Count : ktg;
		}

		private Auto findByInfo(string rsz)
		{
			foreach (Auto a in vehicles)
			{
				if (a.Info == rsz)
				{
					return a;
				}
			}
			return null;
		}

		public void CloseUp()
		{
			Properties.Settings.Default.cimlistaW = bottomSplit.SplitterDistance;
			Properties.Settings.Default.listaH = splitContainer2.SplitterDistance; 
			Properties.Settings.Default.panelH = splitContainer1.SplitterDistance;

			Properties.Settings.Default.showfuvarlap = WorkData.ShowWorksheetNumber;

			Properties.Settings.Default.Save();

			dao.CloseConnection();
			AppLogger.CloseLog();
		}

		public int FindAutoIndex(string info)
		{
			for (int a = 0; a < statview.Rows.Count; a++)
			{
				if (statview[0, a].Value.ToString() == info)
				{
					statview.Rows[a].Selected = true;
					return a;
				}
			}
			return -1;
		}

		public void CheckImageState()
		{
			int maxId, cnt;
			WorkData ma;
            bool problemas;
			foreach (int key in multipleAddress.Keys)
			{
                problemas = false;
				maxId = 0;
				cnt = 0;
				try
				{
                    foreach (int id in multipleAddress[key])
                    {
                        ma = fullRepo.Find(id);

                        if (ma.Kiosztott || ma.Processed ||
                        (alertGroup.Checked && !ma.Problematic) || (visibleGroup > 0 && ma.Csoport != visibleGroup))
                        {
                            continue;
                        }
                        if (ma.Problematic)
                            problemas = true;
                        if (id > maxId)
                            maxId = id;
                        cnt++;

                    }

					if (cnt > 1)
					{
						browser.Document.InvokeScript("setJunction", new object[] { maxId, problemas  });
					}
					else
					{
						browser.Document.InvokeScript("setProblematic", new object[] { maxId, fullRepo.Find(maxId).Problematic });
					}
				}
				catch (Exception e)
				{
					//Ez másik napszak, de ez minket nem érdekel.
					continue;
				}
			}
		}

		public void ToggleMenuItems(bool toggle)
		{
			saveButton.Enabled = settingsButton.Enabled = 
			mentésMáToolStripMenuItem.Enabled = aktuálisÁllapotMentéseToolStripMenuItem.Enabled = 
			járművekAdataiToolStripMenuItem.Enabled = infoÜzemmódToolStripMenuItem.Enabled = 
			munkalapszámLátszikAListábanToolStripMenuItem.Enabled = címekSzerkesztéseToolStripMenuItem.Enabled = 
            //nemMegjeleníthetőCímekToolStripMenuItem.Enabled = 
            munkalapAdatokToolStripMenuItem.Enabled = toggle;
		
		}
	}
}