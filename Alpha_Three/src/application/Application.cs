using Alpha_Three.src.commands;
using Alpha_Three.src.commands.ReportCommands;
using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.application
{
    public class Application
    {
        /// <summary>
        /// Uses Console.WriteLine()
        /// </summary>
        /// <param name="message"></param>
        public static void Print_message_line(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Uses Console.Write()
        /// </summary>
        /// <param name="message"></param>
        public static void Print_message(string message)
        {
            Console.Write(message);
        }
        /// <summary>
        /// Main loop for the all commands
        /// </summary>
        public void Run()
        {
            Dictionary<string, ICommand> myCommands = new Dictionary<string, ICommand>()
            {
                { "help", new HelpCommand("- help - shows usable commands\n" +
                "- exit - exit program\n" +
                "- clear - clear console\n" +
                "- tables - work with tables\n" +
                "- report - generate report") },
                { "clear", new ClearCommand()},
                { "tables", new TablesCommand()},
                { "report", new ReportCommand()}
            };


            string command = String.Empty;
            Print_message_line("Type 'help'");
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Application.Print_message("alfa:$ ");
                command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    break;
                }

                if (myCommands.ContainsKey(command.ToLower()))
                {
                    Print_message_line(myCommands[command.ToLower()].Execute());
                }
                else
                {
                    Print_message_line("Unknown command");
                }

            }
        }
    }
}
