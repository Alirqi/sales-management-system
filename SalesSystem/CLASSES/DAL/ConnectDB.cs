using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.CLASSES.DAL
{
    public class ConnectDB
    {
     
            private readonly SqlConnection _connection;

            public ConnectDB()
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = Properties.Settings.Default.Server,
                    InitialCatalog = Properties.Settings.Default.DataBase,
                    IntegratedSecurity = Properties.Settings.Default.Mode != "SQL"
                };

                if (!connectionStringBuilder.IntegratedSecurity)
                {
                    connectionStringBuilder.UserID = Properties.Settings.Default.Username;
                    connectionStringBuilder.Password = Properties.Settings.Default.Password;
                }

                _connection = new SqlConnection(connectionStringBuilder.ToString());
            }

            public void OpenConnection()
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
            }

            public void CloseConnection()
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            public DataTable ExecuteQuery(string procedureName, SqlParameter[] parameters = null)
            {
                var command = new SqlCommand(procedureName, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                var dataTable = new DataTable();
                new SqlDataAdapter(command).Fill(dataTable);

                return dataTable;
            }

            public void ExecuteNonQuery(string procedureName, SqlParameter[] parameters = null)
            {
                var command = new SqlCommand(procedureName, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                command.ExecuteNonQuery();
            }
        

    }

}
