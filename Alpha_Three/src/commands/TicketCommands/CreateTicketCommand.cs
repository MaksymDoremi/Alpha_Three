﻿using Alpha_Three.src.BLL;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using Alpha_Three.src.application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha_Three.src.interfaces;

namespace Alpha_Three.src.commands.TicketCommands
{
    internal class CreateTicketCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }
        public string Run()
        {
            PassengerBLL passengerBLL = new PassengerBLL();
            DriveBLL driveBLL = new DriveBLL();
            Travel_classBLL travel_ClassBLL = new Travel_classBLL();
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                List<Passenger> passengers = new List<Passenger>(passengerBLL.GetAllList());
                List<Drive> drives = new List<Drive>(driveBLL.GetAllList());
                List<Travel_class> travel_classes = new List<Travel_class>(travel_ClassBLL.GetAllList());

                if (passengers is not null)
                {
                    passengers.ForEach(passenger => stringBuilder.AppendLine(passenger.ToString()));
                }
                else
                {
                    stringBuilder.AppendLine("EMPTY");
                }
                Application.Print_message_line("Passengers available: \n" + stringBuilder.ToString());
                Application.Print_message("Passenger_ID: ");
                int passengerId = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                if (drives is not null)
                {
                    drives.ForEach(drive => stringBuilder.AppendLine(drive.ToString()));
                }
                else
                {
                    stringBuilder.AppendLine("EMPTY");
                }
                Application.Print_message_line("Drives available: \n" + stringBuilder.ToString());
                Application.Print_message("Drive_ID: ");
                int driveId = int.Parse(Console.ReadLine());

                stringBuilder.Clear();
                if (travel_classes is not null)
                {
                    travel_classes.ForEach(travel_class => stringBuilder.AppendLine(travel_class.ToString()));
                }
                else
                {
                    stringBuilder.AppendLine("EMPTY");
                }
                Application.Print_message_line("Travel classes available: \n" + stringBuilder.ToString());
                Application.Print_message("Travel_class_ID: ");
                int travelClassId = int.Parse(Console.ReadLine());

                Application.Print_message("Seat Number: ");
                int seatNumber = int.Parse(Console.ReadLine());

                Application.Print_message("Date of Purchase (YYYY-MM-DD): ");
                DateTime dateOfPurchase = DateTime.Parse(Console.ReadLine());

                Application.Print_message("Price: ");
                int price = int.Parse(Console.ReadLine());

                Ticket element = new Ticket(0, passengerId, driveId, travelClassId, seatNumber, dateOfPurchase, price);
                TicketBLL bll = new TicketBLL();

                bll.Insert(element);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Ticket inserted successfully!";
        }
        
    }
}
