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
    internal class UpdateStationCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StationBLL bll = new StationBLL();

            try
            {
                List<Station> stations = new List<Station>(bll.GetAllList());
                stations.ForEach(station => stringBuilder.AppendLine(station.ToString()));

                Application.Print_message_line("Stations: \n" + stringBuilder.ToString());

                Application.Print_message("Station_ID: ");
                int id = int.Parse(Console.ReadLine());

                Application.Print_message("Name: ");
                string name = Console.ReadLine();

                Application.Print_message("Address: ");
                string address = Console.ReadLine();


                Station element = new Station(id, name, address);

                bll.Update(element);

            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }
            return "Station updated successfully!";
        }
    }
}
