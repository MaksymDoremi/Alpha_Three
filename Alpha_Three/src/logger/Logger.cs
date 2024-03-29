﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.logger
{
    public static class Logger
    {
        private static readonly object _lock = new();

        /// <summary>
        /// Writes program logs to file specidied in App.config at "logFilePath"
        /// </summary>
        /// <param name="message"></param>
        /// <param name="error"></param>
        public static void WriteLog(string message, bool error)
        {
            lock (_lock)
            {
                string logMessage = string.Empty;
                if (!error)
                {
                    logMessage = $"LOG [{DateTime.Now}]: {message}\n";

                }
                else
                {
                    logMessage = $"ERROR [{DateTime.Now}]: {message}\n";
                }

                File.AppendAllText(ConfigurationManager.AppSettings["logFilePath"], logMessage);
            }
        }
    }
}
