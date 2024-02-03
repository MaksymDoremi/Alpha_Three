using Alpha_Three.src.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.DAL
{
    internal class TicketViewDAL
    {

        public DataTable? GetAllDatatable()
        {
            if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
            {
                DatabaseConnection.GetConnection().Open();
            }

            string query = "select * from Ticket_information";
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
    }
}
