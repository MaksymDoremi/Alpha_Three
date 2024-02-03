using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;

namespace Alpha_Three.src.commands.Train_driverCommands
{
    public class RetrieveTrain_driverCommand : ICommand
    {
        /// <summary>
        /// Returns all train drivers
        /// </summary>
        /// <returns></returns>
        public string Execute()
        {
            Train_driverBLL bll = new Train_driverBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Train_driver> train_drivers = new List<Train_driver>(bll.GetAllList());
                if (train_drivers is not null)
                {
                    train_drivers.ForEach(train_driver => stringBuilder.AppendLine(train_driver.ToString()));
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

            return "Train_drivers: \n" + stringBuilder.ToString();
        }
    }
}
