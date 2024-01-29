using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.logger;

namespace Alpha_Three.src.commands.DriveCommands
{
    internal class DeleteDriveCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            DriveBLL bll = new DriveBLL();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                List<Drive> drives = new List<Drive>(bll.GetAllList());
                drives.ForEach(drive => stringBuilder.AppendLine(drive.ToString()));

                Application.Print_message_line("Drives: \n" + stringBuilder.ToString());

                Application.Print_message("Drive_ID: ");
                int id = int.Parse(Console.ReadLine());

                if (bll.Delete(id))
                {
                    return "Drive deleted successfully!";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }
            return "Error deleting drive. Please try again.";
        }

        public string View()
        {
            throw new NotImplementedException();
        }
    }
}
