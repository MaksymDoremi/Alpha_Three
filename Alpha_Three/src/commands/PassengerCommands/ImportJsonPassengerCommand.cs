using Alpha_Three.src.interfaces;
using System;
using Alpha_Three.src.logger;
using Alpha_Three.src.application;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.Objects;
using System.Xml.Linq;

namespace Alpha_Three.src.commands.PassengerCommands
{
    internal class ImportJsonPassengerCommand : ICommand
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


                PassengerBLL bll = new PassengerBLL();


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
