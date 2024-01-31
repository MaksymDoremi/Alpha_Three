using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Station : IBaseClass
    {
        private int _id;
        private string _name;
        private string _address;

        // Constructor
        public Station(int id, string name, string address)
        {
            ID = id;
            Name = name;
            Address = address;
        }

        // Properties
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

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public override string ToString()
        {
            return $"Station ID: {ID}, Name: {Name}, Address: {Address}";
        }
    }
}
