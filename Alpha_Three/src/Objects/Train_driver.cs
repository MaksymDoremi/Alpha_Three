using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Train_driver : IBaseClass
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _email;

        public Train_driver(int id, string name, string surname, string email)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public int ID { get => _id; set => _id = value; }

        public string Name { get => _name; set => _name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null"); }

        public string Surname { get => _surname; set => _surname = value ?? throw new ArgumentNullException(nameof(value), "Surname cannot be null"); }

        public string Email { get => _email; set => _email = value; }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Surname: {Surname}, Email: {Email}";
        }
    }
}

