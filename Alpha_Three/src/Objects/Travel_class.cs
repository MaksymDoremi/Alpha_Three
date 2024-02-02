using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Travel_class : IBaseClass
    {
        private int _id;
        private string _name;

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

        public Travel_class(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Travel_class ID: {ID}, Name: {Name}";
        }
    }
}
