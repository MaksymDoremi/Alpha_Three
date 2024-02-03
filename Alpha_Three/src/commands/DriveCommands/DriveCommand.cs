using Alpha_Three.src.application;
using Alpha_Three.src.interfaces;
using System.Text;
using Alpha_Three.src.logger;

namespace Alpha_Three.src.commands.DriveCommands
{
    public class DriveCommand : ICommand
    {
        public string Execute()
        {
            Application.Print_message_line(View());
            Run();
            return "";
        }

        /// <summary>
        /// Main loop for the drive commands
        /// </summary>
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
        /// Show all possible command for the drive
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
