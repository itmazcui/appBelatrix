using System.Data;
using System.Data.SqlClient;

namespace LogServices.Settings
{
    public class Connection
    {
        private SqlConnection Conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

        public SqlConnection OpenConnection()
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();

            return Conn;
        }

        public SqlConnection CloseConnection()
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();

            return Conn;
        }

    }
}
