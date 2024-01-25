using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands
{
    public class ClearCommand : ICommand
    {
        public string Execute()
        {
            Console.Clear();
            return null;
        }
    }
}
