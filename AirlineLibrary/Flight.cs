using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class Flight {
        public Flight(int number, DateTime date, Route route, int soldSeats, Airplane plane) {
            Number = number;
            Date = date;
            Route = route;
            SoldSeats = soldSeats;
            Airplane = plane;
        }

        public int Number { get; init; }
        public DateTime Date {get; init;}
        public Route Route { get; init; }
        public int SoldSeats { get; init; }
        public Airplane Airplane { get; init; }
    }
}
