using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.StationCommands
{
    public class RetrieveStationCommand : ICommand
    {
        public string Execute()
        {
            StationBLL bll = new StationBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Station> stations = new List<Station>(bll.GetAllList());
                if (stations is not null)
                {
                    stations.ForEach(station => stringBuilder.AppendLine(station.ToString()));
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

            return "Stations: \n" + stringBuilder.ToString();
        }
    }
}
