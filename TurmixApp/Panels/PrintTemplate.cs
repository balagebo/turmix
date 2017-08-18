using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Net;
using System.IO;

namespace TurmixLog
{
	public partial class PrintTemplate : Form
	{
		private List<Auto> cars;
		private int current;
		private int aktualNsz;
		private Repository adatok;

		private PrintDocument document;

		private Pen printPen;
		private Brush printBrush;

		private int efstart, efend, destart, deend, dustart, duend;
		private int efmarad, demarad, dumarad;
		private int efindex = 0, deindex = 0, duindex = 0;

		private bool[] infos;

		public PrintTemplate()
		{

			InitializeComponent();
			InitPrint();

			printBrush = new SolidBrush(System.Drawing.Color.Black);
			printPen = new Pen(printBrush, 1f);

		}

		private void InitPrint()
		{
			document = new PrintDocument();
			PageSettings pageSettings = new PageSettings();
			pageSettings.Color = false;
			pageSettings.Landscape = false;

			document.DefaultPageSettings = pageSettings;

		}

		void document_BeginPrint(object sender, PrintEventArgs e)
		{
			if (cars.Count == 0)
			{
				e.Cancel = true;
			}
			else
			{
				current = 0;

				efmarad = cars[current].NapszakForduloSzam(0);
				demarad = cars[current].NapszakForduloSzam(1);
				dumarad = cars[current].NapszakForduloSzam(2);

				efstart = destart = dustart = 0;
				efindex = deindex = duindex = 0;
			}
		}

		void document_EndPrint(object sender, PrintEventArgs e)
		{
		}

