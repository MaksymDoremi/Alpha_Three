using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using Alpha_Three.src.application;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.TrainCommands
{
    public class ImportJsonTrainCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        /// <summary>
        /// Requires path to json and imports trains
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            try
            {
                Application.Print_message("Path to JSON file: ");
                string path = Console.ReadLine();


                TrainBLL bll = new TrainBLL();


                bll.ImportFromJSON(path);

            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "JSON file imported successfully!";
        }
    }
}
