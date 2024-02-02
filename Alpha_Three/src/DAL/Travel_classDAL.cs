using Alpha_Three.src.db;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.DAL
{
    public class Travel_classDAL : IFunctions<Travel_class>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Travel_class> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Travel_class> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Travel_class";
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(new SqlCommand(query, DatabaseConnection.GetConnection())))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    DatabaseConnection.GetConnection().Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                DatabaseConnection.GetConnection().Close();
                throw;
            }
        }

        public List<Travel_class>? GetAllList()
        {
            List<Travel_class> items = new List<Travel_class>();
            try
            {
                DataTable dataTable = GetAllDatatable();
                foreach (DataRow row in dataTable.Rows)
                {
                    items.Add(new Travel_class((int)row["ID"], (string)row["Name"]));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return items;
        }

        public Travel_class? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Travel_class element)
        {
            throw new NotImplementedException();
        }

        public bool Update(Travel_class element)
        {
            throw new NotImplementedException();
        }
    }
}
