using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LogServices.Settings
{
    class DataAccess
    {
        private Connection _connection = new Connection();
        private SqlDataReader _reader;
        private DataTable _tabla = new DataTable();

        public void ExecuteSP(string procedureName, Dictionary<string, object> parameters = null)
        {
            var command = new SqlCommand(procedureName)
            {
                CommandTimeout = 60
            };

            if (parameters != null)
                foreach (var item in parameters)
                {
                    var param = new SqlParameter(item.Key, item.Value)
                    {
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);
                }

            command.CommandType = CommandType.StoredProcedure;
            command.Connection = _connection.OpenConnection();
            _reader = command.ExecuteReader();
            command.Connection = _connection.CloseConnection();
        }

    }
}