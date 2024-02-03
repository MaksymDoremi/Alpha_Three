using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.logger;

namespace Alpha_Three.src.commands.DriveCommands
{
    public class UpdateDriveCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        /// <summary>
        /// Runs update of the drive
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            DriveBLL bll = new DriveBLL();
            Train_driverBLL train_driverBLL = new Train_driverBLL();
            TrackBLL trackBLL = new TrackBLL();
            TrainBLL trainBLL = new TrainBLL();
            StringBuilder stringBuilder = new StringBuilder();
            List<Train_driver> train_drivers = new List<Train_driver>(train_driverBLL.GetAllList());
            List<Track> tracks = new List<Track>(trackBLL.GetAllList());
            List<Train> trains = new List<Train>(trainBLL.GetAllList());

            try
            {
                List<Drive> drives = new List<Drive>(bll.GetAllList());
                drives.ForEach(drive => stringBuilder.AppendLine(drive.ToString()));

                Application.Print_message_line("Drives: \n" + stringBuilder.ToString());

                Application.Print_message("Drive_ID: ");
                int id = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                train_drivers.ForEach(train_driver => stringBuilder.AppendLine(train_driver.ToString()));
                Application.Print_message_line("Train drivers available: \n" + stringBuilder.ToString());
                Application.Print_message("Train_driver_ID: ");
                int train_driver_ID = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                tracks.ForEach(track => stringBuilder.AppendLine(track.ToString()));
                Application.Print_message_line("Tracks available: \n" + stringBuilder.ToString());
                Application.Print_message("Track_ID: ");
                int track_ID = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                trains.ForEach(train => stringBuilder.AppendLine(train.ToString()));
                Application.Print_message_line("Trains available: \n" + stringBuilder.ToString());
                Application.Print_message("Train_ID: ");
                int train_ID = int.Parse(Console.ReadLine());

                Application.Print_message("Departure (YYYY-MM-DD HH:MM:SS): ");
                DateTime departure = DateTime.Parse(Console.ReadLine());

                Application.Print_message("Arrival (YYYY-MM-DD HH:MM:SS): ");
                DateTime arrival = DateTime.Parse(Console.ReadLine());

                // Create a new Drive object with the input data
                Drive drive = new Drive(id, train_driver_ID, track_ID, train_ID, departure, arrival);
                bll.Update(drive);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Drive updated successfully!";
        }
    }
}
