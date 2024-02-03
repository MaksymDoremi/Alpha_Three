﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// Executes functionality for the each command
        /// </summary>
        /// <returns></returns>
        string Execute();
     
    }
}
