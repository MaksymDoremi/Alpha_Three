using System;
using Alpha_Three.src.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.Objects;
using Alpha_Three.src.logger;

namespace Alpha_Three.src.commands.PassengerCommands
{
    public class RetrievePassengerCommand : ICommand
    {
        public string Execute()
        {
            PassengerBLL bll = new PassengerBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Passenger> passengers = new List<Passenger>(bll.GetAllList());
                if (passengers is not null)
                {
                    passengers.ForEach(passenger => stringBuilder.AppendLine(passenger.ToString()));
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

            return "Passengers: \n" + stringBuilder.ToString();
        }
    }
}
