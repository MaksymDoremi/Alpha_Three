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
    public class PassengerDAL : IFunctions<Passenger>
    {
        public bool Delete(int id)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "delete from Passenger where ID = @id";
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

        public string ExportToJSON(List<Passenger> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Passenger> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Passenger";
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

        public List<Passenger>? GetAllList()
        {
            List<Passenger> items = new List<Passenger>();
            DataTable dataTable = GetAllDatatable();
            foreach (DataRow row in dataTable.Rows)
            {
                items.Add(new Passenger((int)row["ID"], (string)row["Name"], (string)row["Surname"], (string)row["Email"]));
            }
            return items;
        }

        public Passenger? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            try
            {
                string jsonString = "";
                jsonString = File.ReadAllText(path);
                List<Passenger> passengers = JsonSerializer.Deserialize<List<Passenger>>(jsonString);

                foreach (Passenger element in passengers)
                {
                    Insert(element);
                }
            }
            catch
            {
                throw;
            }
            
        }

        public bool Insert(Passenger element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "insert into Passenger(Name, Surname, Email) values(@name, @surname, @email)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", element.Name);
                    cmd.Parameters.AddWithValue("@surname", element.Surname);
                    cmd.Parameters.AddWithValue("@email", element.Email);

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

        public bool Update(Passenger element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "update Passenger set Name = @name, Surname = @surname, Email = @email where ID = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", element.ID);
                    cmd.Parameters.AddWithValue("@name", element.Name);
                    cmd.Parameters.AddWithValue("@surname", element.Surname);
                    cmd.Parameters.AddWithValue("@email", element.Email);

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
