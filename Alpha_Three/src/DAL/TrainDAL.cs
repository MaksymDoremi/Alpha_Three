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
    public class TrainDAL : IFunctions<Train>
    {
        public bool Delete(int id)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "delete from Train where ID = @id";
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

        public string ExportToJSON(List<Train> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Train> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Train";
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

        public List<Train>? GetAllList()
        {
            List<Train> items = new List<Train>();
            DataTable dataTable = GetAllDatatable();
            foreach (DataRow row in dataTable.Rows)
            {
                items.Add(new Train((int)row["ID"], (string)row["Brand"], (string)row["Model"], (int)row["Capacity"]));
            }

            return items;
        }

        public Train? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            try
            {
                string jsonString = "";
                jsonString = File.ReadAllText(path);
                List<Train> trains = JsonSerializer.Deserialize<List<Train>>(jsonString);

                foreach (Train element in trains)
                {
                    Insert(element);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Train element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "insert into Train(Brand, Model, Capacity) values(@brand, @model, @capacity)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@brand", element.Brand);
                    cmd.Parameters.AddWithValue("@model", element.Model);
                    cmd.Parameters.AddWithValue("@capacity", element.Capacity);

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

        public bool Update(Train element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "update Train set Brand = @brand, Model = @model, Capacity = @capacity where ID = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", element.ID);
                    cmd.Parameters.AddWithValue("@brand", element.Brand);
                    cmd.Parameters.AddWithValue("@model", element.Model);
                    cmd.Parameters.AddWithValue("@capacity", element.Capacity);

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
