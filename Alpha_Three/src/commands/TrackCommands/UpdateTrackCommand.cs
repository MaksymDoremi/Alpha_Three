using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.application;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;

namespace Alpha_Three.src.commands.TrackCommands
{
    internal class UpdateTrackCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }


        public string Run()
        {
            StationBLL stationBLL = new StationBLL();
            TrackBLL bll = new TrackBLL();
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                List<Track> tracks = new List<Track>(bll.GetAllList());
                List<Station> stations = new List<Station>(stationBLL.GetAllList());
                
                if (tracks is not null)
                {
                    tracks.ForEach(track => stringBuilder.AppendLine(track.ToString()));
                }
                else
                {
                    stringBuilder.AppendLine("EMPTY");
                }
                Application.Print_message_line("Tracks available: \n" + stringBuilder.ToString());
                Application.Print_message("Track_ID: ");
                int track_ID = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                if (stations is not null)
                {
                    stations.ForEach(station => stringBuilder.AppendLine(station.ToString()));
                }
                else
                {
                    stringBuilder.AppendLine("EMPTY");
                }

                Application.Print_message_line("Stations available: \n" + stringBuilder.ToString());
                Application.Print_message("Origin Station_ID: ");
                int origin_station_ID = int.Parse(Console.ReadLine());

                Application.Print_message("Origin Station_ID: ");
                int destination_station_ID = int.Parse(Console.ReadLine());

                Application.Print_message("Length in km: ");
                int length = int.Parse(Console.ReadLine());

                
                Track element = new Track(track_ID, origin_station_ID, destination_station_ID, length);

                bll.Update(element);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Track inserted successfully!";
        }
    }
}
