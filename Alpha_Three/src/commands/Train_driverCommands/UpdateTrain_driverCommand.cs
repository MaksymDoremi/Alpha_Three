using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.application;
using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;

namespace Alpha_Three.src.commands.Train_driverCommands
{
    public class UpdateTrain_driverCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Train_driverBLL bll = new Train_driverBLL();

            try
            {
                List<Train_driver> train_drivers = new List<Train_driver>(bll.GetAllList());
                train_drivers.ForEach(train_driver => stringBuilder.AppendLine(train_driver.ToString()));

                Application.Print_message_line("Train_drivers: \n" + stringBuilder.ToString());

                Application.Print_message("Train_driver_ID: ");
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

                Train_driver element = new Train_driver(id, name, surname, email);


                bll.Update(element);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Train_driver updated successfully!";
        }
    }
}
