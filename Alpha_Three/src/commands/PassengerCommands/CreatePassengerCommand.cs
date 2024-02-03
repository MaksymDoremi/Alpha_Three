using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.logger;

namespace Alpha_Three.src.commands.PassengerCommands
{
    public class CreatePassengerCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            StringBuilder stringBuilder = new StringBuilder();

            try
            {

                Application.Print_message("Name: ");
                string name = Console.ReadLine();

                stringBuilder.Clear();
                Application.Print_message("Surname: ");
                string surname = Console.ReadLine();

                stringBuilder.Clear();;
                Application.Print_message("Email: ");
                string email = Console.ReadLine();

                Passenger element = new Passenger(0, name, surname, email);
                PassengerBLL bll = new PassengerBLL();


                if (bll.Insert(element))
                {
                    return "Passenger inserted successfully!";

                }           
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Couldn't insert passenger";
        }

        public string View()
        {
            throw new NotImplementedException();
        }
    }
}
