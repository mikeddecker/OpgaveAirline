using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class Airline {
        public Airline(string name) {
            Name = name;
            Flights = new Dictionary<int, Flight>();
        }

        public string Name { get; private set; }
        private Dictionary<int, Flight> Flights { get; init; }

        public void AddNewFlight(Flight flight) {
            Console.WriteLine("Adding new flight");
            Flights.Add(flight.Number, flight);
            OnNewFlight(flight);
        }
        public event EventHandler<FlightEventArgs> NewlyRegisteredFlight;
        protected virtual void OnNewFlight(Flight flight) {
            NewlyRegisteredFlight?.Invoke(this, new FlightEventArgs() { latestNewFlight = flight });
        }
            
    }
}
