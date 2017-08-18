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
	public partial class Form1
	{
		private void InitializeData()
		{
			DateTime dt = DataUtil.LastDate();
			if (dt != DateTime.MinValue)
			{

				dateTimePicker1.Value = dt;
				if (Properties.Settings.Default.upDate)
				{

					using (DataUpdater upd = new DataUpdater(dateTimePicker1.Value))
					{
						upd.ShowDialog();

					}
				}
			}
		}

		private void FillSingleCarData()
		{
			TreeNode tmpNode, tm2;
			try
			{

				workTree.Nodes.Clear();
				workTree.BeginUpdate();

				Auto auto = (Auto)statview.Tag;

				tmpNode = workTree.Nodes.Add(auto.Rendszam, auto.Info);

				if (auto.IsJozsaiAuto)
				{
					tmpNode.ForeColor = Color.Red;
				}

				if (auto.Berjarulek > Auto.BerEgyFore)
				{
					tmpNode.NodeFont = boldFont;
				}
				tmpNode.Nodes.Add("R", "Első fuvar");
				tmpNode.Nodes.Add("R", "Délelőtt");
				tmpNode.Nodes.Add("R", "Délután");

				for (int nsz = 0; nsz < 3; nsz++)
				{
					for (int a = 0; a < auto.GetNapszakFordulok(nsz); a++)
					{
						tm2 = tmpNode.Nodes[nsz].Nodes.Add("[Forduló " + (a + 1) + " ]");
						tm2.ContextMenuStrip = contextMenuStrip1;
						tm2.Tag = a;

						foreach (int id in auto.GetFuvar(nsz, a))
						{
							tm2.Nodes.Add(munkaAdat.Get(nsz, id).CsoInfo);
						}

					}
				}

				workTree.Nodes[0].Nodes[aktivNapszak].ExpandAll();
				workTree.Nodes[0].Nodes[aktivNapszak].EnsureVisible();
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

				foreach (Auto auto in autok)
				{
					statview.Rows.Add();
					if (auto.IsJozsaiAuto)
					{
						statview.Rows[rowCnt].DefaultCellStyle.ForeColor = Color.Red;
					}

					if (auto.Berjarulek > Auto.BerEgyFore)
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

		private void LoadMapData(DateTime date, bool carz)
		{
			List<MunkaAdat> tmp;

			statlabel.Text = "Az adatok betöltése folyamatban...";

			try
			{

				Reset();

				

				if (carz)
				{

					tmp = DataUtil.GetWorkData(date, out autok, out osszesito);

					using (ZeroCso zcs = new ZeroCso(tmp))
					{
						zcs.ShowDialog();
					}

					if (autok.Count > 0)
					{
						autok.Sort();

						using (CarDataGridPane cu = new CarDataGridPane(autok, osszesito, true))
						{
							if (cu.ShowDialog() == DialogResult.Cancel)
							{
								statlabel.Text = "Kész";
								return;
							}
						}
					}
					else
					{
						MessageBox.Show("Nincs megjelenítendő adat.", "Nincs adat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					tmp = DataUtil.GetWorkData(date, out osszesito);
				}

				unbig[0] = osszesito.ElsoTizes;
				unbig[1] = osszesito.DeTizes;
				unbig[2] = osszesito.DuTizes;

				unfive[0] = osszesito.ElsoLE5;
				unfive[1] = osszesito.DeLE5;
				unfive[2] = osszesito.DuLE5;

				kisM3 = osszesito.Kism3;
				nagyM3 = osszesito.Nagym3;

				LoadMarkersFromData(tmp, carz);

				AppLogger.WriteEvent(string.Format("Kiosztás: {0}", dateTimePicker1.Value.ToShortDateString()));
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void LoadMarkersFromData(List<MunkaAdat> tmp, bool carz)
		{
			munkalapSzam = tmp.Count;

			tavolsagok = new double[tmp.Count + 1, tmp.Count + 1];
			int a, b;

			for (a = 0; a < tmp.Count; a++)
			{
				if (tmp[a].Napszak < 0 || tmp[a].Napszak > 3)
					continue;
				if (tmp[a].Lat == 0)
					noData.Add(tmp[a].Utca);

				munkaAdat.Add(tmp[a].Napszak - 1, tmp[a].Number, tmp[a]);
				browser.Document.InvokeScript("addMarker",
								new object[] { tmp[a].Lat, tmp[a].Lng, tmp[a].Kobmeter, tmp[a].TenylegesKobmeter, 
									tmp[a].Lat != 0 && !tmp[a].Jozsai, tmp[a].Napszak, tmp[a].Number, tmp[a].Info, tmp[a].Kiosztott, tmp[a].CsoHossz, 
									tmp[a].Megjegyzes, tmp[a].AutoAdat});

				for (b = a + 1; b < tmp.Count; b++)
				{

					tavolsagok[a, b] = Distance(tmp[a].Lat, tmp[a].Lng, tmp[b].Lat, tmp[b].Lng);
					tavolsagok[b, a] = tavolsagok[a, b];
				}

				tavolsagok[a, tmp.Count] = Distance(tmp[a].Lat, tmp[a].Lng, urx, ury);
				tavolsagok[tmp.Count, a] = tavolsagok[a, tmp.Count];

			}

			if (carz)
				FillCarData();

			statlabel.Text = "Kész";

			ResetLabels();

			NapszakSelect();

			if (leftTab.SelectedIndex == 0)
				UpdateStat();
		}

		private void ResetLabels()
		{
			//5m3

			elsounmapOt.Text = unfive[0].ToString();
			deunmapOt.Text = unfive[1].ToString();
			dunmapOt.Text = unfive[2].ToString();

			elsoOt.Text = osszesito.ElsoLE5.ToString();
			deOt.Text = osszesito.DeLE5.ToString();
			duOt.Text = osszesito.DuLE5.ToString();
			allOt.Text = osszesito.OsszLE5.ToString();

			kism3Unmap.Text = kisM3.ToString();
			kism3.Text = osszesito.Kism3.ToString();

			//10m3

			elsoUnmapBig.Text = unbig[0].ToString();
			deUnmapBig.Text = unbig[1].ToString();
			duUnmapBig.Text = unbig[2].ToString();

			elsoBig.Text = osszesito.ElsoTizes.ToString();
			deBig.Text = osszesito.DeTizes.ToString();
			duBig.Text = osszesito.DuTizes.ToString();
			allBig.Text = osszesito.OsszTizes.ToString();

			nagym3Unmap.Text = nagyM3.ToString();
			nagym3.Text = osszesito.Nagym3.ToString();

			//Ossz

			osszElso.Text = osszesito.Elsofuvardeb.ToString();
			osszDe.Text = osszesito.Delelottdeb.ToString();
			osszDu.Text = osszesito.Delutandeb.ToString();
			osszCim.Text = osszesito.OsszDebrecen.ToString();

			osszm3.Text = (osszesito.Kism3 + osszesito.Nagym3).ToString();

			//Jozsa

			elsoJozsa.Text = osszesito.Elsofuvarjozsa.ToString();
			deJozsa.Text = osszesito.Delelottjozsa.ToString();
			duJozsa.Text = osszesito.Delutanjozsa.ToString();
			allJozsa.Text = osszesito.OsszJozsai.ToString();

			jozsam3.Text = osszesito.Jozsam3.ToString();

			soforinfo.Text = segedinfo.Text = "";
			aktualisMenet.Text = fullTav.Text = allkoltseg.Text = "0";
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
				autok.Clear();
				aktualisFordulo.Clear();
				aktivak.Items.Clear();
				workTree.Nodes.Clear();
				munkaAdat.Clear();
				savedState = 0;
				statview.Rows.Clear();
				cimGrid.Rows.Clear();
				statview.Tag = null;
				noData.Clear();

				for (int a = 0; a < 3; a++)
				{
					unbig[a] = unfive[a] = 0;
				}

				kisM3 = nagyM3 = 0;

				osszesito = new CimOsszesito();
				ResetLabels();

				if (browser.Document != null)
					browser.Document.InvokeScript("reset");
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private double Uthossz()
		{
			int[] ids = aktualisFordulo.ToArray();
			aktualisFordulo.Clear();


			double min = tavolsagok[ids[0], munkalapSzam];
			double otherDist = 0;
			int index = 0;
			int a;

			for (a = 1; a < ids.Length; a++)
			{
				if (tavolsagok[ids[a], munkalapSzam] < min)
				{
					min = tavolsagok[ids[a], munkalapSzam];
					index = a;
				}

			}
			otherDist = min;

			int c;

			for (int b = 0; b < ids.Length - 1; b++)
			{
				min = double.MaxValue;

				c = ids[index];
				aktualisFordulo.Add(c);
				ids[index] = -1;
				index = 0;

				for (a = 0; a < ids.Length; a++)
				{

					if (ids[a] != -1 && tavolsagok[ids[a], c] < min)
					{
						min = tavolsagok[ids[a], c];
						index = a;
					}

				}

				otherDist += min;
			}
			otherDist += tavolsagok[ids[index], munkalapSzam];
			aktualisFordulo.Add(ids[index]);

			return otherDist;
		}

		private void CloseWithMultiCheck(object sender, EventArgs e)
		{

			int idInt = (int)browser.Document.InvokeScript("dosome");

			CimVariacio item;
			List<CimVariacio> cimek = new List<CimVariacio>();
			string info = "";

			if (napszakAdat[idInt].Lat != 0)
			{

				foreach (int a in napszakAdat.Keys)
				{
					if (!napszakAdat[a].Kiosztott && !napszakAdat[a].Processed && tavolsagok[a, idInt] == 0 && napszakAdat[a].Lat != 0)
					{
						item = new CimVariacio();
						item.Id = a;
						item.Cim = napszakAdat[a].CsoInfo;
						info += napszakAdat[a].Megjegyzes + "<br/><br/>";
						cimek.Add(item);
					}
				}
			}

			if (cimek.Count > 1)
			{
				browser.Document.InvokeScript("showMegaInfo", new object[] { info });

				using (MultiChoice ch = new MultiChoice(cimek))
				{
					if (ch.ShowDialog() == DialogResult.OK)
					{
						CheckedListBox cb = ch.items;
						CimVariacio cv;
						for (int a = 0; a < cb.CheckedItems.Count; a++)
						{
							cv = (CimVariacio)cb.CheckedItems[a];
							cv.Check = true;
							AddFuvar(cv, false);

						}
					}

				}
			}
			else
			{

				item = new CimVariacio();
				item.Id = idInt;
				item.Cim = napszakAdat[idInt].CsoInfo;
				item.Check = true;
				AddFuvar(item, false);
			}

			fixateBtn_Click(fixateBtn, null);
		}

		private void AddWithMultiCheck(object sender, EventArgs e)
		{
			int idInt = (int)browser.Document.InvokeScript("dosome");
			string info = "";
			CimVariacio item;
			List<CimVariacio> cimek = new List<CimVariacio>();

			if (napszakAdat[idInt].Lat != 0)
			{

				foreach (int a in napszakAdat.Keys)
				{
					if (!napszakAdat[a].Kiosztott && !napszakAdat[a].Processed && tavolsagok[a, idInt] == 0 && napszakAdat[a].Lat != 0)
					{
						item = new CimVariacio();
						item.Id = a;
						item.Cim = napszakAdat[a].CsoInfo;
						item.Kob = napszakAdat[a].Kobmeter;
						info += napszakAdat[a].Megjegyzes + "<br/><br/>";
						cimek.Add(item);
					}
				}
			}

			if (cimek.Count > 1)
			{
				browser.Document.InvokeScript("showMegaInfo", new object[] { info });
				using (MultiChoice ch = new MultiChoice(cimek))
				{
					if (ch.ShowDialog() == DialogResult.OK)
					{
						CheckedListBox cb = ch.items;

						if (!cb.CheckedIndices.Contains(idInt))
							browser.Document.InvokeScript("undo", new object[] { idInt });

						foreach (CimVariacio cv in cb.CheckedItems)
						{
							AddFuvar(cv, true);
						}

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
				item.Cim = napszakAdat[idInt].CsoInfo;
				item.Kob = napszakAdat[idInt].Kobmeter;
				AddFuvar(item, true);
			}
		}

		private void AddFuvar(CimVariacio cv, bool ui)
		{
			if (aktivMenet == -1)
			{

				MessageBox.Show("Az aktív jármű minden fordulója le van zárva a napszakban.\nVálasszon másik járművet.", "Nincs szabad fuvar",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				browser.Document.InvokeScript("undo", new object[] { cv.Id });
				return;
			}

			int m3 = napszakAdat[cv.Id].Kobmeter;

			if (!aktualisFordulo.Add(cv.Id))
			{
				if (!cv.Check)
				{
					fuvarKapacitas += m3;
					aktualisFordulo.Remove(cv.Id);

					napszakAdat[cv.Id].Processed = false;
					RemoveFromAktivak(cv.Id);
				}

			}
			else
			{

				fuvarKapacitas -= m3;
				if (ui)
				{
					browser.Document.InvokeScript("doid", new object[] { cv.Id });
					aktivak.Items.Add(cv);

					AppLogger.WriteSelect(cv.Cim, true);

				}
				napszakAdat[cv.Id].Processed = true;
			}
		}

		private void RemoveFromAktivak(int p)
		{
			foreach (CimVariacio cv in aktivak.Items)
			{
				if (cv.Id == p)
				{
					aktivak.Items.Remove(cv);
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
					

					napszakAdat = munkaAdat.GetNapszakAdat(aktivNapszak);

					Auto aktivAuto = (Auto)statview.Tag;
					aktivMenet = aktivAuto.ElsoUresMenet(aktivNapszak);
					maradek = aktivAuto.GetUresFordulok(aktivNapszak);
					aktualisMenet.Text = maradek.ToString();

					if (workTree.Nodes.Count > 0)
					{
						workTree.CollapseAll();
						workTree.Nodes[0].Nodes[aktivNapszak].ExpandAll();
						workTree.Nodes[0].Nodes[aktivNapszak].EnsureVisible();
					}
					browser.Document.InvokeScript("showGroup", new object[] { aktivNapszak + 1 });

				}

				aktualisFordulo.Clear();

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

				if (aktualisFordulo.Count > 0)
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

		private void UpdateStat()
		{
			Auto au;
			for (int a = 0; a < statview.Rows.Count; a++)
			{
				au = statview[0, a].Value == null ? autok[a] : findByInfo(statview[0, a].Value.ToString());
				if (au != null)
				{
					statview[0, a].Value = au.Info;
					statview[1, a].Value = au.OsszM3.ToString();
					statview[2, a].Value = au.OsszCim.ToString();
					statview[3, a].Value = au.OsszTavolsag.ToString();
					statview[4, a].Value = au.Csohossz.ToString();
					statview[5, a].Value = au.OsszKoltseg.ToString();
					
				}
			}
			fullTav.Text = GetFullTav();
			allkoltseg.Text = GetFullKtg();

		}

		private void UpdateCimlista()
		{
			cimGrid.Rows.Clear();

			CimVariacio cv;
			if (napszakAdat != null)
			{
				foreach (int id in napszakAdat.Keys)
				{
					if (!napszakAdat[id].Kiosztott)
					{
						cv = new CimVariacio();
						cv.Cim = napszakAdat[id].CsoInfo;
						cv.Info = napszakAdat[id].CsakCsoInfo;
						cv.Kob = napszakAdat[id].Kobmeter;
						cv.Id = id;
						cv.Check = napszakAdat[id].Lat == 0;
						cimGrid.Rows.Add(cv, napszakAdat[id].Kobmeter);
					}
				}
			}
			if (cimGrid.SortOrder != SortOrder.None)
			{
				cimGrid.Sort(cimGrid.SortedColumn, cimGrid.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending :
					ListSortDirection.Descending);
			}

		}

		private void DateChange(DateTime dt, bool withCars)
		{
			LoadMapData(dt, withCars);
		}

		private string GetFullTav()
		{
			double tav = 0;
			foreach (Auto a in autok)
			{
				tav += a.OsszTavolsag;
			}
			return tav.ToString();
		}

		private string GetFullKtg()
		{
			int ktg = 0;
			foreach (Auto a in autok)
			{
				ktg += a.OsszKoltseg;
			}
			return ktg.ToString();
		}

		private Auto findByInfo(string rsz)
		{
			foreach (Auto a in autok)
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

			Properties.Settings.Default.showfuvarlap = MunkaAdat.ShowMunkalap;

			Properties.Settings.Default.Save();

			DataUtil.CloseConnection();
			AppLogger.CloseLog();
		}
	}
}