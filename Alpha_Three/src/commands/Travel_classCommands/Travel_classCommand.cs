using Alpha_Three.src.commands.TicketCommands;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using Alpha_Three.src.application;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.Travel_classCommands
{
    internal class Travel_classCommand : ICommand
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
                { "1", new RetrieveTravel_classCommand() },
                { "clear", new ClearCommand() },
                { "help", new HelpCommand("- help - shows usable commands\n" +
                "- exit - exit program\n" +
                "- clear - clear console\n" +
                "- 1 - retrieve \n")}
            };


            string command = String.Empty;
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Application.Print_message("alfa/tables/travel_class:$ ");
                command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    break;
                }

                if (myCommands.ContainsKey(command.ToLower()))
                {
                    try
                    {
                        Application.Print_message_line(myCommands[command.ToLower()].Execute());
                    }
                    catch (Exception ex)
                    {
                        Application.Print_message_line(ex.Message);
                        Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                    }
                }
                else
                {
                    Application.Print_message_line("Unknown command");
                }
            }
        }

        public string View()
        {
            return "1) retrieve \n";
                
        }
    }
}
