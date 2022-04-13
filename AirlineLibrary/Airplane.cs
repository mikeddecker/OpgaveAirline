using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class Airplane {
        public Airplane(string name, int seats, int speed, double fuelCost) {
            Name = name;
            Seats = seats;
            Speed = speed;
            FuelCost = fuelCost;
        }

        public string Name { get; init; }
        public int Seats { get; init; }
        public int Speed { get; init; }
        public double FuelCost { get; init; }

    }
}
