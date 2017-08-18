using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixLog
{
	public delegate bool VoidDelegate(Auto auto, int newVal);

	public partial class CarDataGridPane : Form
	{

        private KiosztasDao dao;
		private List<Auto> cars;
		
		private Auto select;
		private bool cancel;

		private Font boldStyle;

		private int[] atlag5 = new int[3], atlag10 = new int[3];

		internal event VoidDelegate BeforeKapacitasChg;
		internal event VoidDelegate BeforeElsoFuvarChg;
		internal event VoidDelegate BeforeDelelottChg;
		internal event VoidDelegate BeforeDelutanChg;
		internal event VoidDelegate BeforeRowDelete;
        internal event EmptyDelegate BeforeRowAdd;

		private CimOsszesito cimosz;

		private Comparison<Auto> kapCompare;

		private DataGridViewRow kisOsszeg, nagyOsszeg;

		public CarDataGridPane(List<Auto> autok, CimOsszesito osszCim, bool stat, KiosztasDao dao)
		{
			InitializeComponent();

            this.dao = dao;
			boldStyle = new Font(goodcars.Font, FontStyle.Bold);

			cars = autok;
			cimosz = osszCim;

			kisOsszeg = new DataGridViewRow();
			kisOsszeg.ReadOnly = true;
			kisOsszeg.DefaultCellStyle.BackColor = Color.AntiqueWhite;
			nagyOsszeg = new DataGridViewRow();
			nagyOsszeg.ReadOnly = true;
			nagyOsszeg.DefaultCellStyle.BackColor = Color.AntiqueWhite;

			for (int a = 0; a < 6; a++)
			{
				kisOsszeg.Cells.Add(new DataGridViewTextBoxCell());
				nagyOsszeg.Cells.Add(new DataGridViewTextBoxCell());
			}
			kisOsszeg.Cells[0].Value = "Kis címek összesen";
			nagyOsszeg.Cells[0].Value = "Nagy címek összesen";

			allElsoLE5.Text = cimosz.ElsoLE5.ToString();
			allDELE5.Text = cimosz.DeLE5.ToString();
			allDULE5.Text = cimosz.DuLE5.ToString();
			allLE5.Text = cimosz.OsszLE5.ToString();
            allSDeb.Text = cimosz.OsszLE5Deb.ToString();
            allSJo.Text = cimosz.OsszLE5Jozsa.ToString();

			osszElsoDeb.Text = cimosz.ElsofuvarOsszDeb.ToString();
			osszDeDeb.Text = cimosz.DelelottOsszDeb.ToString();
			osszDuDeb.Text = cimosz.DelutanOsszDeb.ToString();
            allDeb.Text = cimosz.OsszDebrecen.ToString();

			allElsoN.Text = cimosz.ElsoTizes.ToString();
			allDEN.Text = cimosz.DeTizes.ToString();
			allDUN.Text = cimosz.DuTizes.ToString();
			allN.Text = cimosz.OsszTizes.ToString();
            allNDeb.Text = cimosz.OsszTizesDeb.ToString();
            allNJo.Text = cimosz.OsszTizesJozsa.ToString();

			osszElsoJo.Text = cimosz.ElsofuvarOsszJozsa.ToString();
			osszDeJo.Text = cimosz.DelelottOsszJozsa.ToString();
			osszDuJo.Text = cimosz.DelutanOsszJozsa.ToString();
			allJo.Text = cimosz.OsszJozsai.ToString();

            allelso.Text = cimosz.Elsofuvar.ToString();
            allde.Text = cimosz.Delelott.ToString();
            alldu.Text = cimosz.Delutan.ToString();
            allall.Text = cimosz.OsszEgesz.ToString();

            elsoSDeb.Text = cimosz.ElsofuvarKisDeb.ToString();
            elsoSJo.Text = cimosz.ElsoLE5Jo.ToString();
            deSDeb.Text = cimosz.DelelottKisDeb.ToString();
            deSJo.Text = cimosz.DeLE5Jo.ToString();
            duSDeb.Text = cimosz.DelutanKisDeb.ToString();
            duSJo.Text = cimosz.DuLE5Jo.ToString();

            elsoNDeb.Text = cimosz.ElsofuvarNagyDeb.ToString();
            elsoNJo.Text = cimosz.ElsoTizesJozsa.ToString();
            deNDeb.Text = cimosz.DelelottNagyDeb.ToString();
            deNJo.Text = cimosz.DeTizesJozsa.ToString();
            duNDeb.Text = cimosz.DelutanNagyDeb.ToString();
            duNJo.Text = cimosz.DuTizesJozsa.ToString();

			kapCompare = new Comparison<Auto>(Auto.CompareByKapacitas);

			if (stat)
				DoCarStatx();
			DoCarUpdate();

			

			goodcars.CellEndEdit += new DataGridViewCellEventHandler(goodcars_CellEndEdit);

		}

		void goodcars_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{

			try
			{

				string val = goodcars[e.ColumnIndex, e.RowIndex].Value == null ? "0" : goodcars[e.ColumnIndex, e.RowIndex].Value.ToString();
				int intVal;
				float floatVal;

				if (select == null)
					return;

				switch (e.ColumnIndex)
				{

					case 1:
						try
						{
							intVal = int.Parse(val);

							if (intVal < 0)
							{
								MessageBox.Show("'Tartályméret' értéke nem lehet negatív", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw new FormatException();
							}

							/*if (select.IsJozsaiAuto && intVal < select.Kapacitas)
							{
								MessageBox.Show("A jármű tartálymérete nem csökkenthető, mivel a jármű fel nem szabadítható címeket szolgál ki.", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw new FormatException();
							}*/

							if (BeforeKapacitasChg != null && !BeforeKapacitasChg(select, intVal))
								throw new FormatException();

							AppLogger.WriteAutoChange(select.Rendszam, "Tartályméret", select.Kapacitas.ToString(), intVal.ToString());

							select.Kapacitas = intVal;
						}
						catch (FormatException)
						{
							goodcars[e.ColumnIndex, e.RowIndex].Value = select.Kapacitas;
						}

						DoCarUpdate();

						break;
					case 2:
						try
						{
							intVal = int.Parse(val);

							if (intVal < 0)
							{
								MessageBox.Show("'Első fuvar' értéke nem lehet negatív", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw new FormatException();
							}

							if (BeforeElsoFuvarChg != null && !BeforeElsoFuvarChg(select, intVal))
								throw new FormatException();

							AppLogger.WriteAutoChange(select.Rendszam, "Első fuvar", select.GetNapszakFordulok(0).ToString(), intVal.ToString());

                            select.SetNapszakFordulok(0, intVal);
							if (select.IsJozsaiAuto)
							{
								goodcars[2, e.RowIndex].Value = string.Format("{0} [{1}]", select.GetNapszakFordulok(0), select.GetNapszakJozsa(0));
								goodcars[Osszfuvar.Index, e.RowIndex].Value = string.Format("{0} [{1}]", select.OsszFordulo, select.OsszCimJozsa);
							}
							else
							{
								goodcars[Osszfuvar.Index, e.RowIndex].Value = select.OsszFordulo;
							}

							DoSumma();
						}
						catch (FormatException)
						{
                            if (select.IsJozsaiAuto)
                            {
                                goodcars[2, e.RowIndex].Value = string.Format("{0} [{1}]", select.GetNapszakFordulok(0), select.GetNapszakJozsa(0));
                            }
                            else
                            {
                                goodcars[Osszfuvar.Index, e.RowIndex].Value = select.OsszFordulo;
                            }
						}
						break;
					case 3:
						try
						{
							intVal = int.Parse(val);

							if (intVal < 0)
							{
								MessageBox.Show("'Délelőtt' értéke nem lehet negatív", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw new FormatException();
							}

							if (BeforeDelelottChg != null && !BeforeDelelottChg(select, intVal))
								throw new FormatException();

							AppLogger.WriteAutoChange(select.Rendszam, "Délelőtt", select.GetNapszakFordulok(1).ToString(), intVal.ToString());

							select.SetNapszakFordulok(1, intVal);

							if (select.IsJozsaiAuto)
							{
								goodcars[3, e.RowIndex].Value = string.Format("{0} [{1}]", select.GetNapszakFordulok(1), select.GetNapszakJozsa(1));
								goodcars[Osszfuvar.Index, e.RowIndex].Value = string.Format("{0} [{1}]", select.OsszFordulo, select.OsszCimJozsa);
							}
							else
							{
								goodcars[Osszfuvar.Index, e.RowIndex].Value = select.OsszFordulo;
							}

							DoSumma();
						}
						catch (FormatException)
						{
                            if (select.IsJozsaiAuto)
                            {
                                goodcars[3, e.RowIndex].Value = string.Format("{0} [{1}]", select.GetNapszakFordulok(1), select.GetNapszakJozsa(1));
                            }
                            else
                            {
                                goodcars[Osszfuvar.Index, e.RowIndex].Value = select.OsszFordulo;
                            }
						}
						break;
					case 4:
						try
						{
							intVal = int.Parse(val);

							if (intVal < 0)
							{
								MessageBox.Show("'Délután' értéke nem lehet negatív", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw new FormatException();
							}

							if (BeforeDelutanChg != null && !BeforeDelutanChg(select, intVal))
								throw new FormatException();

							AppLogger.WriteAutoChange(select.Rendszam, "Délután", select.GetNapszakFordulok(2).ToString(), intVal.ToString());

							select.SetNapszakFordulok(2, intVal);

							if (select.IsJozsaiAuto)
							{
								goodcars[4, e.RowIndex].Value = string.Format("{0} [{1}]", select.GetNapszakFordulok(2), select.GetNapszakJozsa(2));
								goodcars[Osszfuvar.Index, e.RowIndex].Value = string.Format("{0} [{1}]", select.OsszFordulo, select.OsszCimJozsa);
							}
							else
							{
								goodcars[Osszfuvar.Index, e.RowIndex].Value = select.OsszFordulo;
							}

							DoSumma();
						}
						catch (FormatException)
						{
                            if (select.IsJozsaiAuto)
                            {
                                goodcars[4, e.RowIndex].Value = string.Format("{0} [{1}]", select.GetNapszakFordulok(2), select.GetNapszakJozsa(2));
                            }
                            else
                            {
                                goodcars[Osszfuvar.Index, e.RowIndex].Value = select.OsszFordulo;
                            }
						}
						break;
					case 7:
						try
						{
							floatVal = float.Parse(val);

							if (floatVal < 0)
							{
								MessageBox.Show("'Fogyasztás' értéke nem lehet negatív", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw new FormatException();
							}

							AppLogger.WriteAutoChange(select.Rendszam, "Fogyasztás", select.Fogyasztas.ToString(), floatVal.ToString());

							select.Fogyasztas = floatVal;
							goodcars[osszkoltseg.Index, e.RowIndex].Value = (select.Lizingdij + select.Ber) / Properties.Settings.Default.workDays;
						}
						catch (FormatException)
						{
							goodcars[e.ColumnIndex, e.RowIndex].Value = select.Fogyasztas;
						}
						break;
					case 8:
						try
						{
							floatVal = float.Parse(val);

							if (floatVal < 0)
							{
								MessageBox.Show("'Lízing' értéke nem lehet negatív", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw new FormatException();
							}

							AppLogger.WriteAutoChange(select.Rendszam, "Lízing", select.Lizingdij.ToString(), floatVal.ToString());

							select.Lizingdij = floatVal;
							goodcars[osszkoltseg.Index, e.RowIndex].Value = (select.Lizingdij + select.Ber) / Properties.Settings.Default.workDays;
							goodcars.CurrentCell.Value = floatVal / Properties.Settings.Default.workDays;
						}
						catch (FormatException)
						{
							goodcars[e.ColumnIndex, e.RowIndex].Value = select.Lizingdij;
						}
						break;
				}
			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private bool Duplicate(string val)
		{
			foreach (Auto a in cars)
			{
				if (a.Rendszam == val)
					return true;
			}
			return false;
		}

		

		private int CompareByKoltseg(Auto egy, Auto mas)
		{
            if (egy.KettenUlnek && mas.KettenUlnek)
                return 0;
            if (!egy.KettenUlnek && !mas.KettenUlnek)
            {
                return -egy.KoltsegTenyezo.CompareTo(mas.KoltsegTenyezo);
            }
            return egy.KettenUlnek ? -1 : 1;
		}

		private void DoCarUpdate()
		{
			goodcars.Rows.Clear();
			swapCombo.Items.Clear();

			cars.Sort(kapCompare);
			int a = 0, kicsi = 0, nagy = 0;

			float tBer, tLizing;

			for (; a < cars.Count; a++)
			{
				goodcars.Rows.Add();

				if (cars[a].IsJozsaiAuto)
				{
					goodcars.Rows[a].DefaultCellStyle.ForeColor = Color.Red;
				}
				if (cars[a].KettenUlnek)
				{
					goodcars.Rows[a].DefaultCellStyle.Font = boldStyle;
				}

				goodcars[0, a].Value = cars[a].Rendszam;
				goodcars[1, a].Value = cars[a].Kapacitas;

				if (cars[a].IsJozsaiAuto)
				{
					goodcars.Rows[a].DefaultCellStyle.ForeColor = Color.Red;

					goodcars[2, a].Tag = cars[a].GetNapszakFordulok(0);
					goodcars[3, a].Tag = cars[a].GetNapszakFordulok(1);
					goodcars[4, a].Tag = cars[a].GetNapszakFordulok(2);

					goodcars[2, a].Value = string.Format("{0} [{1}]", cars[a].GetNapszakFordulok(0), cars[a].GetNapszakJozsa(0));
					goodcars[3, a].Value = string.Format("{0} [{1}]", cars[a].GetNapszakFordulok(1), cars[a].GetNapszakJozsa(1));
					goodcars[4, a].Value = string.Format("{0} [{1}]", cars[a].GetNapszakFordulok(2), cars[a].GetNapszakJozsa(2));

					goodcars[Osszfuvar.Index, a].Value = string.Format("{0} [{1}]", cars[a].OsszFordulo, cars[a].OsszCimJozsa);
				}
				else
				{
					goodcars[2, a].Value = cars[a].GetNapszakFordulok(0);
					goodcars[3, a].Value = cars[a].GetNapszakFordulok(1);
					goodcars[4, a].Value = cars[a].GetNapszakFordulok(2);
					goodcars[Osszfuvar.Index, a].Value = cars[a].OsszFordulo;
				}

				int nap = Properties.Settings.Default.workDays;

				tBer = cars[a].Ber / nap;
				tLizing = cars[a].Lizingdij / nap;

				goodcars[berjarulek.Index, a].Value = tBer;
				goodcars[uzamanyag.Index, a].Value = cars[a].Fogyasztas;
				goodcars[lizing.Index, a].Value = tLizing;
				goodcars[osszkoltseg.Index, a].Value = tBer + tLizing;

				swapCombo.Items.Add(cars[a].Rendszam);

				if (cars[a].Kapacitas <= WorkData.BigCapacityLimit)
					kicsi++;
				else
					nagy++;
			}

			try
			{

				DataGridViewRow emptyRow = new DataGridViewRow();
				emptyRow.ReadOnly = true;
				emptyRow.DefaultCellStyle.BackColor = Color.AntiqueWhite;

				if (cars.Count > 0)
					swapCombo.SelectedIndex = 0;

				if (kicsi > 0)
					goodcars.Rows.Insert(kicsi, kisOsszeg);
				if (kicsi * nagy > 0)
				{
					goodcars.Rows.Insert(kicsi + 1, emptyRow);
				}
				if (nagy > 0)
				{
					goodcars.Rows.Add(nagyOsszeg);
				}

				if (select == null && cars.Count > 0)
					select = cars[0];

				DoSumma();
			}
			catch (Exception x)
			{
				AppLogger.WriteException(x);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private void DoSumma()
		{

			cimosz = new CimOsszesito();

			for (int a = 0; a < cars.Count; a++)
			{
				if (cars[a].Kapacitas <= WorkData.BigCapacityLimit)
				{
					cimosz.ElsoLE5 += cars[a].GetNapszakFordulok(0);
					cimosz.DeLE5 += cars[a].GetNapszakFordulok(1);
					cimosz.DuLE5 += cars[a].GetNapszakFordulok(2);
				}
				else
				{
					cimosz.ElsoTizes += cars[a].GetNapszakFordulok(0);
					cimosz.DeTizes += cars[a].GetNapszakFordulok(1);
					cimosz.DuTizes += cars[a].GetNapszakFordulok(2);
				}
			}

			kisOsszeg.Cells[2].Value = cimosz.ElsoLE5;
			kisOsszeg.Cells[3].Value = cimosz.DeLE5;
			kisOsszeg.Cells[4].Value = cimosz.DuLE5;
			kisOsszeg.Cells[5].Value = cimosz.OsszLE5;

			nagyOsszeg.Cells[2].Value = cimosz.ElsoTizes;
			nagyOsszeg.Cells[3].Value = cimosz.DeTizes;
			nagyOsszeg.Cells[4].Value = cimosz.DuTizes;
			nagyOsszeg.Cells[5].Value = cimosz.OsszTizes;

			carCount.Text = cars.Count.ToString();
		}

		private void DoCarStatx()
		{
			try
			{
				List<Auto> kicsik = new List<Auto>(),
					nagyok = new List<Auto>();

				int[] valos5 = new int[3], valos10 = new int[3], 
					  fuvarok = new int[3];

				int nsz, index5, index10, elvett5, elvett10, csere5 = 0, csere10 = 0;

				foreach (Auto a in cars)
				{
					//if (!a.IsJozsaiAuto)
					{
						if (a.Kapacitas <= WorkData.BigCapacityLimit)
						{
							kicsik.Add(a);
							if (a.KettenUlnek)
								csere5++;
						}
						else
						{
							nagyok.Add(a);
							if (a.KettenUlnek)
								csere10++;
						}
					}
				}

				valos10[0] = (cimosz.Elsofuvar - cimosz.ElsoLE5);
				valos10[1] = (cimosz.Delelott - cimosz.DeLE5);
				valos10[2] = (cimosz.Delutan - cimosz.DuLE5);

				valos5[0] = cimosz.ElsoLE5;
				valos5[1] = cimosz.DeLE5;
				valos5[2] = cimosz.DuLE5;

				fuvarok[0] = cimosz.Elsofuvar;
				fuvarok[1] = cimosz.Delelott;
				fuvarok[2] = cimosz.Delutan;

				Comparison<Auto> koltsegCompare = new Comparison<Auto>(CompareByKoltseg);
				kicsik.Sort(koltsegCompare);
				nagyok.Sort(koltsegCompare);

				Auto tnagy;

				for (nsz = 0; nsz < 3; nsz++)
				{

					atlag5[nsz] = (int)Math.Round(valos5[nsz] / (float)kicsik.Count);
					atlag10[nsz] = (int)Math.Round(valos10[nsz] / (float)nagyok.Count);

					try
					{
						index5 = 0;
						elvett5 = valos5[nsz];
						if (atlag5[nsz] > 0)
						{
							while (elvett5 > 0)
							{
								kicsik[index5].SetNapszakFordulok(nsz, kicsik[index5].GetNapszakFordulok(nsz) + Math.Min(atlag5[nsz], elvett5));
								elvett5 -= atlag5[nsz];
								index5++;
								if (index5 == kicsik.Count)
									index5 = 0;
							}
						}
						else
						{
							while (elvett5 > 0)
							{
								kicsik[index5].SetNapszakFordulok(nsz, kicsik[index5].GetNapszakFordulok(nsz) + 1);
								elvett5--;
								index5++;
								if (index5 == kicsik.Count)
									index5 = 0;
							}
						}
					}
					catch (Exception x)
					{
						AppLogger.WriteException(x);
						AppLogger.WriteEvent("A kivétel elkapva.");
					}

					try
					{
						index10 = 0;
						elvett10 = valos10[nsz];
						if (atlag10[nsz] > 0)
						{
							while (elvett10 > 0)
							{
								nagyok[index10].SetNapszakFordulok(nsz, nagyok[index10].GetNapszakFordulok(nsz) + Math.Min(atlag10[nsz], elvett10));
								elvett10 -= atlag10[nsz];
								index10++;
								if (index10 == nagyok.Count)
									index10 = 0;
							}
						}
						else
						{
							while (elvett10 > 0)
							{
								nagyok[index10].SetNapszakFordulok(nsz, nagyok[index10].GetNapszakFordulok(nsz) + 1);
								elvett10--;
								index10++;
								if (index10 == nagyok.Count)
									index10 = 0;
							}
						}
					}
					catch (Exception y)
					{
						AppLogger.WriteException(y);
						AppLogger.WriteEvent("A kivétel elkapva.");
					}

					for (int a = 0; a < csere5; a++)
					{
						if (kicsik[a].GetNapszakFordulok(nsz) > atlag5[nsz])
							continue;

						tnagy = FindNext(nsz, a, kicsik);

						if (tnagy != null)
						{
							kicsik[a].SetNapszakFordulok(nsz, kicsik[a].GetNapszakFordulok(nsz) + 1);
							tnagy.SetNapszakFordulok(nsz, tnagy.GetNapszakFordulok(nsz) - 1);
						}
					}

					for (int a = 0; a < csere10; a++)
					{
						if (nagyok[a].GetNapszakFordulok(nsz) > atlag10[nsz])
							continue;

						tnagy = FindNext(nsz, a, nagyok);

						if (tnagy != null)
						{
							nagyok[a].SetNapszakFordulok(nsz, nagyok[a].GetNapszakFordulok(nsz) + 1);
							tnagy.SetNapszakFordulok(nsz, tnagy.GetNapszakFordulok(nsz) - 1);
						}
					}

				}

			}
			catch (Exception ex)
			{
				AppLogger.WriteException(ex);
				AppLogger.WriteEvent("A kivétel elkapva.");
			}
		}

		private Auto FindNext(int nsz, int ind, List<Auto> list)
		{
			Auto next = null;

			int napford = 0;
			int id = list.Count - ind - 1;
			while (true)
			{
				if (id == ind)
					break;
				if (!list[id].KettenUlnek && list[id].GetNapszakFordulok(nsz) > napford)
				{
					napford = list[id].GetNapszakFordulok(nsz);
					next = list[id];
				}
				id--;
				if (id < 0)
					id = list.Count - 1;
			}
			return next;
		}

		private void CarDataGridPane_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((e.Cancel = HasDuplicates()))
			{
				MessageBox.Show("Egy rendszám csak egyszer szerepelhet.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (DialogResult == DialogResult.OK)
				{

					dao.UpdateKoltseg(cars);
				}
			}
		}

		private bool HasDuplicates()
		{
			foreach (Auto a in cars)
			{
				for (int b = 0; b < cars.Count; b++)
				{
					if (cars[b] != a && cars[b].Rendszam == a.Rendszam)
						return true;
				}
			}
			return false;
		}

		private void goodcars_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			delBtn_Click(null, null);
			e.Cancel = !cancel;
		}

		private Auto findByRendszam(string rsz)
		{
			foreach (Auto a in cars)
			{
				if (a.Rendszam == rsz)
					return a;
			}
			return null;
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			using (UjAuto uj = new UjAuto(dao))
			{
				uj.FormClosing += new FormClosingEventHandler(uj_FormClosing);
				uj.ShowDialog();
			}
		}

		void uj_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (((UjAuto)sender).DialogResult == DialogResult.OK)
			{
				select = ((UjAuto)sender).car;

				if (Duplicate(select.Rendszam))
				{
					MessageBox.Show("A rendszám már szerepel a listán!", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
					e.Cancel = true;
					return;
				}			

				select.Index = Auto.AutoIndex++;
				cars.Add(select);

				dao.InsertCar(select);

				AppLogger.WriteEvent("Új autó:");
				AppLogger.WriteAuto(select);

                if (BeforeRowAdd != null)
                {
                    BeforeRowAdd();
                }

				DoCarUpdate();
			}
		}

		private void goodcars_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
		{
			try
			{
				if (select.IsJozsaiAuto)
					goodcars.CurrentCell.Value = goodcars.CurrentCell.Tag.ToString();
			}
			catch (NullReferenceException)
			{
				select = null;
			}
		}

		private void delBtn_Click(object sender, EventArgs e)
		{
			cancel = false;
			if (goodcars.SelectedRows.Count == 0)
				return;

			string uzi = goodcars.SelectedRows[0].Cells[0].Value.ToString();
			
			if (MessageBox.Show("Valóban eltávolítsam a következő járművet:\n" + uzi, "Jármű törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				== DialogResult.Yes)
			{
				Auto auto = findByRendszam(goodcars.SelectedRows[0].Cells[0].Value.ToString());
				/*if (auto.IsJozsaiAuto)
				{
					MessageBox.Show("A kiválasztott járműhöz józsai címek is vannak rendelve, amelyek nem szabadíthatók fel.\nA jármű nem törölhető.",
						auto.Rendszam, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}*/

				if (BeforeRowDelete != null && !BeforeRowDelete(auto, -1))
					return;

				AppLogger.WriteEvent(string.Format("Autótörlés: {0}", auto.Rendszam));
				cars.Remove(auto);

				cancel = true;
				DoCarUpdate();

			}
		}

		private void swapBtn_Click(object sender, EventArgs e)
		{
			if (swapCombo.SelectedIndex > -1)
			{

				Auto cserelendo = findByRendszam(goodcars[0, goodcars.CurrentCell.RowIndex].Value.ToString());
				Auto masik = findByRendszam(swapCombo.SelectedItem.ToString());

				AppLogger.WriteEvent(string.Format("Csere: {0} -> {1}", cserelendo.Rendszam, masik.Rendszam));

				if (cserelendo != masik &&
					MessageBox.Show(string.Format("Biztosan cserélni akarja a {0} rendszámot erre: {1}?", cserelendo.Rendszam, masik.Rendszam),
					"Csere", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					string tmp = cserelendo.Rendszam;
					cserelendo.Rendszam = masik.Rendszam;
					masik.Rendszam = tmp;

					DoCarUpdate();
				}
			}

		}

		private void CarDataGridPane_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			Help.ShowHelp(this, Application.StartupPath + Properties.Settings.Default.helpPath, HelpNavigator.TopicId, "7");
		}

		private void staffbtn_Click(object sender, EventArgs e)
		{
			if (select != null)
			{
				using (StaffPane sp = new StaffPane(select))
				{
					if (sp.ShowDialog() == DialogResult.OK)
					{
						DoCarUpdate();
					}
				}
			}
		}

		private void goodcars_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				select = findByRendszam(goodcars[0, goodcars.CurrentCell.RowIndex].Value.ToString());
			}
			catch (NullReferenceException)
			{
				select = null;
			}
		}

		private void CarDataGridPane_Load(object sender, EventArgs e)
		{
			goodcars.Columns["rendszam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

	}

}
