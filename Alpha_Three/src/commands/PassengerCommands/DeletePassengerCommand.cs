using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.PassengerCommands
{
    internal class DeletePassengerCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            PassengerBLL bll = new PassengerBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Passenger> passengers = new List<Passenger>(bll.GetAllList());
                passengers.ForEach(passenger => stringBuilder.AppendLine(passenger.ToString()));

                Application.Print_message_line("Passengers: \n" + stringBuilder.ToString());

                Application.Print_message("Passenger_ID: ");
                int id = int.Parse(Console.ReadLine());

                bll.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Passenger deleted successfully!";
        }
    }
}
