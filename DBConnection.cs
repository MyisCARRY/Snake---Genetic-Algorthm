using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SnakeGA
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                try
                {
                    string connstring = string.Format($"Server={DBCredentials.Server}; database={DBCredentials.DBName}; UID={DBCredentials.UID}; password={DBCredentials.Password}");
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }

        public static void UpdateInsert(string query)
        {
            var dbCon = Instance();

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                //dbCon.Close();
            }
        }
    }
}
