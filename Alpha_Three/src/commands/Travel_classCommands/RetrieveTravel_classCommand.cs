using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.Travel_classCommands
{
    internal class RetrieveTravel_classCommand : ICommand
    {
        public string Execute()
        {
            Travel_classBLL bll = new Travel_classBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Travel_class> travel_classes = new List<Travel_class>(bll.GetAllList());
                if (travel_classes is not null)
                {
                    travel_classes.ForEach(travel_class => stringBuilder.AppendLine(travel_class.ToString()));
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

            return "Travel_classes: \n" + stringBuilder.ToString();
        }
    }
}
