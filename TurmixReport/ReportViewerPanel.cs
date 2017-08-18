using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Xml;
using System.IO;

namespace TurmixReport
{
    public partial class ReportViewerPanel : Form
    {

        private turmixDataSetTableAdapters.SelectAtlagFogyTableAdapter selectAdapter =
            new TurmixReport.turmixDataSetTableAdapters.SelectAtlagFogyTableAdapter();

        private turmixDataSetTableAdapters.tankolasTableAdapter tankolasAdapter =
            new TurmixReport.turmixDataSetTableAdapters.tankolasTableAdapter();

        private turmixDataSet.SelectAtlagFogyDataTable atlagTable;
        private turmixDataSet.tankolasDataTable tankolasTable;

        private UserControl userControl;
        private Feladat job;
        private DiagramType diagramType = DiagramType.Column;
        private string reportHome = Application.StartupPath + "\\report\\";
        private string localPath;

        public ReportViewerPanel(Feladat job)
        {
            InitializeComponent();

            this.job = job;
            switch (job)
            {
                case Feladat.FogyasztasIdoszak:
                    userControl = new FogyasztasPanel();
                    infoText.DocumentText = Properties.Resources.fogyIdoHTML;
                    break;
            }
            contentPanel.Controls.Add(userControl);

            int index = 0;
            foreach (string s in Enum.GetNames(typeof(DiagramType)))
            {
                diagramToolStripMenuItem.DropDownItems[index].Enabled = File.Exists(string.Format("{0}{1}_{2}.rdlc", reportHome, job, s));
                index++;
            }

            localPath = string.Format("{0}{1}.rdlc", reportHome, job);
            plainReport.LocalReport.ReportPath = localPath;
        }

        private void ReportViewerPanel_Load(object sender, EventArgs e)
        {
            selectAdapter.ClearBeforeFill = tankolasAdapter.ClearBeforeFill = true;
        }

        public void DoFogyIdoszak(DateTime kezdo, DateTime veg)
        {
            try
            {
                atlagTable = selectAdapter.GetData(kezdo, veg);
                tankolasTable = tankolasAdapter.GetData();

                dataGrid.DataSource = atlagTable;
                dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[0].HeaderText = "Rendszám";
                dataGrid.Columns[1].HeaderText = "Átlagfogyasztás [liter]";
                dataGrid.Columns[1].Width = 200;
                dataGrid.Columns[1].DefaultCellStyle.Format = "N2";
                dataGrid.Columns[2].HeaderText = "Átlagos költség [Ft]";
                dataGrid.Columns[2].Width = 200;
                dataGrid.Columns[2].DefaultCellStyle.Format = "N2";

                if (mindkettőToolStripMenuItem.Checked || táblázatToolStripMenuItem.Checked)
                {
                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("kezdo", kezdo.ToString("yyyy-MM-dd"));
                    param[1] = new ReportParameter("veg", veg.ToString("yyyy-MM-dd"));
                    

                    plainReport.LocalReport.DataSources.Clear();
                    plainReport.LocalReport.DataSources.Add(new ReportDataSource("atlagProc",
                        atlagTable));
                    plainReport.LocalReport.DataSources.Add(new ReportDataSource("tankolas",
                        tankolasTable));
                    plainReport.LocalReport.SetParameters(param);
                    plainReport.RefreshReport();                 
                }
                if (mindkettőToolStripMenuItem.Checked || grafikonToolStripMenuItem.Checked)
                {
                    chartReport.Reset();
                    chartReport.LocalReport.ReportPath = string.Format("{0}FogyasztasIdoszak_{1}.rdlc", reportHome, diagramType);
                    chartReport.LocalReport.DataSources.Clear();
                    chartReport.LocalReport.DataSources.Add(new ReportDataSource("atlagProc", atlagTable));
                    chartReport.LocalReport.DataSources.Add(new ReportDataSource("tankolas",
                        tankolasTable));
                    chartReport.RefreshReport();
                }

                Text = string.Format("Időszakos fogyasztás: {0} - {1}", kezdo.ToShortDateString(), veg.ToShortDateString());
            }
            catch (MySql.Data.MySqlClient.MySqlException myex)
            {
                if (myex.Number == 1042 || myex.Number == 1044 || myex.Number == 1045)
                {
                    if (MessageBox.Show("Az adatok lekérdezése közben hiba történt. Valószínűleg hibásak az adatbázis beállítások.\nKívánja ezeket módosítani?",
                            "Hiba", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        using (SetterPanel sp = new SetterPanel())
                        {
                            if (sp.ShowDialog() == DialogResult.OK)
                            {
                                //DoFogyIdoszak(kezdo, veg);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            switch (job)
            {
                case Feladat.FogyasztasIdoszak:
                    FogyasztasPanel fp = userControl as FogyasztasPanel;
                    DoFogyIdoszak(fp.KezdoDatum, fp.VegDatum);
                    
                    break;
            }
        }

        private void táblázatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem chItem = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem item in nézetToolStripMenuItem.DropDownItems)
            {
                item.Checked = (item == chItem);
            }

            reportSplit.Panel2Collapsed = !(mindkettőToolStripMenuItem.Checked || grafikonToolStripMenuItem.Checked);
            reportSplit.Panel1Collapsed = !(mindkettőToolStripMenuItem.Checked || táblázatToolStripMenuItem.Checked);
            
            if (chartReport.LocalReport.ReportPath == null)
                return;

            if (reportSplit.Panel1Collapsed)
            {
                chartReport.ZoomMode = ZoomMode.FullPage;
            }
            else 
            {
                chartReport.ZoomMode = ZoomMode.Percent;
                chartReport.ZoomPercent = 100;
            }

            refreshBtn_Click(null, null);
        }

        private void oszlopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                ToolStripMenuItem chItem = sender as ToolStripMenuItem;
                foreach (ToolStripMenuItem item in diagramToolStripMenuItem.DropDownItems)
                {
                    item.Checked = (item == chItem);
                }

                if (chartReport.LocalReport.ReportPath == null)
                    return;

                if (chItem == oszlopToolStripMenuItem)
                {
                    diagramType = DiagramType.Column;
                }
                else if (chItem == sordiagramToolStripMenuItem)
                {
                    diagramType = DiagramType.Bar;
                }
                else if (chItem == területToolStripMenuItem)
                {
                    diagramType = DiagramType.Area;
                }
                else if (chItem == vonalToolStripMenuItem)
                {
                    diagramType = DiagramType.Line;
                }
                else if (chItem == körToolStripMenuItem)
                {
                    diagramType = DiagramType.Pie;
                }
                else if (chItem == körsávToolStripMenuItem)
                {
                    diagramType = DiagramType.Doughnut;
                }

                refreshBtn_Click(null, null);
            }
            catch (Exception ex)
            {
            }
        }
        enum DiagramType {
            Column, Bar, Area, Line, Pie, Doughnut
        }
    }
}