		void document_PrintPage(object sender, PrintPageEventArgs e)
		{

			int fo;
			int px = e.PageBounds.Left + 50;
			int py = e.MarginBounds.Top;

			int tab = 20;

			int metric = Font.Height;
			int pRows = e.PageBounds.Height / metric - 4;
			List<WorkData> ids;

			float w_sofor = e.Graphics.MeasureString(sofor.Text, Font).Width;
			float w_sv = e.Graphics.MeasureString(cars[current].Sofor, Font).Width;
			float w_rsz = e.Graphics.MeasureString(cars[current].Rendszam, Font).Width;
			float w_seged = e.Graphics.MeasureString(seged.Text, Font).Width;
			float w_segv = e.Graphics.MeasureString(cars[current].Seged, Font).Width;
			float w_date = e.Graphics.MeasureString(idoval.Text, Font).Width;
			float w_gyuj = e.Graphics.MeasureString(gyujto.Text, Font).Width;

			float w_megrend = e.Graphics.MeasureString("Megrendelt mennyiség (tonna): ", Font).Width;
			float w_telcel = e.Graphics.MeasureString("Telítettségi cél (%): ", Font).Width;
			float w_beszall = e.Graphics.MeasureString("Beszállított mennyiség (tonna): ", Font).Width;

            float cimWidth;
            string cimText;
            int tCsoX = e.PageBounds.Right - 150;
            int tM3X = tCsoX - 100;

			e.Graphics.DrawString(gyujto.Text, Font, printBrush, px, py);
			e.Graphics.DrawString(sofor.Text, Font, printBrush, px + w_gyuj + w_rsz + tab * 2, py);
			e.Graphics.DrawString(cars[current].Rendszam, Font, printBrush, px + w_gyuj + tab, py);
			e.Graphics.DrawString(cars[current].Sofor, Font, printBrush, px + w_gyuj + w_rsz + w_seged + tab * 3, py);

			py += metric;

			e.Graphics.DrawString(cars[current].Seged, Font, printBrush, px + w_gyuj + w_rsz + w_seged + tab * 3, py);
			e.Graphics.DrawString(seged.Text, Font, printBrush, px + w_gyuj + w_rsz + tab * 2, py);
			e.Graphics.DrawString(idoval.Text, Font, printBrush, px, py);

            e.Graphics.DrawString("Tényl. m3", Font, printBrush, tCsoX - 20, py);
            //e.Graphics.DrawString("Cső (m)", Font, printBrush, tCsoX - 20, py);
           
			if (!cars[current].IsEmpty)
			{
				if (efmarad > 0 || demarad > 0 || dumarad > 0)
				{
					efend = Math.Min(efmarad, pRows);
					deend = Math.Min(demarad, pRows - efend);
					duend = Math.Min(dumarad, pRows - efend - deend);

					if (efend > 0)
					{
						py += metric;
						e.Graphics.DrawLine(printPen, px, py, e.MarginBounds.Right, py);
						py += metric;
						e.Graphics.DrawString(Enum.GetNames(typeof(Napszak))[0], Font, printBrush, px, py);
                        
					}
					fo = 0;		//fordulók adott oldalon
					while (fo < efend)
					{
						if ((ids = cars[current].GetFuvarAt(0, efindex)).Count > 0)
						{
							foreach (WorkData id in ids)
							{
								py += metric;
                                cimText = string.Format("{0}. {1} - {2} m cső", efstart + 1, id.GetInfo(true, true, false, true), id.CsoHossz);
                                cimWidth = e.Graphics.MeasureString(cimText, Font).Width;
                                e.Graphics.DrawString(cimText, Font, printBrush, px + 20, py);

                                e.Graphics.DrawString(id.TenylegesKobmeter.ToString(), Font, printBrush, tCsoX, py);
                                //e.Graphics.DrawString(id.CsoHossz.ToString(), Font, printBrush, tCsoX, py);						
                            }
							efmarad--;	//össz.
							efstart++;	//hanyadik a napszakban. 
							fo++;
						}
						efindex++;		//index a NM-ben

					}

					if (deend > 0)
					{
						py += metric;
						e.Graphics.DrawLine(printPen, px, py, e.MarginBounds.Right, py);
						py += metric;
						e.Graphics.DrawString(Enum.GetNames(typeof(Napszak))[1], Font, printBrush, px, py);
					}

					fo = 0;		//fordulók adott oldalon
					while (fo < deend)
					{
						if ((ids = cars[current].GetFuvarAt(1, deindex)).Count > 0)
						{
							foreach (WorkData id in ids)
							{
                                py += metric;
                                cimText = string.Format("{0}. {1} - {2} m cső", destart + 1, id.GetInfo(true, true, false, true), id.CsoHossz);
                                cimWidth = e.Graphics.MeasureString(cimText, Font).Width;
                                e.Graphics.DrawString(cimText, Font, printBrush, px + 20, py);

                               e.Graphics.DrawString(id.TenylegesKobmeter.ToString(), Font, printBrush, tCsoX, py);
                               // e.Graphics.DrawString(id.CsoHossz.ToString(), Font, printBrush, tCsoX, py);
							}
							demarad--;	//össz.
							destart++;	//hanyadik a napszakban. 
							fo++;
						}
						deindex++;		//index a NM-ben

					}

					if (duend > 0)
					{
						py += metric;
						e.Graphics.DrawLine(printPen, px, py, e.MarginBounds.Right, py);
						py += metric;
						e.Graphics.DrawString(Enum.GetNames(typeof(Napszak))[2], Font, printBrush, px, py);
					}

					fo = 0;		//fordulók adott oldalon
					while (fo < duend)
					{
						if ((ids = cars[current].GetFuvarAt(2, duindex)).Count > 0)
						{
							foreach (WorkData id in ids)
							{
                                py += metric;
                                cimText = string.Format("{0}. {1} - {2} m cső", dustart + 1, id.GetInfo(true, true, false, true), id.CsoHossz);
                                cimWidth = e.Graphics.MeasureString(cimText, Font).Width;
                                e.Graphics.DrawString(cimText, Font, printBrush, px + 20, py);

                                e.Graphics.DrawString(id.TenylegesKobmeter.ToString(), Font, printBrush, tCsoX, py);
                                //e.Graphics.DrawString(id.CsoHossz.ToString(), Font, printBrush, tCsoX, py);
							}
							dumarad--;	//össz.
							dustart++;	//hanyadik a napszakban. 
							fo++;
						}
						duindex++;		//index a NM-ben

					}

				}

				int marad = (py / metric);
				if (!infos[current] && marad <= pRows - 6)
				{
					py += metric;
					py += metric;
					e.Graphics.DrawString(string.Format("Megrendelt mennyiség (tonna): {0}", cars[current].OsszM3), Font, printBrush, px + 20, py);
					py += metric;
					e.Graphics.DrawString(string.Format("Telítettségi cél (%): {0}", Properties.Settings.Default.telitettCel), Font, printBrush, px + 20, py);
					py += metric;
					e.Graphics.DrawString(string.Format("Beszállított mennyiség (tonna): {0}", cars[current].OsszM3 * Properties.Settings.Default.telitettCel / 100), Font, printBrush, px + 20, py);
					py += metric;
					e.Graphics.DrawString(string.Format("Összes csőhossz (m): {0}", cars[current].Csohossz), Font, printBrush, px + 20, py);
					py += metric;
					e.Graphics.DrawString(string.Format("Összes megtett km: {0}", cars[current].OsszTavolsag), Font, printBrush, px + 20, py);

					infos[current] = true;
				}
			}
			else
			{
				infos[current] = true;
			}

			e.HasMorePages = true;
			if (infos[current] && efmarad == 0 && demarad == 0 && dumarad == 0)
			{
				current++;
				if (current == cars.Count)
				{
					e.HasMorePages = false;
				}
				else
				{
					efstart = destart = dustart = 0;
					efindex = deindex = duindex = 0;

					efmarad = cars[current].NapszakForduloSzam(0);
					demarad = cars[current].NapszakForduloSzam(1);
					dumarad = cars[current].NapszakForduloSzam(2);
				}
			}

		}

