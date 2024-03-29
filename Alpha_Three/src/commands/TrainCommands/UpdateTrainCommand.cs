﻿using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.logger;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Alpha_Three.src.application;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.TrainCommands
{
    public class UpdateTrainCommand : ICommand
    {
        public string Execute()
        {
            return Run();
        }

        /// <summary>
        /// Runs upate of the train
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            StringBuilder stringBuilder = new StringBuilder();
            TrainBLL bll = new TrainBLL();

            try
            {
                List<Train> trains = new List<Train>(bll.GetAllList());
                trains.ForEach(train => stringBuilder.AppendLine(train.ToString()));

                Application.Print_message_line("Trains: \n" + stringBuilder.ToString());

                Application.Print_message("Train_ID: ");
                int id = int.Parse(Console.ReadLine());

                stringBuilder.Clear();

                Application.Print_message("Brand: ");
                string brand = Console.ReadLine();

                Application.Print_message("Model: ");
                string model = Console.ReadLine();
                ;
                Application.Print_message("Capacity: ");
                int capacity = Int32.Parse(Console.ReadLine());

                Train element = new Train(id, brand, model, capacity);

                bll.Update(element);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                return "Invalid input. Please try again.\n" +
                    $"Error: {ex.Message}";
            }

            return "Train updated successfully!";
        }
    }
}
