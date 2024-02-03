using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    internal class TicketView
    {
        // Private fields
        private string _passengerName;
        private string _passengerSurname;
        private string _passengerEmail;
        private string _travelClass;
        private int _ticketID;
        private string _from;
        private string _to;
        private DateTime _departure;
        private DateTime _arrival;
        private int _seatNumber;
        private DateTime _dateOfPurchase;
        private int _price;

        // Properties
        public string PassengerName
        {
            get => _passengerName;
            set => _passengerName = value;
        }

        public string PassengerSurname
        {
            get => _passengerSurname;
            set => _passengerSurname = value;
        }

        public string PassengerEmail
        {
            get => _passengerEmail;
            set => _passengerEmail = value;
        }

        public string TravelClass
        {
            get => _travelClass;
            set => _travelClass = value;
        }

        public int TicketID
        {
            get => _ticketID;
            set => _ticketID = value;
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

        public int SeatNumber
        {
            get => _seatNumber;
            set => _seatNumber = value;
        }

        public DateTime DateOfPurchase
        {
            get => _dateOfPurchase;
            set => _dateOfPurchase = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        // Constructor
        public TicketView(string passengerName, string passengerSurname, string passengerEmail, string travelClass, int ticketID, string from, string to, DateTime departure, DateTime arrival, int seatNumber, DateTime dateOfPurchase, int price)
        {
            PassengerName = passengerName;
            PassengerSurname = passengerSurname;
            PassengerEmail = passengerEmail;
            TravelClass = travelClass;
            TicketID = ticketID;
            From = from;
            To = to;
            Departure = departure;
            Arrival = arrival;
            SeatNumber = seatNumber;
            DateOfPurchase = dateOfPurchase;
            Price = price;
        }

        // ToString method
        public override string ToString()
        {
            return $"Passenger Name: {PassengerName}, Passenger Surname: {PassengerSurname}, Passenger Email: {PassengerEmail}, Travel Class: {TravelClass}, Ticket ID: {TicketID}, From: {From}, To: {To}, Departure: {Departure}, Arrival: {Arrival}, Seat Number: {SeatNumber}, Date of Purchase: {DateOfPurchase}, Price: {Price}";
        }
    }
}
