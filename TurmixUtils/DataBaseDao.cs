using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TurmixUtils
{
    public abstract class MySqlDao
    {
        public MySqlConnection connection;

        private static bool ping;

        public MySqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public MySqlDao()
        {
            GetConnection();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                Init();
            }

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
        protected virtual void GetConnection()
        {
            
        }
    }
}
