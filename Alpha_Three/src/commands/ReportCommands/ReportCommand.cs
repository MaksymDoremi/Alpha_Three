using Alpha_Three.src.commands.DriveCommands;
using Alpha_Three.src.commands.PassengerCommands;
using Alpha_Three.src.commands.StationCommands;
using Alpha_Three.src.commands.TicketCommands;
using Alpha_Three.src.commands.TrackCommands;
using Alpha_Three.src.commands.Train_driverCommands;
using Alpha_Three.src.commands.TrainCommands;
using Alpha_Three.src.commands.Travel_classCommands;
using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using Alpha_Three.src.application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.ReportCommands
{
    internal class ReportCommand : ICommand
    {
        public string Execute()
        {

            Application.Print_message_line(View());
            Run();

            return "";

        }

        /// <summary>
        /// Run report commands
        /// </summary>
        public void Run()
        {
            Dictionary<string, ICommand> myCommands = new Dictionary<string, ICommand>()
            {
                { "1", new DriveReportCommand() },
                { "2", new TicketReportCommand() },              
                { "help", new HelpCommand("- help - shows usable commands\n" +
                "- exit - exit \n" +
                "- clear - clear console\n" +
                "- 1 - Drive information\n" +
                "- 2 - Ticket information\n")}
            };


            string command = String.Empty;
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Application.Print_message("alfa/report:$ ");
                command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    break;
                }

                if (myCommands.ContainsKey(command.ToLower()))
                {
                    Application.Print_message_line(myCommands[command.ToLower()].Execute());
                }
                else
                {
                    Application.Print_message_line("Unknown command");
                }

            }
        }
        /// <summary>
        /// Show possible command of the report
        /// </summary>
        /// <returns></returns>
        public string View()
        {
            return "1) Drive information\n" +
           "2) Ticket information\n"; ;
        }
    }
}
