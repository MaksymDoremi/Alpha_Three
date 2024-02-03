using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;

namespace Alpha_Three.src.commands.Train_driverCommands
{
    public class DeleteTrain_driverCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        /// <summary>
        /// Runs deletion of the train driver
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            Train_driverBLL bll = new Train_driverBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Train_driver> train_drivers = new List<Train_driver>(bll.GetAllList());
                train_drivers.ForEach(train_driver => stringBuilder.AppendLine(train_driver.ToString()));

                Application.Print_message_line("Train_drivers: \n" + stringBuilder.ToString());

                Application.Print_message("Train_driver_ID: ");
                int id = int.Parse(Console.ReadLine());

                bll.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Train_driver deleted successfully!";
        }
    }
}
