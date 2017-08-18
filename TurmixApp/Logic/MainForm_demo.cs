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
using System.Net;
using System.Threading;
using System.Globalization;

namespace TurmixLog
{
    public partial class MainForm : Form
    {
		private Dictionary<int, HashSet<int>> multipleAddress = new Dictionary<int, HashSet<int>>();
		private List<Auto> vehicles = new List<Auto>();
		private Repository fullRepo = new Repository();

        private KiosztasDao dao = new KiosztasDao();

		private Dictionary<int, WorkData> partialRepo;

		private DateTimePicker dateChooser = new DateTimePicker();

		private double[,] distances;
		private double urx = 47.501306;
		private double ury = 21.601979;

		private int activePeriod;

		private int oldSelection;

		private int remaining;

		private int groupCapacity;

		private int visibleGroup;

		private CimOsszesito summary;

		private HashSet<int> actualWorkSet = new HashSet<int>();
		private int worksTotal;
        private int[] unbig = new int[6], unfive = new int[6], groupIndex = new int[3], m3big = new int[2], m3small = new int[2];
            
		private Label[] unmapLabel, unBigLabel, unFiveLabel, m3LabelDeb, m3LabelJozsa;
		private ToolStripButton[] radios;
		private int savedState;

		private Font boldFont;

		private string fileName;

		private Font printFont = new Font("Courier New", 10f, FontStyle.Bold);
		private PageSettings pageSettings = new PageSettings();

        private NumberFormatInfo numberFormat;

        public MainForm(string[] args)
        {
            InitializeComponent();

			browser.Navigate(string.Format("file://{0}/resources/map.htm", Application.StartupPath));

			if (args.Length == 1)
				InitializeData();
			else
				fileName = args[1];

			WorkData.BigCapacityLimit = Properties.Settings.Default.kisAutoLimit;
			WorkData.ShowWorksheetNumber = munkalapszámLátszikAListábanToolStripMenuItem.Checked = Properties.Settings.Default.showfuvarlap;

			unmapLabel = new Label[] { allToGoEFDeb, allToGoDEDeb, allToGoDUDeb, allToGoEFJo, allToGoDEJo, allToGoDUJo };
			unFiveLabel = new Label[] {smallToGoEFDeb, smallToGoDEDeb, smallToGoDUDeb, smallToGoEFJo, smallToGoDEJo, smallToGoDUJo};
			unBigLabel = new Label[] {bigToGoEFDeb, bigToGoDEDeb, bigToGoDUDeb, bigToGoEFJo, bigToGoDEJo, bigToGoDUJo};
            m3LabelDeb = new Label[] { smallM3Deb, bigM3Deb};
            m3LabelJozsa = new Label[] { smallM3Jo, bigM3Jo };
			radios = new ToolStripButton[] { osszauto_rad, kisauto_rad, nagyauto_rad, alertGroup };

			cimGrid.Sort(Column1, ListSortDirection.Ascending);

			boldFont = new Font(workTree.Font, FontStyle.Bold);

			osszauto_rad.Tag = 0;
			kisauto_rad.Tag = 1;
			nagyauto_rad.Tag = 2;

			dateChooser.Format = DateTimePickerFormat.Short;
			toolStrip1.Items.Insert(1, new ToolStripControlHost(dateChooser));

            CultureInfo cinfo = CultureInfo.CreateSpecificCulture("HU-hu");
            cinfo.NumberFormat.NumberDecimalSeparator = ".";
            cinfo.DateTimeFormat.DateSeparator = "-";
            cinfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Application.CurrentCulture = cinfo;
            numberFormat = cinfo.NumberFormat;
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
			browser.Document.GetElementById("loadready").AttachEventHandler("onclick", new EventHandler(button4_Click));
			browser.Document.GetElementById("klikker").Click += new HtmlElementEventHandler(CloseWithMultiCheck);
			browser.Document.GetElementById("inf").Click += new HtmlElementEventHandler(InfoClick);
            browser.Document.GetElementById("streetclick").Click += new HtmlElementEventHandler(AddingFinished);
            browser.Document.GetElementById("distance").Click += new HtmlElementEventHandler(FoldutFinished);
        }

		private void InfoClick(object sender, EventArgs e)
		{
			int idInt = (int)browser.Document.InvokeScript("dosome");
			ShowInfo(idInt);
		}

