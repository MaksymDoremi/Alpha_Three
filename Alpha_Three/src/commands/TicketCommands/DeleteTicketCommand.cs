using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.application;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;

namespace Alpha_Three.src.commands.TicketCommands
{
    public class DeleteTicketCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            TicketBLL bll = new TicketBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Ticket> tickets = new List<Ticket>(bll.GetAllList());
                tickets.ForEach(ticket => stringBuilder.AppendLine(ticket.ToString()));

                Application.Print_message_line("Tickets: \n" + stringBuilder.ToString());

                Application.Print_message("Ticket_ID: ");
                int id = int.Parse(Console.ReadLine());

                bll.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Ticket deleted successfully!";
        }
    }
}
