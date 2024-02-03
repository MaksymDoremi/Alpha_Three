using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    internal class DriveView
    {
        // Private fields
        private string _trainDriverName;
        private string _trainDriverSurname;
        private string _trainDriverEmail;
        private string _from;
        private string _to;
        private string _trainBrand;
        private string _trainModel;
        private DateTime _departure;
        private DateTime _arrival;

        // Properties
        public string TrainDriverName
        {
            get => _trainDriverName;
            set => _trainDriverName = value;
        }

        public string TrainDriverSurname
        {
            get => _trainDriverSurname;
            set => _trainDriverSurname = value;
        }

        public string TrainDriverEmail
        {
            get => _trainDriverEmail;
            set => _trainDriverEmail = value;
        }

        public string From
        {
            get => _from;
            set => _from = value;
        }

        public string To
        {
            get => _to;
            set => _to = value;
        }

        public string TrainBrand
        {
            get => _trainBrand;
            set => _trainBrand = value;
        }

        public string TrainModel
        {
            get => _trainModel;
            set => _trainModel = value;
        }

        public DateTime Departure
        {
            get => _departure;
            set => _departure = value;
        }

        public DateTime Arrival
        {
            get => _arrival;
            set => _arrival = value;
        }

        // Constructor
        public DriveView(string trainDriverName, string trainDriverSurname, string trainDriverEmail, string from, string to, string trainBrand, string trainModel, DateTime departure, DateTime arrival)
        {
            TrainDriverName = trainDriverName;
            TrainDriverSurname = trainDriverSurname;
            TrainDriverEmail = trainDriverEmail;
            From = from;
            To = to;
            TrainBrand = trainBrand;
            TrainModel = trainModel;
            Departure = departure;
            Arrival = arrival;
        }

        // ToString method
        public override string ToString()
        {
            return $"Train Driver Name: {TrainDriverName}, Train Driver Surname: {TrainDriverSurname}, Train Driver Email: {TrainDriverEmail}, From: {From}, To: {To}, Train Brand: {TrainBrand}, Train Model: {TrainModel}, Departure: {Departure}, Arrival: {Arrival}";
        }
    }
}
