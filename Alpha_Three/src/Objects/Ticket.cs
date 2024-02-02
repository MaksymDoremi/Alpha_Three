using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Ticket : IBaseClass
    {
        private int _id;
        private int _passengerId;
        private int _driveId;
        private int _travelClassId;
        private int _seatNumber;
        private DateTime _dateOfPurchase;
        private int _price;

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public int Passenger_ID
        {
            get => _passengerId;
            set => _passengerId = value;
        }

        public int Drive_ID
        {
            get => _driveId;
            set => _driveId = value;
        }

        public int Travel_class_ID
        {
            get => _travelClassId;
            set => _travelClassId = value;
        }

        public int Seat_number
        {
            get => _seatNumber;
            set => _seatNumber = value;
        }

        public DateTime Date_of_purchase
        {
            get => _dateOfPurchase;
            set => _dateOfPurchase = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public Ticket(int id, int passengerId, int driveId, int travelClassId, int seatNumber, DateTime dateOfPurchase, int price)
        {
            ID = id;
            Passenger_ID = passengerId;
            Drive_ID = driveId;
            Travel_class_ID = travelClassId;
            Seat_number = seatNumber;
            Date_of_purchase = dateOfPurchase;
            Price = price;
        }

        public override string ToString()
        {
            return $"Ticket ID: {ID}, Passenger ID: {Passenger_ID}, Drive ID: {Drive_ID}, Travel Class ID: {Travel_class_ID}, Seat Number: {Seat_number}, Date of Purchase: {Date_of_purchase}, Price: {Price}";
        }
    }
}
