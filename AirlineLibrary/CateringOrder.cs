using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class CateringOrder {
        public CateringOrder(Flight flight) {
            Quantity = flight.SoldSeats;
            Airport = flight.Route.DepartureAirport;
            Date = flight.Date;
        }

        public int Quantity { get; init; }
        public string Airport { get; init; }
        public DateTime Date { get; init; }

    }
}
