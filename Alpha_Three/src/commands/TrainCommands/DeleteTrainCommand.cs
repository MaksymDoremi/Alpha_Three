using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using Alpha_Three.src.application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.TrainCommands
{
    public class DeleteTrainCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        /// <summary>
        /// Runs deletion of the train
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            TrainBLL bll = new TrainBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Train> trains = new List<Train>(bll.GetAllList());
                trains.ForEach(train => stringBuilder.AppendLine(train.ToString()));

                Application.Print_message_line("Trains: \n" + stringBuilder.ToString());

                Application.Print_message("Train_ID: ");
                int id = int.Parse(Console.ReadLine());

                bll.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Train deleted successfully!";
        }
    }
}
