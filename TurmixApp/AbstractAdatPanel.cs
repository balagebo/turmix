using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TurmixLog
{
	public partial class AbstarctAdatPanel : Form
	{
		protected string tableName;
		protected bool cancel;
		protected MySqlDataAdapter adapter;
		protected DataSet dataSet = new DataSet();

        protected KiosztasDao dao;

        private AbstarctAdatPanel() { }

        protected DataView dataView;

		public AbstarctAdatPanel(string tableName)
		{
            dao = new KiosztasDao();
			this.tableName = tableName;
			InitializeComponent();

			InitializeData();
		}

		private void InitializeData()
		{
            using (MySqlCommand cmd = new MySqlCommand(string.Format("select * from {0}", this.tableName), dao.Connection))
            {
                cmd.CommandTimeout = 30;
                adapter = new MySqlDataAdapter(cmd);

                MySqlCommandBuilder cBuilder = new MySqlCommandBuilder(adapter);
                cBuilder.SetAllValues = false;
                cBuilder.ConflictOption = ConflictOption.OverwriteChanges;

                adapter.InsertCommand = cBuilder.GetInsertCommand();
                adapter.UpdateCommand = cBuilder.GetUpdateCommand();
                adapter.Fill(dataSet);

                //A DataView kell a filtereléshez
                dataView = dataSet.Tables[0].DefaultView;
                autoGrid.DataSource = dataView;
            }

            CustomizeTableUI();
		}

		protected virtual void CustomizeTableUI()
		{
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			try
			{
				adapter.Update(dataSet, tableName);
			}
			catch (MySqlException mse)
			{
				MessageBox.Show("Az adatbázis frissítése nem sikerült!\nEllenőrizze, hogy minden szükséges érték megvan-e és hogy az értékek megfelelőek.",
					"Frissítés sikertelen", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cancel = true;
			}
		}

		protected virtual void autoGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
		}

		private void AutoAdatPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = cancel;
			cancel = false;
		}

		protected virtual void AbstarctAdatPanel_Load(object sender, EventArgs e)
		{
			autoGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		protected virtual void autoGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			switch (e.ColumnIndex)
			{
				case 0:
					string old = autoGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
					autoGrid[e.ColumnIndex, e.RowIndex].Value = old.ToUpper();
					break;
			}
		}

        protected virtual void searchTx_TextChanged(object sender, EventArgs e)
        {
            //if (searchTx.Text.Length > 0)
            {
                string filterTx = autoGrid.Columns[0].Name + " like '" + searchTx.Text + "%'";

                dataView.RowFilter = filterTx;
            }
        }
	}
}
