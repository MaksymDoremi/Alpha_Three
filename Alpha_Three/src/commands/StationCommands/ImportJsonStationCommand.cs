using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.StationCommands
{
    internal class ImportJsonStationCommand : ICommand
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

                StationBLL bll = new StationBLL(); 

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
