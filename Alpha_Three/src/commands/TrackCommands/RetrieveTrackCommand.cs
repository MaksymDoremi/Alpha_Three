using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;

namespace Alpha_Three.src.commands.TrackCommands
{
    internal class RetrieveTrackCommand : ICommand
    {
        public string Execute()
        {
            TrackBLL bll = new TrackBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Track> tracks = new List<Track>(bll.GetAllList());
                if (tracks is not null)
                {
                    tracks.ForEach(track => stringBuilder.AppendLine(track.ToString()));
                }
                else
                {
                    stringBuilder.AppendLine("EMPTY");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return "Tracks: \n" + stringBuilder.ToString();
        }
    }
}