        public void gyujtoToPDF(List<Auto> autok, DateTime date)
        {
            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.CheckPathExists = fd.AddExtension = true;
                fd.Filter = "PDF fájl|*.pdf";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        iTextSharp.text.Font fon = FontFactory.GetFont("c:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, true, Font.Size - 1);
                        iTextSharp.text.Font bold = FontFactory.GetFont("c:\\Windows\\Fonts\\arialbd.ttf", BaseFont.IDENTITY_H, true, Font.Size);
                        Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fd.FileName, FileMode.Create, FileAccess.Write));

                        doc.Open();

                        PdfPTable table;

                        int napszakfuvar;

                        PdfPCell cell;
                        int count = 0;
                        foreach (Auto auto in autok)
                        {
                            if (auto.OsszM3 == 0)
                                continue;
                            table = new PdfPTable(2);
                            table.DefaultCell.Border = 0;
                            table.SetWidths(new float[] { .8f, .2f });

                            cell = new PdfPCell(new Phrase("Gyűjtő - " + auto.Rendszam, bold));
                            cell.Border = 0;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(date.ToShortDateString(), bold));
                            cell.Border = 0;
                            cell.HorizontalAlignment = 2;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Járművezető: " + auto.Sofor + "     Segéd: " + (auto.KettenUlnek ? auto.Seged : "Nincs"), bold));
                            cell.Colspan = 2;
                            cell.Border = 0;
                            table.AddCell(cell);
                            for (int a = 0; a < 3; a++)
                            {
                                List<WorkData> lapok = auto.OsszesMunkalap(a);
                                if (lapok.Count > 0)
                                {
                                    cell = new PdfPCell(new Phrase(Enum.GetNames(typeof(Napszak))[a], bold));
                                    cell.Border = 0;
                                    cell.PaddingTop = cell.PaddingBottom = 10f;
                                    table.AddCell(cell);
                                    cell = new PdfPCell(new Phrase("Tényl. m3", bold));
                                    cell.HorizontalAlignment = 2;
                                    cell.Border = 0;
                                    cell.PaddingTop = cell.PaddingBottom = 10f;
                                    table.AddCell(cell);

                                    napszakfuvar = 1;
                                
                                    foreach (WorkData wd in lapok)
                                    {
                                        table.AddCell(new Phrase(string.Format("{0}. {1} - {2} m cső", napszakfuvar++, wd.GetInfo(true, true, false, true), wd.CsoHossz), fon));
                                        cell = new PdfPCell(new Phrase(wd.TenylegesKobmeter.ToString(), fon));
                                        cell.HorizontalAlignment = 2;
                                        cell.Border = 0;
                                        table.AddCell(cell);
                                    }
                                }
                            }

