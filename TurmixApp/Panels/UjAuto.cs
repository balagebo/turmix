using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace TurmixLog
{
	public partial class UjAuto : Form
	{

		public Auto car = new Auto("");

		private List<Auto> elem = new List<Auto>();
		

		private Predicate<Auto> rendszamPred;

		public UjAuto(KiosztasDao dao)
		{
			InitializeComponent();

			rendszamPred = new Predicate<Auto>(IsRendszam);

			elem = dao.GetCars();
			foreach (Auto a in elem)
			{
				rendszamBox.Items.Add(a.Rendszam);
			}
		}

		private void okBtn_Click(object sender, EventArgs e)
		{

			if (rendszamBox.Text.Trim() == "")
			{
				MessageBox.Show("A Rendszám mező nem lehet üres", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (!Auto.Rendex.IsMatch(rendszamBox.Text))
			{
				MessageBox.Show("A rendszám alakja a következő: 'ABC-123'", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (kapacitas.Value == 0m)
			{
				MessageBox.Show("A kapacitás nem lehet 0", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (sofor.Text.Trim() == "")
			{
				MessageBox.Show("Adja meg a jármű vezetőjét!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			car.Rendszam = rendszamBox.Text.ToUpper();
			car.Sofor = sofor.Text;
			car.Seged = seged.Text;

			car.SetNapszakFordulok(0, (int)elsofuvar.Value);
			car.SetNapszakFordulok(1, (int)delelott.Value);
			car.SetNapszakFordulok(2, (int)delutan.Value);

			car.Fogyasztas = (float)uzemanyag.Value;
			car.Lizingdij = (float)lizing.Value;

			car.Kapacitas = (int)kapacitas.Value;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void rendszamBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Auto au = elem.Find(rendszamPred);
			if (au != null)
			{
				car = au;
			}

            try
            {
                kapacitas.Value = (decimal)car.Kapacitas;
            }
            catch (ArgumentOutOfRangeException)
            {
                car.Kapacitas = 5;
                kapacitas.Value = (decimal)car.Kapacitas;
            }
            try
            {
                uzemanyag.Value = (decimal)car.Fogyasztas;
            }
            catch (ArgumentOutOfRangeException)
            {
                car.Fogyasztas = 0f;
                uzemanyag.Value = (decimal)car.Fogyasztas;
            }
            try
            {
                lizing.Value = (decimal)car.Lizingdij;
            }
            catch (ArgumentOutOfRangeException)
            {
                car.Lizingdij = 0f;
                lizing.Value = (decimal)car.Lizingdij;
            }
		}

		private bool IsRendszam(Auto a)
		{
			if (rendszamBox.SelectedIndex > -1 && a.Rendszam == rendszamBox.SelectedItem.ToString())
			{
				return true;
			}
			return false;
		}
	}
}
