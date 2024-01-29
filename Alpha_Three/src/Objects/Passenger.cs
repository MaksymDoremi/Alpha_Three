using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Passenger : IBaseClass
    {

        // Private fields corresponding to the properties
        private int _id;
        private string _name;
        private string _surname;
        private string _email;

        // Properties corresponding to the table columns
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }


        public Passenger(int id, string name, string surname, string email)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public override string ToString()
        {
            return $"Passenger ID: {ID}, Name: {Name}, Surname: {Surname}, Email: {Email}";
        }

    }
}
