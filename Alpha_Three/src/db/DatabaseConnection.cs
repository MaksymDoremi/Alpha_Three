using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.db
{
    public class DatabaseConnection
    {
        private DatabaseConnection() { }

        private static SqlConnection _connection = null;
        private static readonly object _lock = new object();
        /// <summary>
        /// Database singleton, returns current connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                lock (_lock)
                {
                    if (_connection == null)
                    {
                        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["skolniConnection"].ConnectionString);
                    }
                }
            }
            return _connection;
        }


    }
}
