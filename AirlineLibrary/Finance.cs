using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class Finance {
        private Dictionary<int, double> _fuelCostEachYear = new Dictionary<int, double>();
        private SortedDictionary<int, SortedDictionary<int, SortedDictionary<string, double>>> cateringCostsOnYearMonthAirport = new SortedDictionary<int, SortedDictionary<int, SortedDictionary<string, double>>>();
        public void OnNewFlight(object source, FlightEventArgs args) {
            Console.WriteLine("Finance - OnNewFlight");
            double fuelPrice = CalculateFuelCost(args.latestNewFlight);
            AddFuelCosts(args.latestNewFlight.Date.Year, fuelPrice);
        }
        public void OnNewCateringOrder(object source, CateringEventArgs args) {
            Console.WriteLine("-- Finance - OnNewCateringOrder");
            double cateringCost = CalculateCateringCost(args.cateringOrder);
            AddCateringCost(cateringCost, args.cateringOrder.Date.Year, args.cateringOrder.Date.Month, args.cateringOrder.Airport);
        }
        public void ShowCateringRapport() {
            Console.WriteLine("\n====ShowCateringRapport====");
            foreach (int year in cateringCostsOnYearMonthAirport.Keys) {
                foreach (int month in cateringCostsOnYearMonthAirport[year].Keys) {
                    foreach (string airport in cateringCostsOnYearMonthAirport[year][month].Keys) {
                        Console.WriteLine($"Catering expenses from {year}/{month} at {airport} : {cateringCostsOnYearMonthAirport[year][month][airport]} euro");
                    }
                }
            }
        }
        public void ShowFuelCost(int year) {
            Console.WriteLine($"\n====ShowFuelCost in {year}====");
            Console.WriteLine($"Year {year} - fuelcost : {_fuelCostEachYear[year]} euro");
        }
        private void AddCateringCost(double cost, int year, int month, string airport) {
            if (cateringCostsOnYearMonthAirport.ContainsKey(year)) {
                if (cateringCostsOnYearMonthAirport[year].ContainsKey(month)) {
                    if (cateringCostsOnYearMonthAirport[year][month].ContainsKey(airport)) {
                        cateringCostsOnYearMonthAirport[year][month][airport] += cost;
                    } else {
                        cateringCostsOnYearMonthAirport[year][month].Add(airport, cost);
                    }
                } else {
                    cateringCostsOnYearMonthAirport[year].Add(month, new SortedDictionary<string, double>() { { airport, cost } });
                }
            } else {
                cateringCostsOnYearMonthAirport.Add(year, new SortedDictionary<int, SortedDictionary<string, double>>() { { month, new SortedDictionary<string, double>() { { airport, cost } } } });
            }
        }
        private double CalculateCateringCost(CateringOrder order) {
            double mealPrice = 3.5;
            return order.Quantity * mealPrice;
        }
        private double CalculateFuelCost(Flight flight) {
            return flight.Route.Distance / 100.0 * flight.SoldSeats * flight.Airplane.FuelCost;
        }
        private void AddFuelCosts(int year, double cost) {
            if (_fuelCostEachYear.ContainsKey(year)) {
                _fuelCostEachYear[year] += cost;
            } else { 
                _fuelCostEachYear.Add(year, cost); 
            }
        }
    }
}
