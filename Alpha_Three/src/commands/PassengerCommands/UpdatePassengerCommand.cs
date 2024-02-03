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
using Alpha_Three.src.DAL;

namespace Alpha_Three.src.commands.PassengerCommands
{
    public class UpdatePassengerCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            StringBuilder stringBuilder = new StringBuilder();
            PassengerBLL bll = new PassengerBLL();
           
            try
            {
                List<Passenger> passengers = new List<Passenger>(bll.GetAllList());
                passengers.ForEach(passenger => stringBuilder.AppendLine(passenger.ToString()));

                Application.Print_message_line("Passengers: \n" + stringBuilder.ToString());

                Application.Print_message("Passenger_ID: ");
                int id = int.Parse(Console.ReadLine());

                stringBuilder.Clear();

                Application.Print_message("Name: ");
                string name = Console.ReadLine();

                stringBuilder.Clear();
                Application.Print_message("Surname: ");
                string surname = Console.ReadLine();

                stringBuilder.Clear(); ;
                Application.Print_message("Email: ");
                string email = Console.ReadLine();

                Passenger element = new Passenger(id, name, surname, email);


                if (bll.Update(element))
                {
                    return "Passenger updated successfully!";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Couldn't update passenger";
        }
    }
}
