using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Console.WriteLine("Drives: \n" + stringBuilder.ToString());

                Console.Write("Drive_ID: ");
                int id = int.Parse(Console.ReadLine());

                if (bll.Delete(id))
                {
                    return "Drive deleted successfully!";
                }
                else
                {
                    return "Error deleting drive. Please try again.";
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.ToString();
            }
        }

        public string View()
        {
            throw new NotImplementedException();
        }
    }
}
