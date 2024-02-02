using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.TicketCommands
{
    internal class RetrieveTicketCommand : ICommand
    {
        public string Execute()
        {
            TicketBLL bll = new TicketBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Ticket> tickets = new List<Ticket>(bll.GetAllList());
                if (tickets is not null)
                {
                    tickets.ForEach(ticket => stringBuilder.AppendLine(ticket.ToString()));
                }
                else
                {
                    stringBuilder.AppendLine("EMPTY");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return "Tickets: \n" + stringBuilder.ToString();
        }
    }
}
