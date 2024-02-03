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

namespace Alpha_Three.src.commands.TrainCommands
{
    public class CreateTrainCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        /// <summary>
        /// Runs creation of the train
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            try
            {
                Application.Print_message("Brand: ");
                string brand = Console.ReadLine();

                Application.Print_message("Model: ");
                string model = Console.ReadLine();
                ;
                Application.Print_message("Capacity: ");
                int capacity = Int32.Parse(Console.ReadLine());

                Train element = new Train(0, brand, model, capacity);
                TrainBLL bll = new TrainBLL();

                bll.Insert(element);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Train inserted successfully!";
        }
    }
}
