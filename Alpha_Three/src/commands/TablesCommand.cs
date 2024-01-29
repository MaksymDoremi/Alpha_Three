using Alpha_Three.src.commands.DriveCommands;
using Alpha_Three.src.commands.PassengerCommands;
using Alpha_Three.src.commands.StationCommands;
using Alpha_Three.src.commands.TicketCommands;
using Alpha_Three.src.commands.TrackCommands;
using Alpha_Three.src.commands.Train_driverCommands;
using Alpha_Three.src.commands.TrainCommands;
using Alpha_Three.src.commands.Travel_classCommands;
using Alpha_Three.src.application;
using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands
{
    internal class TablesCommand : ICommand
    {
        public string Execute()
        {

            Application.Print_message_line(View());
            Run();

            return "";

        }

        public void Run()
        {
            Dictionary<string, ICommand> myCommands = new Dictionary<string, ICommand>()
            {
                { "1", new DriveCommand() },
                { "2", new PassengerCommand() },
                { "3", new StationCommand() },
                { "4", new TicketCommand() },
                { "5", new TrackCommand() },
                { "6", new Train_driverCommand() },
                { "7", new TrainCommand() },
                { "8", new Travel_classCommand() },
                { "clear", new ClearCommand() },
                { "help", new HelpCommand("- help - shows usable commands\n" +
                "- exit - exit \n" +
                "- clear - clear console\n" +
                "- 1-8 - choose table")}
            };


            string command = String.Empty;
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Application.Print_message("alfa/tables:$ ");
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

        public string View()
        {
            return "1) Drive\n" +
           "2) Passenger\n" +
           "3) Station\n" +
           "4) Ticket\n" +
           "5) Track\n" +
           "6) Train_driver\n" +
           "7) Train\n" +
           "8) Travel_class (retrieve)";
        }
    }
}
