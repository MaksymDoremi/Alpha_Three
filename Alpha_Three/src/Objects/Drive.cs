using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Drive : IBaseClass
    {
        private int id;
        private int train_driver_ID;
        private int track_ID;
        private int train_ID;
        private DateTime departure;
        private DateTime arrival;

        public Drive(int id, int train_driver_ID, int track_id, int train_id, DateTime departure, DateTime arrival)
        {
            ID = id;
            Train_driver_ID = train_driver_ID;
            Track_ID = track_id;
            Train_ID = train_id;
            Departure = departure;
            Arrival = arrival;
        }

        public int ID { get => id; set => id = value >= 0 ? value : 0; }
        public int Train_driver_ID { get => train_driver_ID; set => train_driver_ID = value >= 0 ? value : 0; }
        public int Track_ID { get => track_ID; set => track_ID = value >= 0 ? value : 0; }
        public int Train_ID { get => train_ID; set => train_ID = value >= 0 ? value : 0; }
        public DateTime Departure { get => departure; set => departure = value; }
        public DateTime Arrival { get => arrival; set => arrival = value; }

        public override string ToString()
        {
            return $"Drive ID: {ID}, Train_driver_ID: {Train_driver_ID}, Track_ID: {Track_ID}, Train_ID: {Train_ID}, Departure: {Departure}, Arrival: {Arrival}";
        }
    }
}