                            cell = new PdfPCell(new Phrase("Megrendelt mennyiség (tonna): " + auto.OsszM3.ToString(), bold));
                            cell.PaddingTop = 20f;
                            cell.Colspan = 2;
                            cell.Border = 0;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Telítettségi cél %: " + Properties.Settings.Default.telitettCel.ToString(), bold));cell.Colspan = 2;
                            cell.Colspan = 2;
                            cell.Border = 0;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Beszállított mennyiség (tonna): " +
                                auto.OsszM3 * Properties.Settings.Default.telitettCel / 100, bold));
                            cell.Colspan = 2;
                            cell.Border = 0;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Összes csőhossz (m): " + auto.Csohossz.ToString(), bold));
                            cell.Colspan = 2;
                            cell.Border = 0;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Összes km: " + auto.OsszTavolsag.ToString(), bold));
                            cell.Colspan = 2;
                            cell.Border = 0;
                            table.AddCell(cell);

                            doc.Add(table);
                            if (count < autok.Count - 1)
                            {
                                doc.NewPage();
                            }
                            count++;
                        }

                        
                        doc.Close();

                        MessageBox.Show("A mentés sikerült!", "Mentés kész", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception e)
                    {
                        AppLogger.WriteException(e);
                        MessageBox.Show("A mentés nem sikerült!\nEllenőrízze, a kiválasztott fájl nincs-e mással megnyitva", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

		public void PrintCars(List<Auto> autok, Repository repo, DateTime date, PageSettings set, bool print)
		{

			try
			{

				document.BeginPrint += new PrintEventHandler(document_BeginPrint);
				document.PrintPage += new PrintPageEventHandler(document_PrintPage);
				document.EndPrint += new PrintEventHandler(document_EndPrint);

				cars = autok;
				adatok = repo;
				idoval.Text = date.ToShortDateString();

				infos = new bool[autok.Count];

				document.DefaultPageSettings = set;

				if (print)
				{

					using (PrintDialog pd = new PrintDialog())
					{
						
						pd.Document = document;
						if (pd.ShowDialog() == DialogResult.OK)
						{
							document.DefaultPageSettings = pd.PrinterSettings.DefaultPageSettings;
							document.Print();
						}
					}

				}
				else
				{
					
					using (PrintPreviewDialog ps = new PrintPreviewDialog())
					{
						
						ps.Document = document;
						ps.UseAntiAlias = true;
						ps.ShowDialog();
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		public void PrintStat(List<Auto> autok, DateTime date, PageSettings set, bool printe) {

			try
			{
				cars = autok;
				idoval.Text = date.ToShortDateString();

				document.DefaultPageSettings = set;
				document.BeginPrint += new PrintEventHandler(stdoc_BeginPrint);
				document.PrintPage += new PrintPageEventHandler(stdoc_PrintPage);

				if (printe)
				{
					using (PrintDialog pd = new PrintDialog())
					{

						pd.Document = document;
						if (pd.ShowDialog() == DialogResult.OK)
						{
							document.DefaultPageSettings = pd.PrinterSettings.DefaultPageSettings;
							document.Print();
						}
					}
				}
				else
				{
					using (PrintPreviewDialog ps = new PrintPreviewDialog())
					{

						ps.Document = document;
						ps.UseAntiAlias = true;
						ps.ShowDialog();
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void stdoc_BeginPrint(object sender, PrintEventArgs e)
		{
			if (cars.Count == 0)
			{
				e.Cancel = true;
				return;
			}
		}

		void stdoc_PrintPage(object sender, PrintPageEventArgs e)
		{
			int px = e.MarginBounds.Left;
			int py = e.MarginBounds.Top;

			int tab = 20;

			int metric = Font.Height;
			int pRows = e.MarginBounds.Height / metric - 7;
			int roCnt = 0;

			float w_cim = e.Graphics.MeasureString("Összes cím: ", Font).Width;
			float w_km = e.Graphics.MeasureString("Összes km: ", Font).Width;
			float w_kolt = e.Graphics.MeasureString("Összes költség: ", Font).Width;
			float w_cso = e.Graphics.MeasureString("Összes csőhossz: ", Font).Width;

			float w_cimval;
			float w_kmval = e.Graphics.MeasureString("999", Font).Width;
			

			Auto auto;

			e.Graphics.DrawString("Járműstatisztika", Font, printBrush, px, py);
			py += metric;
			roCnt++;
			e.Graphics.DrawString(idoval.Text, Font, printBrush, px, py);

			e.HasMorePages = false;

			while (current < cars.Count)
			{
				auto = cars[current];

				py += metric;
				roCnt++;
				py += metric;
				roCnt++;
				e.Graphics.DrawString(auto.Info, Font, printBrush, px, py);
				py += metric;
				roCnt++;
				e.Graphics.DrawLine(printPen, px, py, e.MarginBounds.Right, py);
				
				py += metric;
				roCnt++;
				e.Graphics.DrawString("Összes cím: ", Font, printBrush, px + tab, py);
				e.Graphics.DrawString(auto.OsszCim.ToString(), Font, printBrush, px + w_cso + 2 * tab, py);
				
				//py += metric;
				//roCnt++;
				e.Graphics.DrawString("Összes km: ", Font, printBrush, px + w_cso + w_kmval + 3 * tab, py);
				e.Graphics.DrawString(auto.OsszTavolsag.ToString(), Font, printBrush, px + w_cso + w_kmval + w_km + 4 * tab, py);

				py += metric;
				roCnt++;
				e.Graphics.DrawString("Összes csőhossz: ", Font, printBrush, px + tab, py);
				e.Graphics.DrawString(auto.Csohossz.ToString(), Font, printBrush, px + w_cso + 2 * tab, py);
				

				//py += metric;
				//roCnt++;
				e.Graphics.DrawString("Összköltség: ", Font, printBrush, px + w_cso + w_kmval + 3 * tab, py);
				e.Graphics.DrawString(auto.OsszKoltseg.ToString(), Font, printBrush, px + w_km + w_kmval + w_cso + 4 * tab, py);

				current++;

				if (roCnt >= pRows)
				{
					e.HasMorePages = true;
					return;
				}
				
			}


		}

        public void statToPDF(List<Auto> autok, DateTime date)
        {
            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.CheckPathExists = fd.AddExtension = true;
                fd.Filter = "PDF fájl|*.pdf";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        iTextSharp.text.Font fon = FontFactory.GetFont("c:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, true, Font.Size);
                        iTextSharp.text.Font bold = FontFactory.GetFont("c:\\Windows\\Fonts\\arialbd.ttf", BaseFont.IDENTITY_H, true, Font.Size);
                        Document doc = new Document(PageSize.A4, 30, 30, 72, 72);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fd.FileName, FileMode.Create, FileAccess.Write));

                        doc.Open();

                        Phrase w_cim = new Phrase("Összes cím", bold);
                        Phrase w_rend = new Phrase("Rendszám", bold);
                        Phrase w_km = new Phrase("Összes km", bold);
                        Phrase w_kolt = new Phrase("Összes költség", bold);
                        Phrase w_cso = new Phrase("Összes csőhossz", bold);

                        PdfPTable table = new PdfPTable(5);
                        PdfPCell cell = new PdfPCell(new Phrase("Járműstatisztika " + date.ToShortDateString(), bold));
                        cell.Colspan = 5;
                        cell.HorizontalAlignment = 1;
                        cell.Border = 0;
                        cell.PaddingBottom = 20f;
                        table.AddCell(cell);

                        cell = new PdfPCell(w_rend);
                        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        cell.HorizontalAlignment = 1;
                        table.AddCell(cell);

                        cell = new PdfPCell(w_cim);
                        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        cell.HorizontalAlignment = 1;
                        table.AddCell(cell);

                        cell = new PdfPCell(w_km);
                        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        cell.HorizontalAlignment = 1;
                        table.AddCell(cell);

                        cell = new PdfPCell(w_kolt);
                        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        cell.HorizontalAlignment = 1;
                        table.AddCell(cell);

                        cell = new PdfPCell(w_cso);
                        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        cell.HorizontalAlignment = 1;
                        table.AddCell(cell);

                        float[] vals = new float[4];

                        foreach (Auto auto in autok)
                        {
                            table.AddCell(new Phrase(auto.Info, fon));
                            cell = new PdfPCell(new Phrase(auto.OsszCim.ToString(), fon));
                            vals[0] += auto.OsszCim;
                            cell.HorizontalAlignment = 1;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(auto.OsszTavolsag.ToString(), fon));
                            cell.HorizontalAlignment = 1;
                            vals[1] += auto.OsszTavolsag;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(auto.Csohossz.ToString(), fon));
                            cell.HorizontalAlignment = 1;
                            vals[2] += auto.Csohossz;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(auto.OsszKoltseg.ToString(), fon));
                            cell.HorizontalAlignment = 1;
                            vals[3] += auto.OsszKoltseg;
                            table.AddCell(cell);

                        }

                        cell = new PdfPCell(new Phrase("Mindösszesen:", bold));
                        table.AddCell(cell);

                        for (int a = 0; a < 4; a++)
                        {
                            cell = new PdfPCell(new Phrase(vals[a].ToString(), bold));
                            cell.HorizontalAlignment = 1;
                            table.AddCell(cell);
                        }

                        cell = new PdfPCell(new Phrase("Telítettségi cél %: " + Properties.Settings.Default.telitettCel.ToString(), bold));
                        cell.Colspan = 5;
                        cell.HorizontalAlignment = 1;
                        cell.Border = 0;
                        cell.PaddingTop = 20f;
                        table.AddCell(cell);

                        doc.Add(table);
                        doc.Close();

                        MessageBox.Show("A mentés sikerült!", "Mentés kész", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception e)
                    {
                        AppLogger.WriteException(e);
                        MessageBox.Show("A mentés nem sikerült!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
            
        }

	}
}
