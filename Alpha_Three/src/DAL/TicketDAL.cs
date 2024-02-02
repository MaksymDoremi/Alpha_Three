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
    public class TicketDAL : IFunctions<Ticket>
    {
        public bool Delete(int id)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "delete from Ticket where ID = @id";
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

        public string ExportToJSON(List<Ticket> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Ticket> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Ticket";
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

        public List<Ticket>? GetAllList()
        {
            List<Ticket> items = new List<Ticket>();
            try
            {
                DataTable dataTable = GetAllDatatable();
                foreach (DataRow row in dataTable.Rows)
                {
                    items.Add(new Ticket(
                        (int)row["ID"],
                        (int)row["Passenger_ID"],
                        (int)row["Drive_ID"],
                        (int)row["Travel_class_ID"],
                        (int)row["Seat_number"],
                        (DateTime)row["Date_of_purchase"],
                        (int)row["Price"]
            ));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return items;
        }

        public Ticket? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Ticket element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "insert into Ticket(Passenger_ID, Drive_ID, Travel_class_ID, Seat_number, Date_of_purchase, Price) values(@passenger_ID, @drive_ID, @travelClass_ID, @seatNumber, @dateOfPurchase, @price)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@passenger_ID", element.Passenger_ID);
                    cmd.Parameters.AddWithValue("@drive_ID", element.Drive_ID);
                    cmd.Parameters.AddWithValue("@travelClass_ID", element.Travel_class_ID);
                    cmd.Parameters.AddWithValue("@seatNumber", element.Seat_number);
                    cmd.Parameters.AddWithValue("@dateOfPurchase", element.Date_of_purchase);
                    cmd.Parameters.AddWithValue("@price", element.Price);

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

        public bool Update(Ticket element)
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "update Ticket set Passenger_ID = @passenger_ID, Drive_ID = @drive_ID, Travel_class_ID = @travelClass_ID, Seat_number = @seatNumber, Date_of_purchase = @dateOfPurchase, Price = @price where ID = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", element.ID);
                    cmd.Parameters.AddWithValue("@passenger_ID", element.Passenger_ID);
                    cmd.Parameters.AddWithValue("@drive_ID", element.Drive_ID);
                    cmd.Parameters.AddWithValue("@travelClass_ID", element.Travel_class_ID);
                    cmd.Parameters.AddWithValue("@seatNumber", element.Seat_number);
                    cmd.Parameters.AddWithValue("@dateOfPurchase", element.Date_of_purchase);
                    cmd.Parameters.AddWithValue("@price", element.Price);

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
