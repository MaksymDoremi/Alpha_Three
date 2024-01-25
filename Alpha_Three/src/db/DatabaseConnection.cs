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
        public static SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                lock (_lock)
                {
                    if (_connection == null)
                    {
                        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["localConnection"].ConnectionString);
                    }
                }
            }
            return _connection;
        }


    }
}
