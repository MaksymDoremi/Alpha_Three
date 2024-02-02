using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.StationCommands
{
    internal class CreateStationCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            try
            {
                Application.Print_message("Name: ");
                string name = Console.ReadLine();

                Application.Print_message("Address: ");
                string address = Console.ReadLine();

                Station element = new Station(0, name, address);
                StationBLL bll = new StationBLL();

                bll.Insert(element);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Station inserted successfully!";
        }
    }
}
