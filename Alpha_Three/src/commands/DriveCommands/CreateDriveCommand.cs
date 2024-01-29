using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;
using Alpha_Three.src.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.DriveCommands
{
    internal class CreateDriveCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        public string Run()
        {
            Train_driverBLL train_driverBLL = new Train_driverBLL();
            TrackBLL trackBLL = new TrackBLL();
            TrainBLL trainBLL = new TrainBLL();
            StringBuilder stringBuilder = new StringBuilder();
            List<Train_driver> train_drivers = new List<Train_driver>(train_driverBLL.GetAllList());
            List<Track> tracks = new List<Track>(trackBLL.GetAllList());
            List<Train> trains = new List<Train>(trainBLL.GetAllList());

            try
            {
                train_drivers.ForEach(train_driver => stringBuilder.AppendLine(train_driver.ToString()));
                Application.Print_message_line("Train drivers available: \n" + stringBuilder.ToString());
                Application.Print_message("Train_driver_ID: ");
                int train_driver_ID = Int32.Parse(Console.ReadLine());

                stringBuilder.Clear();
                tracks.ForEach(track => stringBuilder.AppendLine(track.ToString()));
                Application.Print_message_line("Tracks available: \n" + stringBuilder.ToString());
                Application.Print_message("Track_ID: ");
                int track_ID = Int32.Parse(Console.ReadLine());

                stringBuilder.Clear();
                trains.ForEach(train => stringBuilder.AppendLine(train.ToString()));
                Application.Print_message_line("Trains available: \n" + stringBuilder.ToString());
                Application.Print_message("Train_ID: ");
                int train_ID = Int32.Parse(Console.ReadLine());

                Application.Print_message("Departure YYYY-MM-DD HH:MI:SS: ");
                DateTime departure = DateTime.Parse(Console.ReadLine());

                Application.Print_message("Arrival YYYY-MM-DD HH:MI:SS: ");
                DateTime arrival = DateTime.Parse(Console.ReadLine());

                // Construct your Drive object and insert into the database
                Drive element = new Drive(0, train_driver_ID, track_ID, train_ID, departure, arrival);
                DriveBLL bll = new DriveBLL();


                if (bll.Insert(element))
                {
                    return "Drive inserted successfully!";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Couldn't insert drive";
        }

        public string View()
        {
            throw new NotImplementedException();
        }
    }
}
