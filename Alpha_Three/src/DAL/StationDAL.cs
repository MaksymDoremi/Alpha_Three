using Alpha_Three.src.db;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Alpha_Three.src.DAL
{
    public class StationDAL : IFunctions<Station>
    {
        public bool Delete(int id)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "delete from Station where ID = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
                DatabaseConnection.GetConnection().Close();

                return true;
            }
            catch (Exception ex)
            {
                DatabaseConnection.GetConnection().Close();
                throw;
            }
        }

        public string ExportToJSON(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Station> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Station> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Station";
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

        public List<Station>? GetAllList()
        {
            List<Station> items = new List<Station>();
            try
            {
                DataTable dataTable = GetAllDatatable();
                foreach (DataRow row in dataTable.Rows)
                {
                    items.Add(new Station((int)row["ID"], (string)row["Name"], (string)row["Address"]));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return items;
        }

        public Station? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            try
            {
                string jsonString = "";
                jsonString = File.ReadAllText(path);
                List<Station> stations = JsonSerializer.Deserialize<List<Station>>(jsonString);

                foreach (Station element in stations)
                {
                    Insert(element);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Station element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "insert into Station(Name, Address) values(@name, @address)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", element.Name);
                    cmd.Parameters.AddWithValue("@address", element.Address);

                    cmd.ExecuteNonQuery();
                }
                DatabaseConnection.GetConnection().Close();

                return true;
            }
            catch (Exception ex)
            {
                DatabaseConnection.GetConnection().Close();
                throw;
            }
        }

        public bool Update(Station element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "update Station set Name=@name, Address=@address where ID = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", element.ID);
                    cmd.Parameters.AddWithValue("@name", element.Name);
                    cmd.Parameters.AddWithValue("@address", element.Address);

                    cmd.ExecuteNonQuery();
                }
                DatabaseConnection.GetConnection().Close();

                return true;
            }
            catch (Exception ex)
            {
                DatabaseConnection.GetConnection().Close();
                throw;
            }
        }
    }
}
