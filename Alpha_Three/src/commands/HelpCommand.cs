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
        private string helpCommand;
        public HelpCommand(string helpCommand) 
        {
            this.helpCommand = helpCommand;
        }

        /// <summary>
        /// Returns string given from constructor
        /// </summary>
        /// <returns></returns>
        public string Execute()
        {
            return this.helpCommand;
        }
    }
}
