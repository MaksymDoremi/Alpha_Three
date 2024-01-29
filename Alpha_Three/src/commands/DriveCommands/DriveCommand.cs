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

namespace Alpha_Three.src.commands.DriveCommands
{
    internal class DriveCommand : ICommand
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
                { "1", new CreateDriveCommand() },
                { "2", new RetrieveDriveCommand() },
                { "3", new UpdateDriveCommand() },
                { "4", new DeleteDriveCommand() },
                { "clear", new ClearCommand() },
                { "help", new HelpCommand("- help - shows usable commands\n" +
                "- exit - exit program\n" +
                "- clear - clear console\n" +
                "- 1 - create \n" +
                "- 2 - retrieve \n" +
                "- 3 - update \n" +
                "- 4 - delete \n")}
            };


            string command = String.Empty;
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Application.Print_message("alfa/tables/drive:$ ");
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
            return "1) create \n" +
                "2) retrieve \n" +
                "3) update \n" +
                "4) delete \n";
        }
    }
}
