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
    public delegate void IdPassDelegate(int id);
    public delegate void ProblemPassDelegate(int id, bool prob);

    public partial class MunkalapPanel : Form
    {

        private KiosztasDao dao;
        private Repository repo;

        public event IdPassDelegate OnStreetChange;
        public event ProblemPassDelegate OnProbChange;
        public event IdPassDelegate OnNapszakChange;

        public MunkalapPanel(Repository repo, KiosztasDao dao)
        {
            this.dao = dao;
            this.repo = repo;
            InitializeComponent();

            List<string> utcak = dao.GetUtcak();
            List<WorkData> work = repo.GetOsszAdat().Values.ToList();
            csoGrid.AutoGenerateColumns = false;
            csoGrid.DataSource = work;

            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.ReadOnly = true;
            col.HeaderText = "Munkalap";
            col.DataPropertyName = "WorksheetNumber";
            col.Width = 60;
            csoGrid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.ReadOnly = true;
            col.HeaderText = "m3";
            col.DataPropertyName = "WorkCapacity";
            col.Width = 30;
            csoGrid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.ReadOnly = true;
            col.HeaderText = "Tm3";
            col.DataPropertyName = "TenylegesKobmeter";
            col.Width = 30;
            csoGrid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Napszak";
            col.ReadOnly = true;
            col.DataPropertyName = "Napszak";
            col.Width = 50;
            csoGrid.Columns.Add(col);

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Utca";
            foreach (string itm in utcak)
            {
                combo.Items.Add(itm);
            }
            combo.Items.Add("");
            combo.AutoComplete = true;
            combo.MaxDropDownItems = 10;
            combo.DataPropertyName = "Utca";
            combo.Width = 140;
            csoGrid.Columns.Add(combo);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hsz";
            col.DataPropertyName = "HazSzam";
            col.Width = 60;
            csoGrid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Info";
            col.DataPropertyName = "Megjegyzes";
            csoGrid.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Problémás";
            col.DataPropertyName = "Problematic";
            col.Width = 60;
            csoGrid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "ID";
            col.DataPropertyName = "Number";
            col.Width = 10;
            col.Visible = false;
            csoGrid.Columns.Add(col);

            csoGrid.CellValueChanged += new DataGridViewCellEventHandler(csoGrid_CellValueChanged);
            
        }

        private void MunkalapPanel_Load(object sender, EventArgs e)
        {
            csoGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void csoGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            WorkData wd = repo.Find((int)csoGrid[8, e.RowIndex].Value);

            switch (e.ColumnIndex)
            {
                case 4:
                    //Utca
                    dao.GetLatLngProb(wd);
                    if (OnStreetChange != null)
                    {
                        OnStreetChange(wd.Number);
                    }
                    break;
                case 7:
                    if (OnProbChange != null)
                    {
                        OnProbChange(wd.Number, wd.Problematic);
                    }
                    break;
            }
        }

        private void csoGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {
                DataGridViewComboBoxEditingControl cbo = e.Control as DataGridViewComboBoxEditingControl;
                cbo.DropDownStyle = ComboBoxStyle.DropDown;
                cbo.Validating += new CancelEventHandler(cbo_Validating);
            }
        }

        void cbo_Validating(object sender, CancelEventArgs e)
        {

            DataGridViewComboBoxEditingControl cbo = sender as DataGridViewComboBoxEditingControl;

            DataGridView grid = cbo.EditingControlDataGridView;

            object value = cbo.Text;

            // Add value to list if not there

            if (cbo.Items.IndexOf(value) == -1)
            {

                DataGridViewComboBoxColumn cboCol = grid.Columns[grid.CurrentCell.ColumnIndex] as DataGridViewComboBoxColumn;

                // Must add to both the current combobox as well as the template, to avoid duplicate entries...

                cbo.Items.Add(value);
                cboCol.Items.Add(value);
                grid.CurrentCell.Value = value;

            }

        }
    }
}
