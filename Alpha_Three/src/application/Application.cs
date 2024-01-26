using Alpha_Three.src.commands;
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
                { "tables", new TablesCommand()}
            };


            string command = String.Empty;
            Console.WriteLine("Type 'help'");
            while (true)
            {Console.OutputEncoding = Encoding.UTF8;
                Console.Write("alfa:$ ");
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
    }
}
