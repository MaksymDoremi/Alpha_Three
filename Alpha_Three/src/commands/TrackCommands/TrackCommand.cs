using System;
using System.Collections.Generic;
using Alpha_Three.src.interfaces;
using System.Linq;
using System.Text;
using Alpha_Three.src.application;
using System.Threading.Tasks;
using Alpha_Three.src.commands.TicketCommands;
using Alpha_Three.src.logger;

namespace Alpha_Three.src.commands.TrackCommands
{
    public class TrackCommand : ICommand
    {
        public string Execute()
        {
            Application.Print_message_line(View());
            Run();
            return "";
        }

        /// <summary>
        /// Main loop for track commands
        /// </summary>
        public void Run()
        {
            Dictionary<string, ICommand> myCommands = new Dictionary<string, ICommand>()
            {
                { "1", new CreateTrackCommand() },
                { "2", new RetrieveTrackCommand() },
                { "3", new UpdateTrackCommand() },
                { "4", new DeleteTrackCommand() },
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
                Application.Print_message("alfa/tables/track:$ ");
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
        /// Shows all track commands
        /// </summary>
        /// <returns></returns>
        public string View()
        {
            return "1) create \n" +
                "2) retrieve \n" +
                "3) update \n" +
                "4) delete \n";
        }
    }
}
