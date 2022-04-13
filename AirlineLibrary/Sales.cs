using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class Sales {
        private Dictionary<Route, List<double>> _occupancyRatePerRoute = new Dictionary<Route, List<double>>();
        public void OnNewFlight(object source, FlightEventArgs args) {
            Console.WriteLine("Sales - OnNewFlight");
            AddNewOccupancyRate(args.latestNewFlight);
        }
        private void AddNewOccupancyRate(Flight flight) {
            if (_occupancyRatePerRoute.ContainsKey(flight.Route)) {
                _occupancyRatePerRoute[flight.Route].Add(CalculateOccupancyRate(flight));
            } else {
                _occupancyRatePerRoute.Add(flight.Route, new List<double>() { CalculateOccupancyRate(flight) });
            }
        }
        private double CalculateOccupancyRate(Flight flight) {
            return Convert.ToDouble(flight.SoldSeats) / flight.Airplane.Seats;
        }
        public void ShowAverageOccupancyRate() {
            foreach (Route r in _occupancyRatePerRoute.Keys) {
                Console.WriteLine($"Route: {_occupancyRatePerRoute[r].Count} flights from {r.DepartureAirport} to {r.ArrivalAirport} with an average occupancy rate of {CalculateAverageOccupancyRate(_occupancyRatePerRoute[r])}");
            }
        }

        private double CalculateAverageOccupancyRate(List<double> list) {
            double total = 0.0;
            foreach (double d in list) {
                total += d;
            }
            return total / list.Count;
        }
    }
}
