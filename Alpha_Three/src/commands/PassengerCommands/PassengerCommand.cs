using System;
using Alpha_Three.src.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.commands.DriveCommands;

namespace Alpha_Three.src.commands.PassengerCommands
{
    internal class PassengerCommand : ICommand
    {
        public string Execute()
        {
            Console.WriteLine(View());
            Run();
            return "";
        }

        public void Run()
        {
            Dictionary<string, ICommand> myCommands = new Dictionary<string, ICommand>()
            {
                { "1", new CreatePassengerCommand() },
                { "2", new RetrievePassengerCommand() },
                { "3", new UpdatePassengerCommand() },
                { "4", new DeletePassengerCommand() },
                { "5", new ImportJsonPassengerCommand() },
                { "clear", new ClearCommand() },
                { "help", new HelpCommand("- help - shows usable commands\n" +
                "- exit - exit program\n" +
                "- clear - clear console\n" +
                "- 1 - create \n" +
                "- 2 - retrieve \n" +
                "- 3 - update \n" +
                "- 4 - delete \n" +
                "- 5 - import json file\n")}
            };

            string command = String.Empty;
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("alfa/tables/passenger:$ ");
                command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    break;
                }

                if (myCommands.ContainsKey(command.ToLower()))
                {
                    Console.WriteLine(myCommands[command.ToLower()].Execute());
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }

        public string View()
        {
            return "1) create \n" +
                "2) retrieve \n" +
                "3) update \n" +
                "4) delete \n" +
                "5) import json file\n";
        }
    }
}
