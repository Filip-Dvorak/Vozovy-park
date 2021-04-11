using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozový_park
{
    class Car
    {
        public int id;
        public string znacka;
        public string model;
        public string typ;
        public double spotreba;
        public bool isActive;
        public static Dictionary<int, Car> _cars = new Dictionary<int, Car>();
        public static Dictionary<int, Car> cars
        {
            get { return _cars; }
            set { _cars = value; }
        }
    }
}
