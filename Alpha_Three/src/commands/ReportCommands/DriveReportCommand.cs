using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.ReportCommands
{
    internal class DriveReportCommand : ICommand
    {

        public string Execute()
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["driveViewReportPath"];

                if (Report(filePath))
                {
                    return $"Drives reported successfully at {filePath}";
                }

                return $"Nothing to report";
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

        }

        /// <summary>
        /// Write report to path given
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Report(string path)
        {
            try
            {
                DriveViewBLL bll = new DriveViewBLL();
                DataTable tickets = bll.GetAllDatatable();

                StringBuilder stringbuilder = new StringBuilder();
                stringbuilder.AppendLine($"Drive report\nDate: {DateTime.Now}\n" +
                    $"Beggining\n" +
                    $"====================================================================================");
                if (tickets is not null)
                {
                    DriveView drive;
                    foreach (DataRow row in tickets.Rows)
                    {
                        drive = new DriveView(
                            (string)row["Train driver name"],
                            (string)row["Train driver surname"],
                            (string)row["Train driver email"],
                            (string)row["From"],
                            (string)row["To"],
                            (string)row["Train brand"],
                            (string)row["Train model"],
                            (DateTime)row["Departure"],
                            (DateTime)row["Arrival"]);

                        stringbuilder.AppendLine(drive.ToString());
                    }


                    stringbuilder.AppendLine(
                        "====================================================================================\n" +
                        "End");

                    File.WriteAllText(path, stringbuilder.ToString());
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return false;
        }
    }
}
