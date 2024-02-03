using System;
using Alpha_Three.src.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.commands.TrainCommands;
using Alpha_Three.src.logger;
using Alpha_Three.src.application;

namespace Alpha_Three.src.commands.TrainCommands
{
    public class TrainCommand : ICommand
    {
        public string Execute()
        {
            Application.Print_message_line(View());
            Run();
            return "";
        }

        /// <summary>
        /// Main loop for the train commands
        /// </summary>
        public void Run()
        {
            Dictionary<string, ICommand> myCommands = new Dictionary<string, ICommand>()
            {
                { "1", new CreateTrainCommand() },
                { "2", new RetrieveTrainCommand() },
                { "3", new UpdateTrainCommand() },
                { "4", new DeleteTrainCommand() },
                { "5", new ImportJsonTrainCommand() },
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
                Application.Print_message("alfa/tables/train:$ ");
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

        /// <summary>
        /// Show all command available
        /// </summary>
        /// <returns></returns>
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