		private void ShowInfo(int idInt)
		{
			try
			{
				WorkData wd = fullRepo.Find(idInt);

				infotext.Lines = new string[] {wd.GetInfo(true, true, true, false), 
						"Info: " + wd.Megjegyzes};

					infotext.Refresh();
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{

			browser.Document.InvokeScript("setNagyM3", new object[] { WorkData.BigCapacityLimit });
			browser.Document.GetElementById("hidden").AttachEventHandler("onclick", new EventHandler(AddWithMultiCheck));
			browser.Document.AttachEventHandler("onkeydown", new EventHandler(MapKeyDown));
			browser.Document.AttachEventHandler("onkeyup", new EventHandler(MapKeyUp));

			if (fileName != null)
			{
				AppLogger.WriteEvent(string.Format("Argumentum megnyitás: {0}", fileName));
				RestoreState(fileName);
			}

		}

		private void MapKeyDown(object sender, EventArgs e)
		{
			browser.Document.InvokeScript("showInfo", new object[] { statview.Tag == null ? -1 : ((Auto)statview.Tag).Index });
		}

		private void MapKeyUp(object sender, EventArgs e)
		{
			browser.Document.InvokeScript("hideInfo");
		}

		private void fuvarTörléseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Auto activeVehicle;
			int period = activePeriod;
			int group;
			
			bool performedDelete = false;

			if (sender == null)
			{
				//szelekció és nem volt lezárva és HÓTMINDEGY a júzer mire kattintott
				if (actualWorkSet.Count == 0)
					return;

				activeVehicle = (Auto)statview.Tag;
				WorkData wd;

				foreach (int id in actualWorkSet)
				{
					wd = partialRepo[id];

					wd.Processed = false;
					browser.Document.InvokeScript("undo", new object[] { id });
                    RestoreJunction(id);
				}
			}
			else
			{

				for (int col = 0; col < 3; col++)
				{
					if (workTree.SelectedNode.BackColor == napszakColors[col])
					{
						period = col;
						break;
					}
				}

				activeVehicle = findByInfo(workTree.SelectedNode.Name);
				group = (int)workTree.SelectedNode.Tag;

				WorkData[] delIds = activeVehicle.GetFuvarAt(period, group).ToArray();
				
				foreach (WorkData ma in delIds)
				{
					
					if (activeVehicle.RemoveFuvar(ma))
					{
						performedDelete = true;

                        UpdateLabelsWork(ma, true);

						browser.Document.InvokeScript("undo", new object[] { ma.Number });

						RestoreJunction(ma.Number);
					}
				}

				if (performedDelete)
				{
					AppLogger.WriteUnmapping(activeVehicle.Rendszam, group);

					if (leftTab.SelectedIndex == 0)
						UpdateStat();
					else
						UpdateCimlista();

					remaining = activeVehicle.SzabadCimek(activePeriod);
					availableWorkTxt.Text = remaining.ToString();

					FillSingleCarData();
					savedState++;
				}
			}

			groupCapacity = activeVehicle.Kapacitas;
			actualWorkSet.Clear();
			clickedGroup.Items.Clear();

		}

		

		private void dateRevBtn_Click(object sender, EventArgs e)
		{

			if (saveButton.Enabled)
			{
				switch (MessageBox.Show("A nem mentett hozzárendelések elvesznek.\nKíván először menteni?", "Megnyitás",
				MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
				{
					case DialogResult.Yes:
						aktuálisÁllapotMentéseToolStripMenuItem_Click(null, null);
						break;
					case DialogResult.Cancel:
						return;
				}
			}

			statlabel.Text = "Az adatok betöltése folyamatban...";

			using (DataUpdater updater = new DataUpdater(dateChooser.Value, dao)) {
				updater.FormClosing += new FormClosingEventHandler(LoadMapData);
				updater.ShowDialog();
			}
			
		}

		private void workTree_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
		{
			try
			{
				TreeNode sel = e.Node;
				workTree.SelectedNode = e.Node;
				while (sel.Parent != null)
					sel = sel.Parent;

				foreach (DataGridViewRow ro in statview.Rows)
				{
					if (ro.Cells[0].Value.ToString() == sel.Text)
						ro.Selected = true;
				}
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void fixateBtn_Click(object sender, EventArgs e)
		{

			if (statview.Tag != null)
			{
				Auto activeVehicle = (Auto)statview.Tag;

				if (actualWorkSet.Count > 0)
				{

					if (remaining < actualWorkSet.Count)
					{
						MessageBox.Show("Az aktív járműnek nincs elég szabad címe a napszakban.\nAz összeszívás nem lehetséges.", "Nincs szabad cím",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						fuvarTörléseToolStripMenuItem_Click(null, null);
						return;
					}

					if (groupCapacity > 0)
					{
						if (MessageBox.Show("A jármű tartályában " + groupCapacity + " m3-nyi hely maradt.\n Mégis lezárjam a fordulót?",
							"Szabad kapacitás maradt", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
							== DialogResult.No)
						{
							fuvarTörléseToolStripMenuItem_Click(null, null);
							return;
						}
					}
					if (groupCapacity < 0)
					{
						if (MessageBox.Show("A jármű kapacitása " + (-groupCapacity) + " m3-rel túl van terhelve.\n Mégis lezárjam a fordulót?",
							"Túlterhelés", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
							== DialogResult.No)
						{
							fuvarTörléseToolStripMenuItem_Click(null, null);
							return;
						}
					}

					int dist = Uthossz(actualWorkSet.ToArray());
					double limit = activeVehicle.Kapacitas <= WorkData.BigCapacityLimit ? Properties.Settings.Default.otkm : 
						Properties.Settings.Default.tizkm;

					if (limit > 0 && dist + activeVehicle.OsszTavolsag > limit)
					{
						if (MessageBox.Show("A jármű összes km értéke meghaladja a beállított limitet.\nFolytatja?",
							"Távolságlimit túllépés", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
						{
							fuvarTörléseToolStripMenuItem_Click(null, null);
							return;
						}
					}

					WorkData wd;
					List<WorkData> workGroup = new List<WorkData>();

					foreach (int tid in actualWorkSet)
					{
					
						wd = partialRepo[tid];

						workGroup.Add(wd);

                        UpdateLabelsWork(wd, false);
						
						AppLogger.WriteMapping(activeVehicle.Rendszam, wd.Cim);

						browser.Document.InvokeScript("hide", new object[] { tid, activeVehicle.Index, activeVehicle.NapszakForduloSzam(activePeriod) + 1});
						
					}

					if (actualWorkSet.Count > 0)
					{
						savedState++;
						activeVehicle.AddFuvar(workGroup, dist);

						remaining = activeVehicle.SzabadCimek(activePeriod);
						availableWorkTxt.Text = remaining.ToString();

						groupCapacity = activeVehicle.Kapacitas;

						foreach (int id in actualWorkSet)
						{
							RestoreJunction(id);
						}

                        if (activeVehicle.OsszSzabadCimek == 0)
                        {
                            WavPlayer.PlaySound(SoundType.AutóMegtelt);
                        }

						FillSingleCarData();
					}
					

					if (leftTab.SelectedIndex == 0)
						UpdateStat();
					else
						UpdateCimlista();

				}
			}
		
			actualWorkSet.Clear();
			clickedGroup.Items.Clear();

		}

        private void UpdateLabelsWork(WorkData wd, bool undo)
        {
            bool jozsa = wd.Jozsai;

            int unmapIndex = jozsa ? wd.Napszak + 2 : wd.Napszak - 1;
            int m3Index = jozsa ? 1 : 0;
            int nov = undo ? 1 : -1;
            int sum = 0;
            int a = unmapIndex / 3;

            
            if (wd.WorkCapacity <= WorkData.BigCapacityLimit)
            {
                unfive[unmapIndex] += nov;
                m3small[m3Index] += wd.WorkCapacity * nov;
                unFiveLabel[unmapIndex].Text = unfive[unmapIndex].ToString();
                
            }
            else
            {
                unbig[unmapIndex] += nov;
                m3big[m3Index] += wd.WorkCapacity * nov;
                unBigLabel[unmapIndex].Text = unbig[unmapIndex].ToString();
                
            }

        }

		private void elso_rad_Click(object sender, EventArgs e)
		{
			CheckAbandonState();
			activePeriod = 0;

			AppLogger.WriteEvent("Napszakváltás: ELSŐ FUVAR");
			NapszakSelect();
		}

		private void de_rad_Click(object sender, EventArgs e)
		{
			CheckAbandonState();
			activePeriod = 1;

			AppLogger.WriteEvent("Napszakváltás: DÉLELŐTT");
			NapszakSelect();

		}

		private void du_rad_Click(object sender, EventArgs e)
		{
			CheckAbandonState();
			activePeriod = 2;

			AppLogger.WriteEvent("Napszakváltás: DÉLUTÁN");
			NapszakSelect();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{

			if (savedState > 0)
			{
				switch (MessageBox.Show("Szeretné menteni a változásokat kilépés előtt?", "Mentés", MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Exclamation))
				{
					case DialogResult.Cancel:
						e.Cancel = true;
						return;
					case DialogResult.Yes:
						aktuálisÁllapotMentéseToolStripMenuItem_Click(null, null);
						break;
				}
				
			}

			CloseUp();
		}

		private void csvBtn_Click(object sender, EventArgs e)
		{
			Dictionary<int, WorkData> allData = fullRepo.GetOsszAdat();


			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.AddExtension = sfd.CheckPathExists = true;
				sfd.Filter = "CSV állomány (*.csv)|*.csv|Minden fájl (*.*)|*.*";
				sfd.InitialDirectory = "c:\\";
				sfd.FileName = "update.csv";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					string dateStr = dateChooser.Value.ToString("yyyy.MM.dd");
					using (TextWriter writer = new StreamWriter(sfd.FileName, false))
					{
						foreach (Auto veh in vehicles)
						{
							for (int period = 0; period < 3; period++)
							{
								foreach (WorkData wd in veh.OsszesMunkalap(period))
								{
									writer.WriteLine(string.Format("{0};{1};{2};", wd.WorksheetNumber, veh.Rendszam, dateStr));
									allData.Remove(wd.Number);
								}

							}
						}
						writer.Close();
					}

					if (allData.Count > 0)
					{
						using (MissingData md = new MissingData(allData, fullRepo.Length - allData.Count))
						{
							md.ShowDialog();
						}
					}
					else
					{
						MessageBox.Show(string.Format("{0}: a generálás kész", sfd.FileName), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

			}
			
		}

		private void bezárásToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void statview_SelectionChanged(object sender, EventArgs e)
		{
			Auto sel = null;
			try
			{
				if (vehicles.Count > 0 && statview.SelectedRows.Count > 0)
				{
					CheckAbandonState();

					sel = statview.SelectedRows[0].Cells[0].Value == null ? vehicles[0] :
						findByInfo(statview.SelectedRows[0].Cells[0].Value.ToString());

					statview.Tag = sel;

					remaining = sel.SzabadCimek(activePeriod);
					availableWorkTxt.Text = remaining.ToString();
					groupCapacity = sel.Kapacitas;

					driverTxt.Text = sel.Sofor;
					helperTxt.Text = sel.Seged;

					FillSingleCarData();

					if (infoÜzemmódToolStripMenuItem.Checked)
					{
						browser.Document.InvokeScript("showAutoInfo", new object[] { sel.Index });
					}
					
				}

				
			}
			catch (Exception ex)
			{
				
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void aktuálisÁllapotMentéseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (fileName == null)
				mentésMáToolStripMenuItem_Click(null, null);
			else
			{
				SaveState(fileName);
			}
			
		}

		private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (savedState > 0) {
				switch (MessageBox.Show("A nem mentett hozzárendelések elvesznek.\nKíván először menteni?", "Megnyitás", 
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
				{
					case DialogResult.Yes :
						aktuálisÁllapotMentéseToolStripMenuItem_Click(null, null);
						break;
					case DialogResult.Cancel:
						return;
				}
			}

			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				string last = Properties.Settings.Default.lastDir;

				ofd.AddExtension = ofd.CheckFileExists = ofd.CheckPathExists = true;
				ofd.Filter = "Kiosztási adatok (*.tmx)|*.tmx|Minden fájl (*.*)|*.*";
				ofd.InitialDirectory = last == null || last.Trim() == "" ? string.Format("{0}\\save", Application.StartupPath) : last;
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					tabControl1.SelectedIndex = 0;
					RestoreState(ofd.FileName);				
				}
			}
		}

		private void mentésMáToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.AddExtension = sfd.CheckPathExists = true;
				sfd.Filter = "Kiosztási adatok (*.tmx)|*.tmx|Minden fájl (*.*)|*.*";
				sfd.InitialDirectory = string.Format("{0}\\save", Application.StartupPath);
				sfd.FileName = fileName == null ? string.Format("{0}.tmx",  dateChooser.Value.ToString("yyyy_MM_dd")) : fileName;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					fileName = sfd.FileName;
					SaveState(fileName);
					
				}
				
			}
		}

		private void járművekBeállításaToolStripMenuItem_Click(object sender, EventArgs e)
		{

			fuvarTörléseToolStripMenuItem_Click(null, null);
			AppLogger.WriteEvent("Járműbeállítás");

			oldSelection = statview.SelectedRows[0].Index;

			using (CarDataGridPane grid = new CarDataGridPane(vehicles, summary, false, dao))
			{
				grid.BeforeKapacitasChg += new VoidDelegate(cargrid_BeforeKapacitasChg);
				grid.BeforeElsoFuvarChg += new VoidDelegate(cargrid_BeforeElsoFuvarChg);
				grid.BeforeDelelottChg += new VoidDelegate(cargrid_BeforeDelelottChg);
				grid.BeforeDelutanChg += new VoidDelegate(cargrid_BeforeDelutanChg);
				grid.BeforeRowDelete += new VoidDelegate(cargrid_BeforeRowDelete);
                grid.BeforeRowAdd += new EmptyDelegate(grid_BeforeRowAdd);

				if (grid.ShowDialog() == DialogResult.OK)
				{
					FillCarData();
					Auto activeVeh = (Auto)statview.Tag;
					
					remaining = activeVeh.SzabadCimek(activePeriod);
					availableWorkTxt.Text = remaining.ToString();

					if (leftTab.SelectedIndex == 0)
						UpdateStat();

				}
			}

            try
            {
                statview.Rows[oldSelection].Selected = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
		}

        void grid_BeforeRowAdd()
        {
            oldSelection = 0;
   
        }

		bool cargrid_BeforeRowDelete(Auto vehicle, int newVal)
		{
			bool ret = true;

			if (!vehicle.IsEmpty)
			{
				if (MessageBox.Show("A kiválasztott járműhöz rendelt címek fel lesznek szabadítva.\nFolytatja?",
					vehicle.Rendszam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					if (FindAutoIndex(vehicle.Info) > -1)
					{
						while (vehicle.OsszCim > 0)
						{
							try
							{

								workTree.SelectedNode = workTree.Nodes[0];

								if (workTree.SelectedNode != null)
								{
									fuvarTörléseToolStripMenuItem_Click(fuvarTörléseToolStripMenuItem, null);
									savedState++;
                                    oldSelection = 0;
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
				else
				{
					ret = false;
				}
			}
			return ret;
		}

		bool cargrid_BeforeDelutanChg(Auto vehicle, int newVal)
		{
			bool ret = true;
			if (vehicle.GetNapszakFordulok(2) > newVal)
			{
				if (MessageBox.Show("'Délután' értéke csökken. A meghaladó fuvarok címei fel lesznek szabadítva.\nFolytatja?",
					vehicle.Rendszam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					if (FindAutoIndex(vehicle.Info) > -1)
					{
						while (vehicle.NapszakFuvarDebCimek(2) > newVal)
						{
							try
							{

								workTree.SelectedNode = workTree.Nodes[workTree.Nodes.Count - 1];

								if (workTree.SelectedNode != null)
								{
									fuvarTörléseToolStripMenuItem_Click(fuvarTörléseToolStripMenuItem, null);
									savedState++;
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
				else
				{
					ret = false;
				}
			}
			
			return ret;
		}


		bool cargrid_BeforeDelelottChg(Auto vehicle, int newVal)
		{
			bool ret = true;

			if (vehicle.GetNapszakFordulok(1) > newVal)
			{
				if (MessageBox.Show("'Délelőtt' értéke csökken. A meghaladó fordulók címei fel lesznek szabadítva.\nFolytatja?",
					vehicle.Rendszam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					if (FindAutoIndex(vehicle.Info) > -1)
					{

						while (vehicle.NapszakFuvarDebCimek(1) > newVal)
						{
							try
							{

								workTree.SelectedNode = workTree.Nodes[groupIndex[2] - 1];

								if (workTree.SelectedNode != null)
								{
									fuvarTörléseToolStripMenuItem_Click(fuvarTörléseToolStripMenuItem, null);
									savedState++;
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
				else
				{
					ret = false;
				}
			}


			return ret;
		}

		bool cargrid_BeforeElsoFuvarChg(Auto vehicle, int newVal)
		{
			bool ret = true;
			if (vehicle.GetNapszakFordulok(0) > newVal)
			{
				if (MessageBox.Show("'Első fuvar' értéke csökken. A meghaladó fuvarok címei fel lesznek szabadítva.\nFolytatja?",
					vehicle.Rendszam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{

					if (FindAutoIndex(vehicle.Info) > -1)
					{
						while (vehicle.NapszakFuvarDebCimek(0) > newVal)
						{
							try
							{

								workTree.SelectedNode = workTree.Nodes[groupIndex[1] - 1];

								if (workTree.SelectedNode != null)
								{
									fuvarTörléseToolStripMenuItem_Click(fuvarTörléseToolStripMenuItem, null);
									savedState++;
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
				else
				{
					ret = false;
				}
			}

			return ret;
		}

		bool cargrid_BeforeKapacitasChg(Auto vehicle, int newVal)
		{
			bool ret = true;
			if (vehicle.Kapacitas > newVal)
			{
				if (MessageBox.Show("A jármű tartálymérete csökken.\nKívánja a járműhöz rendelt címeket felszabadítani?",
					vehicle.Rendszam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					if (FindAutoIndex(vehicle.Info) > -1)
					{
						while (vehicle.OsszCim > 0)
						{
							try
							{

								workTree.SelectedNode = workTree.Nodes[0];

								if (workTree.SelectedNode != null)
								{
									fuvarTörléseToolStripMenuItem_Click(fuvarTörléseToolStripMenuItem, null);
									savedState++;
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
				else
				{
					ret = false;
				}
			}
			
			return ret;
		}

		private void aktivak_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (clickedGroup.SelectedIndex > -1)
			{
				CimVariacio ma = (CimVariacio)clickedGroup.SelectedItem;

				clickedGroup.Items.RemoveAt(clickedGroup.SelectedIndex);

				actualWorkSet.Remove(ma.Id);

				groupCapacity += ma.Kob;

				partialRepo[ma.Id].Processed = false;
                
                browser.Document.InvokeScript("undo", new object[] { ma.Id });
                RestoreJunction(ma.Id);
			}
		}

		private void aktivak_Format(object sender, ListControlConvertEventArgs e)
		{
			e.Value = ((CimVariacio)e.ListItem).Cim;
		}

		private void beállításokToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			using (SettingsPanel sp = new SettingsPanel())
			{
				if (sp.ShowDialog() == DialogResult.OK)
				{
					UpdateStat();
                    soundButton.Checked = Properties.Settings.Default.hangoskodik;
				}
			}
		}

		private void leftTab_Selecting(object sender, TabControlCancelEventArgs e)
		{
			switch (e.TabPageIndex)
			{
				case 0:
					UpdateStat();
					break;
				case 1:
					UpdateCimlista();
					break;
			}
		}

		private void cimGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				CimVariacio ma = (CimVariacio)cimGrid[0, e.RowIndex].Value;
				e.Value = ma.Info;

				if (ma.Check)
				{
					e.CellStyle.ForeColor = Color.Red;

				}
			}
			else
			{
				e.Value = cimGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
			}
			e.FormattingApplied = true;
		}

		private void cimGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			switch (e.Column.Index)
			{
				case 0:
					CimVariacio v1 = (CimVariacio)e.CellValue1;
					CimVariacio v2 = (CimVariacio)e.CellValue2;

					e.SortResult = v1.Cim.CompareTo(v2.Cim);

					break;
				case 1:
					int i1 = (int)e.CellValue1,
						i2 = (int)e.CellValue2;
					e.SortResult = i1.CompareTo(i2);
					break;

			}
			e.Handled = true;
		}

		private void kiválasztToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cimGrid.SelectedRows.Count > 0)
			{
				CimVariacio ma = (CimVariacio)cimGrid.SelectedRows[0].Cells[0].Value;
				AddFuvar(ma, true);
			}
		}

		private void lezárToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cimGrid.SelectedRows.Count > 0)
			{
				CimVariacio ma = (CimVariacio)cimGrid.SelectedRows[0].Cells[0].Value;
				AddFuvar(ma, false);
				fixateBtn_Click(fixateBtn, null);
			}
		}	

		private void statview_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			try
			{
				Auto a1 = findByInfo(statview[0, e.RowIndex1].Value.ToString()),
					 a2 = findByInfo(statview[0, e.RowIndex2].Value.ToString());
				switch (e.Column.Index)
				{
					case 0:
						e.SortResult = a1.Rendszam.CompareTo(a2.Rendszam);
						break;
					case 1:
						e.SortResult = a1.OsszM3.CompareTo(a2.OsszM3);
						break;
					case 2:
						e.SortResult = a1.OsszCim.CompareTo(a2.OsszCim);
						break;
					case 3:
						e.SortResult = a1.OsszTavolsag.CompareTo(a2.OsszTavolsag);
						break;
					case 4:
						e.SortResult = a1.Csohossz.CompareTo(a2.Csohossz);
						break;
					case 5:
						e.SortResult = a1.OsszKoltseg.CompareTo(a2.OsszKoltseg);
						break;
					case 6:
						e.SortResult = a1.CumiTenyezo.CompareTo(a2.CumiTenyezo);
						break;
					case 7:
						e.SortResult = a1.MikorVegezStr.CompareTo(a2.MikorVegezStr);
						break;
				}

				e.Handled = true;
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

        private void smallToGoEFJo_TextChanged(object sender, EventArgs e)
        {
            int sumbig = 0, sumfive = 0;
            for (int period = 3; period < unfive.Length; period++)
            {
                sumbig += unbig[period];
                sumfive += unfive[period];
                unmapLabel[period].Text = (unfive[period] + unbig[period]).ToString();
            }
            smallToGoOsszJo.Text = sumfive.ToString();
            smallToGoM3Jo.Text = m3small[1].ToString();
            allToGoOsszJo.Text = (sumbig + sumfive).ToString();
            allToGoM3Jo.Text = (m3small[1] + m3big[1]).ToString();
        }

        private void bigToGoEFJo_TextChanged(object sender, EventArgs e)
        {
            int sumbig = 0, sumfive = 0;
            for (int period = 3; period < unfive.Length; period++)
            {
                sumbig += unbig[period];
                sumfive += unfive[period];
                unmapLabel[period].Text = (unfive[period] + unbig[period]).ToString();
            }
            bigToGoOsszJo.Text = sumbig.ToString();
            bigToGoM3Jo.Text = m3big[1].ToString();
            allToGoOsszJo.Text = (sumbig + sumfive).ToString();
            allToGoM3Jo.Text = (m3small[1] + m3big[1]).ToString();
        }

		private void mutatATérképenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cimGrid.SelectedRows.Count > 0)
			{
				CimVariacio ma = (CimVariacio)cimGrid.SelectedRows[0].Cells[0].Value;
				browser.Document.InvokeScript("centerTo", new object[] { ma.Id, ma.Cim });
			}
		}

		private void eredetiRendezésVisszaállításaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			vehicles.Sort(new Comparison<Auto>(Auto.CompareByKapacitas));

			statview.Rows.Clear();

			int rowCnt = 0;
			foreach (Auto veh in vehicles)
			{
				statview.Rows.Add();

				if (veh.IsJozsaiAuto)
				{
					statview.Rows[rowCnt].DefaultCellStyle.ForeColor = Color.Red;
				}

				if (veh.KettenUlnek)
				{
					statview.Rows[rowCnt].DefaultCellStyle.Font = boldFont;
				}

				rowCnt++;
			}
			UpdateStat();
		}

		private void turmixLogisztikaSúgóToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, Application.StartupPath + Properties.Settings.Default.helpPath, HelpNavigator.TopicId, "9");
		}

		private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			Help.ShowHelp(this, Application.StartupPath + Properties.Settings.Default.helpPath, HelpNavigator.TopicId, "2");
		}

		private void cimGrid_MouseClick(object sender, MouseEventArgs e)
		{
			

			System.Windows.Forms.DataGridView.HitTestInfo hitTest = cimGrid.HitTest(e.X, e.Y);

			if (hitTest.Type == DataGridViewHitTestType.Cell)
			{

				if (!((DataGridViewRow)(cimGrid.Rows[hitTest.RowIndex])).Selected)
				{
					cimGrid.ClearSelection();

					((DataGridViewRow)cimGrid.Rows[hitTest.RowIndex]).Selected = true;

				}

				CimVariacio ma = (CimVariacio)cimGrid[0, hitTest.RowIndex].Value;
				ShowInfo(ma.Id);

				if (e.Button == MouseButtons.Right)
				{
					errorStrip.Show(cimGrid.PointToScreen(e.Location));
				}
			}
			
		}


		private void fontBtn_Click(object sender, EventArgs e)
		{
			using (FontDialog fd = new FontDialog())
			{
				fd.FontMustExist = true;
				fd.Font = printFont;
				if (fd.ShowDialog() == DialogResult.OK)
				{
					printFont = fd.Font;
				}
			}
		}

		private void prBtn_Click(object sender, EventArgs e)
		{
			using (PrintTemplate pt = new PrintTemplate())
			{
				pt.Font = printFont;
				pt.PrintCars(vehicles, fullRepo, dateChooser.Value, pageSettings, true);
			}
			
		}

		private void printBtn_Click(object sender, EventArgs e)
		{
			using (PrintTemplate pt = new PrintTemplate())
			{
				pt.Font = printFont;
				pt.PrintStat(vehicles, dateChooser.Value, pageSettings, true);

			}
		}

        private void printGyujtoBtn_Click(object sender, EventArgs e)
        {
            using (PrintTemplate pt = new PrintTemplate())
            {
                pt.Font = printFont;
                pt.PrintCars(vehicles, fullRepo, dateChooser.Value, pageSettings, false);

            }
        }

		private void sideBtn_Click(object sender, EventArgs e)
		{
			using (PageSetupDialog psd = new PageSetupDialog())
			{
				psd.PageSettings = pageSettings;
				psd.AllowPrinter = false;

				if (psd.ShowDialog() == DialogResult.OK)
				{
					pageSettings = psd.PageSettings;
				}

			}
		}

		private void kism3Unmap_TextChanged(object sender, EventArgs e)
		{
            //allToGoM3Deb.Text = (m3small[0] + m3big[0]).ToString();
		}

		private void jstat_Click(object sender, EventArgs e)
		{
			using (PrintTemplate pt = new PrintTemplate())
			{
				pt.Font = printFont;
				pt.PrintStat(vehicles, dateChooser.Value, pageSettings, true);

			}
		}

		private void munkalapszámLátszikAListábanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WorkData.ShowWorksheetNumber = munkalapszámLátszikAListábanToolStripMenuItem.Checked;

			if (workTree.Nodes.Count > 0)
			{
				FillCarData();
				if (leftTab.SelectedIndex == 1)
					UpdateCimlista();
				else
					UpdateStat();
			}
		}

		private void statprev_Click(object sender, EventArgs e)
		{
			using (PrintTemplate pt = new PrintTemplate())
			{
				pt.Font = printFont;
				pt.PrintStat(vehicles, dateChooser.Value, pageSettings, false);

			}
		}

		private void munkaPrintBtn_Click(object sender, EventArgs e)
		{
			using (MunkalapSelector sel = new MunkalapSelector(vehicles, fullRepo))
			{
				sel.FormClosing += new FormClosingEventHandler(sel_FormClosing);
				sel.ShowDialog();
			}
			
		}

		void sel_FormClosing(object sender, FormClosingEventArgs e)
		{
			MunkalapSelector sel = sender as MunkalapSelector;

			if (sel.DialogResult == DialogResult.OK)
			{
				using (PrintProgress pp = new PrintProgress(sel.MunkaLista))
				{
					DialogResult rd = pp.ShowDialog();
					if (rd != DialogResult.Cancel)
					{
						try
						{
							System.Diagnostics.Process.Start("acrord32.exe", string.Format("{0}\\munkalapok.pdf", Environment.GetFolderPath
    (Environment.SpecialFolder.DesktopDirectory)));
						}
						catch (Exception ex)
						{
							MessageBox.Show("Az előnézet megnyitása nem sikerült.\nEllenőrizze, hogy az Acrobat Reader program elérhető-e.",
								"Előnézet megnyitása nem sikerült", MessageBoxButtons.OK, MessageBoxIcon.Error);

							AppLogger.WriteException(ex);
							AppLogger.WriteEvent("A kivétel elkapva.");
						}
					}
				}
			}
		}

		private void infoÜzemmódToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (statview.Tag != null)
			{
				browser.Document.InvokeScript("toggleInfoMode", new object[] { infoÜzemmódToolStripMenuItem.Checked });

				if (infoÜzemmódToolStripMenuItem.Checked)
					browser.Document.InvokeScript("showAutoInfo", new object[] { ((Auto)statview.Tag).Index });
			}
		}

		private void settings_btn_Click(object sender, EventArgs e)
		{
			járművekBeállításaToolStripMenuItem_Click(null, null);
		}

		private void nagyauto_rad_Click(object sender, EventArgs e)
		{
			visibleGroup = (int)((ToolStripButton)sender).Tag;
			for (int period = 0; period < 3; period++)
			{
				radios[period].Checked = period == visibleGroup;
			}
			browser.Document.InvokeScript("showAutos", new object[] { visibleGroup });
			if (leftTab.SelectedIndex == 1)
				UpdateCimlista();
			
			CheckImageState();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			megnyitásToolStripMenuItem_Click(null, null);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{

			aktuálisÁllapotMentéseToolStripMenuItem_Click(null, null);
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			beállításokToolStripMenuItem1_Click(null, null);
		}

		private void aTurmixLogisztikaNévjegyeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (AboutTurmixLog about = new AboutTurmixLog())
			{
				about.ShowDialog();
			}
		}

		private void címekSzerkesztéseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (ProblemAddressPanel pma = new ProblemAddressPanel(fullRepo))
			{
				pma.FormClosing += new FormClosingEventHandler(pma_FormClosing);
				pma.ShowDialog();
			}
		}

		void pma_FormClosing(object sender, FormClosingEventArgs e)
		{
			ProblemAddressPanel pma = sender as ProblemAddressPanel;
			if (pma.DialogResult == DialogResult.OK)
			{
				WorkData wd;
				foreach (int id in pma.ModifiedIds)
				{
					wd = fullRepo.Find(id);
					browser.Document.InvokeScript("setProblematic", new object[] { id, wd.Problematic });
				}
				CheckImageState();
			}
		}

		private void koordinátákFelvételeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (koordinátákFelvételeToolStripMenuItem.Checked)
			{
				browser.Document.InvokeScript("beginAdditiveMode");
			}
			else
			{
				browser.Document.InvokeScript("endAdditiveMode");
			}
		}

		private void térképVisszaállításaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			browser.Document.InvokeScript("centerMap");
		}

		private void járművekToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (AutoAdatPanel aap = new AutoAdatPanel())
			{
				aap.ShowDialog();
			}
		}

		private void koordinátákToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (LatLngPanel llp = new LatLngPanel())
			{
                llp.FormClosing += new FormClosingEventHandler(llp_FormClosing);
				llp.ShowDialog();
			}
		}

        void llp_FormClosing(object sender, FormClosingEventArgs e)
        {
            LatLngPanel llp = sender as LatLngPanel;
            
            if (llp.DialogResult == DialogResult.OK)
            {
                foreach (WorkData wd in nulls)
                {
                    dao.GetLatLngProb(wd);
                }
                AddUpdatedCoordsToMap();
            }
        }

        private void AddUpdatedCoordsToMap()
        {
            List<WorkData> delete = new List<WorkData>();
            foreach (WorkData data in nulls)
            {
                if (data.Lat > 0 && data.Lng > 0)
                {
                    delete.Add(data);
                    LoadMarker(data);
                }
            }
            foreach (WorkData wd in delete)
            {
                nulls.Remove(wd);
            }
            if (leftTab.SelectedIndex == 1)
            {
                UpdateCimlista();
            }
            nomapButton.Visible = nulls.Count > 0;
        }

		private void problémásCímekToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (ProblemCimPanel pcp = new ProblemCimPanel())
			{
				pcp.ShowDialog();
			}
		}

		private void ténylegesM3AdatokToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (TenylegesM3Panel tmp = new TenylegesM3Panel())
			{
				tmp.ShowDialog();
			}
		}

		private void alertGroup_Click(object sender, EventArgs e)
		{	
			browser.Document.InvokeScript("showProblemGroup", new object[] { alertGroup.Checked });
			if (leftTab.SelectedIndex == 1)
				UpdateCimlista();

			CheckImageState();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
            
			if (Properties.Settings.Default.panelH > 0)
				splitContainer1.SplitterDistance = Properties.Settings.Default.panelH;
			if (Properties.Settings.Default.cimlistaW > 0)
				bottomSplit.SplitterDistance = Properties.Settings.Default.cimlistaW;
			if (Properties.Settings.Default.listaH > 0)
				splitContainer2.SplitterDistance = Properties.Settings.Default.listaH;
		}

		private void állandóProblémásUtcákToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (ProblemUtcaPanel tmp = new ProblemUtcaPanel())
			{
				tmp.ShowDialog();
			}
		}

		private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
           
			if (tabControl1.SelectedIndex == 1)
			{
                if (allToGoOsszDeb.Text != "0" &&
                    MessageBox.Show("Még van cím, amely nincs kiosztva!\n Mégis folytatja?", "Kiosztatlan címek",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                
				StringBuilder sb = new StringBuilder("A következő járművekhez nincs cím rendelve.\nMégis folytatja?\n");
				bool volt = false;
				foreach (Auto a in vehicles)
				{
					if (a.IsEmpty)
					{
						sb.AppendLine(a.Rendszam);
						volt = true;
					}
				}
				if (volt)
				{
                    e.Cancel = MessageBox.Show(sb.ToString(), "Üres járművek", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) 
                        == DialogResult.No;
				}
               
			}
		}

        private void soundButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.hangoskodik = soundButton.Checked;
            Properties.Settings.Default.Save();
        }

        private void nemMegjeleníthetőCímekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ZeroLatLng zll = new ZeroLatLng(nulls, dao))
            {
                zll.FormClosing += new FormClosingEventHandler(zll_FormClosing);
                zll.BeginCoordinateEdit += new CoordinateClickDelegate(zll_BeginCoordinateEdit);
                zll.ShowDialog();
            }
        }

        void zll_BeginCoordinateEdit(int id, string utca)
        {
            koordinátákFelvételeToolStripMenuItem.Checked = true;
            browser.Document.InvokeScript("beginAdditiveMode", new object[] { id, utca });
        }

        void zll_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddUpdatedCoordsToMap();
        }

        private void FoldutFinished(object sender, HtmlElementEventArgs e)
        {
            string utca = (string)browser.Document.InvokeScript("getUtca");
            if (utca != null)
            {
                try
                {
                    double dist = (double)browser.Document.InvokeScript("getDistance");
                    string[] coords = ((string)browser.Document.InvokeScript("getAddCoords")).Split('&');
                    
                    dao.UpdateFoldRow(utca, double.Parse(coords[0], numberFormat), double.Parse(coords[1], numberFormat), 
                        (int)Math.Round(dist / 1000));

                    browser.Document.InvokeScript("endAdditiveMode");
                    //földútpontokMódosításaToolStripMenuItem.Checked = false;
                    földútpontokMódosításaToolStripMenuItem_Click(null, null);                   
                    
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void AddingFinished(object sender, EventArgs e)
        {

            int idInt = (int)browser.Document.InvokeScript("getAddId");
            if (idInt != -1)
            {
                try
                {
                    string[] coords = ((string)browser.Document.InvokeScript("getAddCoords")).Split('&');
                    WorkData wd = fullRepo.Find(idInt);
                    WorkData tmpData;
                    wd.Lat = double.Parse(coords[0], numberFormat);
                    wd.Lng = double.Parse(coords[1], numberFormat);
                    List<WorkData> del = new List<WorkData>();
                    foreach (WorkData nd in nulls)
                    {
                        if (nd.Utca == wd.Utca)
                        {
                            tmpData = fullRepo.Find(nd.Number);
                            tmpData.Lat = nd.Lat = wd.Lat;
                            tmpData.Lng = nd.Lng = wd.Lng;
                            //del.Add(nd);
                        }
                    }
                   
                    nemMegjeleníthetőCímekToolStripMenuItem_Click(null, null);
                    browser.Document.InvokeScript("endAdditiveMode");
                    koordinátákFelvételeToolStripMenuItem.Checked = false;
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                try
                {
                    string[] coords = ((string)browser.Document.InvokeScript("getAddCoordsRaw")).Split('&');
                    dao.InsertLatLng(coords[0].Trim().ToUpper(), double.Parse(coords[1], numberFormat), double.Parse(coords[2], numberFormat));
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void munkalapAdatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MunkalapPanel mp = new MunkalapPanel(fullRepo, dao))
            {
                mp.OnNapszakChange += new IdPassDelegate(mp_OnNapszakChange);
                mp.OnProbChange += new ProblemPassDelegate(mp_OnProbChange);
                mp.OnStreetChange += new IdPassDelegate(mp_OnStreetChange);
                mp.ShowDialog();

            }
        }

        void mp_OnStreetChange(int id)
        {
            WorkData wd = fullRepo.Find(id);
            LoadMarker(wd);
        }

        void mp_OnProbChange(int id, bool prob)
        {
            browser.Document.InvokeScript("setProblematic", new object[] { id, prob });
            RestoreJunction(id);
        }

        void mp_OnNapszakChange(int id)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (dao.Connection == null || dao.Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Az adatbázis nem érhető el.\nA program csak CSV exportra és nyomtatásra alkalmas így", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
            }
        }

        private void allToGoEFDeb_TextChanged(object sender, EventArgs e)
        {

        }

        private void smallToGoM3Jo_TextChanged(object sender, EventArgs e)
        {
            //allToGoM3Jo.Text = (m3small[1] + m3big[1]).ToString();
        }

        private void smallToGoEFDeb_TextChanged(object sender, EventArgs e)
        {

            int sumbig = 0, sumfive = 0;
            for (int period = 0; period < 3; period++)
            {
                sumbig += unbig[period];
                sumfive += unfive[period];
                unmapLabel[period].Text = (unfive[period] + unbig[period]).ToString();
            }
            smallToGoOsszDeb.Text = sumfive.ToString();
            smallToGoM3Deb.Text = m3small[0].ToString();
            allToGoOsszDeb.Text = (sumbig + sumfive).ToString();
            allToGoM3Deb.Text = (m3small[0] + m3big[0]).ToString();

        }

        private void bigToGoEFDeb_TextChanged(object sender, EventArgs e)
        {
            int sumbig = 0, sumfive = 0;
            for (int period = 0; period < 3; period++)
            {
                sumbig += unbig[period];
                sumfive += unfive[period];
                unmapLabel[period].Text = (unfive[period] + unbig[period]).ToString();
            }
            bigToGoOsszDeb.Text = sumbig.ToString();
            bigToGoM3Deb.Text = m3big[0].ToString();
            allToGoOsszDeb.Text = (sumbig + sumfive).ToString();
            allToGoM3Deb.Text = (m3small[0] + m3big[0]).ToString();
        }

        private void földútpontokMódosításaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (földútpontokMódosításaToolStripMenuItem.Checked)
            {
                using (FoldutPanel fp = new FoldutPanel())
                {
                    fp.FormClosed += new FormClosedEventHandler(fp_FormClosed);
                    fp.BeginCoordinateEdit += new FoldutDelegate(fp_BeginCoordinateEdit);
                    fp.ShowDialog();
                }
            }
            else
            {
                browser.Document.InvokeScript("endAdditiveMode");
            }
        }

        void fp_FormClosed(object sender, FormClosedEventArgs e)
        {
            FoldutPanel fp = sender as FoldutPanel;

            if (fp.DialogResult == DialogResult.OK)
            {
                dao.GetFoldLatLng(fullRepo.GetOsszList());
                if (leftTab.SelectedIndex == 0)
                {
                    UpdateStat();
                }
                else
                {
                    UpdateBottomPanel();
                }
            }
            if (fp.DialogResult != DialogResult.Abort)
                földútpontokMódosításaToolStripMenuItem.Checked = false;
        }

        void fp_BeginCoordinateEdit(string utca, double flat, double flng)
        {
            GLatLng streetCoord = dao.GetLatLng(utca);
            browser.Document.InvokeScript("beginFoldAdditiveMode", new object[] { utca, streetCoord.Lat, streetCoord.Lng, flat, flng });
        }

        private void statPdf_Click(object sender, EventArgs e)
        {
            using (PrintTemplate pt = new PrintTemplate())
            {
                pt.Font = printFont;
                pt.statToPDF(vehicles, dateChooser.Value);

            }
        }

        private void browser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void gyujtoPDFBtn_Click(object sender, EventArgs e)
        {
            using (PrintTemplate pt = new PrintTemplate())
            {
                pt.Font = printFont;
                pt.gyujtoToPDF(vehicles, dateChooser.Value);

            }
        }

	}
}
