using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.TrainCommands
{
    public class RetrieveTrainCommand : ICommand
    {
        public string Execute()
        {
            TrainBLL bll = new TrainBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Train> trains = new List<Train>(bll.GetAllList());
                if (trains is not null)
                {
                    trains.ForEach(train => stringBuilder.AppendLine(train.ToString()));
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

            return "Trains: \n" + stringBuilder.ToString();
        }
    }
}
