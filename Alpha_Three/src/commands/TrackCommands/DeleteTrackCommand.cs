using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using System;
using Alpha_Three.src.application;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.TrackCommands
{
    internal class DeleteTrackCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            TrackBLL bll = new TrackBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Track> tickets = new List<Track>(bll.GetAllList());
                tickets.ForEach(ticket => stringBuilder.AppendLine(ticket.ToString()));

                Application.Print_message_line("Tracks: \n" + stringBuilder.ToString());

                Application.Print_message("Track_ID: ");
                int id = int.Parse(Console.ReadLine());

                bll.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Track deleted successfully!";
        }
    }
}
