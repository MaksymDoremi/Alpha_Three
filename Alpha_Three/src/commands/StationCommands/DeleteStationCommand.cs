using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.application;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.StationCommands
{
    internal class DeleteStationCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            StationBLL bll = new StationBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Station> passengers = new List<Station>(bll.GetAllList());
                passengers.ForEach(drive => stringBuilder.AppendLine(drive.ToString()));

                Application.Print_message_line("Stations: \n" + stringBuilder.ToString());

                Application.Print_message("Station_ID: ");
                int id = int.Parse(Console.ReadLine());

                bll.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Station deleted successfully!";
        }
    }
}
