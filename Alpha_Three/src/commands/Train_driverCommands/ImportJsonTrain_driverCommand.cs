using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.application;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;

namespace Alpha_Three.src.commands.Train_driverCommands
{
    public class ImportJsonTrain_driverCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            try
            {
                Application.Print_message("Path to JSON file: ");
                string path = Console.ReadLine();


                Train_driverBLL bll = new Train_driverBLL();


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
