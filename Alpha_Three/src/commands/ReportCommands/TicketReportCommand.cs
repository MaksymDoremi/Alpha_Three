using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.ReportCommands
{
    internal class TicketReportCommand : ICommand
    {
        public string Execute()
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["ticketViewReportPath"];

                if (Report(filePath))
                {
                    return $"Tickets reported successfully at {filePath}";
                }

                return $"Nothing to report";
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

        }

        /// <summary>
        /// Writes report to the path given
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Report(string path)
        {
            try
            {
                TicketViewBLL bll = new TicketViewBLL();
                DataTable tickets = bll.GetAllDatatable();

                StringBuilder stringbuilder = new StringBuilder();
                stringbuilder.AppendLine($"Ticket report\nDate: {DateTime.Now}\n" +
                    $"Beggining\n" +
                    $"====================================================================================");
                if (tickets is not null)
                {
                    TicketView ticket;
                    foreach (DataRow row in tickets.Rows)
                    {
                        ticket = new TicketView(
                            (string)row["Passenger name"],
                            (string)row["Passenger surname"],
                            (string)row["Passenger email"],
                            (string)row["Travel class"],
                            (int)row["Ticket ID"],
                            (string)row["From"],
                            (string)row["To"],
                            (DateTime)row["Departure"],
                            (DateTime)row["Arrival"],
                            (int)row["Seat number"],
                            (DateTime)row["Date of purchase"],
                            (int)row["Price"]);
                        stringbuilder.AppendLine(ticket.ToString());
                    }


                    stringbuilder.AppendLine(
                        "====================================================================================\n" +
                        "End");

                    File.WriteAllText(path, stringbuilder.ToString());
                    return true;
                }
            }catch(Exception ex)
            {
                throw;
            }

            return false;
        }
    }
}
