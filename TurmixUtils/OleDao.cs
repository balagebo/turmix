using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TurmixUtils
{
    public abstract class OleDao
    {
        protected OleDbConnection connection;

        public OleDbConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public OleDao()
        {
            GetConnection();
            if (connection.State == System.Data.ConnectionState.Open) 
                Init();
        }        

        public void CloseConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)

                    connection.Dispose();
                connection = null;
            }
            catch (Exception)
            {
            }
        }

        public abstract void Init();
        protected abstract void GetConnection();
    }
}
