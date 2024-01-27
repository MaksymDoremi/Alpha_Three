using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Train : IBaseClass
    {

        private int _id;
        private string _brand;
        private string _model;
        private int _capacity;

        public Train(int id, string brand, string model, int capacity)
        {
            ID = id;
            Brand = brand;
            Model = model;
            Capacity = capacity;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Brand
        {
            get => _brand;
            set => _brand = value ?? throw new ArgumentNullException(nameof(value), "Brand cannot be null");
        }

        public string Model
        {
            get => _model;
            set => _model = value ?? throw new ArgumentNullException(nameof(value), "Model cannot be null");
        }

        public int Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
            }
        }

        public override string ToString()
        {
            return $"ID: {ID}, Brand: {Brand}, Model: {Model}, Capacity: {Capacity}";
        }
    }
}
