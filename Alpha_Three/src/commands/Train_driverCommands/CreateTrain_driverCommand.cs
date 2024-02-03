using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Alpha_Three.src.application;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.Train_driverCommands
{
    public class CreateTrain_driverCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        /// <summary>
        /// Runs creation of the train driver
        /// </summary>
        /// <returns></returns>
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

                stringBuilder.Clear(); ;
                Application.Print_message("Email: ");
                string email = Console.ReadLine();

                Train_driver element = new Train_driver(0, name, surname, email);
                Train_driverBLL bll = new Train_driverBLL();


                bll.Insert(element);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Train_driver inserted successfully!";
        }
    }
}
