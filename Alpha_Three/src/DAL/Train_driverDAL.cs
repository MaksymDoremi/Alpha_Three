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
    public class Train_driverDAL : IFunctions<Train_driver>
    {
        public bool Delete(int id)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "delete from Train_driver where ID = @id";
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

        public string ExportToJSON(List<Train_driver> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Train_driver> list, string path)
        {
            throw new NotImplementedException();
        }
        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Train_driver";
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
                return null;
            }
        }

        public List<Train_driver>? GetAllList()
        {
            List<Train_driver> items = new List<Train_driver>();
            DataTable dataTable = GetAllDatatable();
            foreach (DataRow row in dataTable.Rows)
            {
                items.Add(new Train_driver((int)row["ID"], (string)row["Name"], (string)row["Surname"], (string)row["Email"]));
            }

            return items;
        }

        public Train_driver? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            try
            {
                string jsonString = "";
                jsonString = File.ReadAllText(path);
                List<Train_driver> train_drivers = JsonSerializer.Deserialize<List<Train_driver>>(jsonString);

                foreach (Train_driver element in train_drivers)
                {
                    Insert(element);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Train_driver element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "insert into Train_driver(Name, Surname, Email) values(@name, @surname, @email)";
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

        public bool Update(Train_driver element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "update Train_driver set Name = @name, Surname = @surname, Email = @email where ID = @id";
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
