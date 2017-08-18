using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurmixLog;

namespace TurmixBatch
{
    public partial class DataForm : Form
    {
        private Font boldFont;

        public DataForm(List<TenykobRecord> data)
        {
            InitializeComponent();

            boldFont = new Font(dataGrid.DefaultCellStyle.Font, FontStyle.Bold);

            DataTable table = new DataTable();
            table.Columns.Add("FH Kód", typeof(string));
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
