using Alpha_Three.src.db;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alpha_Three.src.DAO
{
    public class DriveDAL : IFunctions<Drive>
    {
        public bool Delete(int id)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "delete from Drive where ID = @id";
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

        public string ExportToJSON(List<Drive> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Drive> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Drive";
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

        public List<Drive>? GetAllList()
        {
            List<Drive> items = new List<Drive>();
            DataTable dataTable = GetAllDatatable();
            foreach (DataRow row in dataTable.Rows)
            {
                items.Add(new Drive((int)row["ID"], (int)row["Train_driver_ID"], (int)row["Track_ID"], (int)row["Train_ID"], (DateTime)row["Departure"], (DateTime)row["Arrival"]));
            }

            return items;
        }

        public Drive? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Drive element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "insert into Drive(Train_driver_ID, Track_ID, Train_ID, Departure, Arrival) values(@train_driver_ID, @track_ID, @train_ID, @departure, @arrival)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@train_driver_ID", element.Train_driver_ID);
                    cmd.Parameters.AddWithValue("@track_ID", element.Track_ID); 
                    cmd.Parameters.AddWithValue("@train_ID", element.Train_ID); 
                    cmd.Parameters.AddWithValue("@departure", element.Departure); 
                    cmd.Parameters.AddWithValue("@arrival", element.Arrival);

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

        public bool Update(Drive element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "update Drive \r\nset Train_driver_ID = @train_driver_ID, \r\nTrack_ID = @track_ID, \r\nTrain_ID = @train_ID, \r\nDeparture = @departure, \r\nArrival = @arrival  \r\nwhere ID = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", element.ID);
                    cmd.Parameters.AddWithValue("@train_driver_ID", element.Train_driver_ID);
                    cmd.Parameters.AddWithValue("@track_ID", element.Track_ID);
                    cmd.Parameters.AddWithValue("@train_ID", element.Train_ID);
                    cmd.Parameters.AddWithValue("@departure", element.Departure);
                    cmd.Parameters.AddWithValue("@arrival", element.Arrival);

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
