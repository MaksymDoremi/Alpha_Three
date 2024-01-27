using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.DriveCommands
{
    internal class UpdateDriveCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }
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

                Console.WriteLine("Drives: \n" + stringBuilder.ToString());

                Console.Write("Drive_ID: ");
                int id = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                train_drivers.ForEach(train_driver => stringBuilder.AppendLine(train_driver.ToString()));
                Console.WriteLine("Train drivers available: \n" + stringBuilder.ToString());
                Console.Write("Train_driver_ID: ");
                int train_driver_ID = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                tracks.ForEach(track => stringBuilder.AppendLine(track.ToString()));
                Console.WriteLine("Tracks available: \n" + stringBuilder.ToString());
                Console.Write("Track_ID: ");
                int track_ID = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                trains.ForEach(train => stringBuilder.AppendLine(train.ToString()));
                Console.WriteLine("Trains available: \n" + stringBuilder.ToString());
                Console.Write("Train_ID: ");
                int train_ID = int.Parse(Console.ReadLine());

                Console.Write("Departure (YYYY-MM-DD HH:MM:SS): ");
                DateTime departure = DateTime.Parse(Console.ReadLine());

                Console.Write("Arrival (YYYY-MM-DD HH:MM:SS): ");
                DateTime arrival = DateTime.Parse(Console.ReadLine());

                // Create a new Drive object with the input data
                Drive drive = new Drive(id, train_driver_ID, track_ID, train_ID, departure, arrival);
                if (bll.Update(drive))
                {
                    return "Drive updated successfully!";
                }
                else
                {
                    return "Error updating drive. Please try again.";
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
