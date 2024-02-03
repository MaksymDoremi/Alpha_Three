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
        /// <summary>
        /// Clears console
        /// </summary>
        /// <returns></returns>
        public string Execute()
        {
            Console.Clear();
            return null;
        }
    }
}
