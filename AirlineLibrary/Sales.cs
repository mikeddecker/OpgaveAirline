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

        private double CalculateAverageOccupancyRate(List<double> list) {
            double total = 0.0;
            foreach (double d in list) {
                total += d;
            }
            return total / list.Count;
        } // calculate the average occupancy rate for each flight
        private double CalculateOccupancyRate(Flight flight) {
            return Convert.ToDouble(flight.SoldSeats) / flight.Airplane.Seats;
        } // used by AddNewOccupancyRate => to calculate the occupancy rate of a new flight
        public void ShowAverageOccupancyRate() {
            ShowAverageOccupancyRate(1); // 1 is the maximum and the standard value
        }
        public void ShowAverageOccupancyRate(double maxValue) {
            Console.WriteLine($"\n====ShowAverageOccupancyRate kleiner dan {maxValue}====");

            if (maxValue > 1 || maxValue <= 0) {
                Console.WriteLine("maximum value must be smaller than 1 and bigger than 0");
            } else {
                foreach (Route r in _occupancyRatePerRoute.Keys) {
                    double average = CalculateAverageOccupancyRate(_occupancyRatePerRoute[r]);
                    if (average <= maxValue) { Console.WriteLine($"{_occupancyRatePerRoute[r].Count} flights from {r.DepartureAirport} to {r.ArrivalAirport} with an average occupancy rate of {average}"); }
                }
            }
        }
    }
}
