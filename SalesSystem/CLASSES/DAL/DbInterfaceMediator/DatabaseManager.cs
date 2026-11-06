using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SalesSystem.CLASSES.DAL.DbInterfaceMediator
{
    public class DatabaseManager
    {

        private readonly ConnectDB _dbConnection;

        public DatabaseManager()
        {
            _dbConnection = new ConnectDB();
        }

        public DataTable GetData(string procedureName, SqlParameter[] parameters = null)
        {
            try
            {
                _dbConnection.OpenConnection();
                var data = _dbConnection.ExecuteQuery(procedureName, parameters);
                return data;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }

        public void ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
        {
            try
            {
                _dbConnection.OpenConnection();
                _dbConnection.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }


    }

}
