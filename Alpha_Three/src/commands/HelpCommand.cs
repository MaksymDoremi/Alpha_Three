using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands
{
    public class HelpCommand : ICommand
    {
        public string Execute()
        {
            return "- help - shows usable commands\n" +
                "- exit - exit program\n" +
                "- clear - clear console\n" +
                "- tables - work with tables\n" +
                "- report - generate report";
        }
    }
}
