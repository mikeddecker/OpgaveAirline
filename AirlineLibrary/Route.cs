using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class Route {
        public Route(string departureAirport, string arrivalAirport, int distance) {
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            Distance = distance;
            Stopovers = new List<string>();
        }

        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public int Distance { get; set; } // in km's    
        public List<string> Stopovers { get; set; } // with no Stopovers in between the Departure airport and the Arrival airport, there would be no items in the list.
        public void AddStopover(string airport) {
            Stopovers.Add(airport);
        } // adds an airport as an in between route

        public override bool Equals(object obj) {
            Route r = (Route)obj;
            Console.WriteLine($"equals {CompareList(r.Stopovers, Stopovers)},{ EqualityComparer<List<string>>.Default.Equals(Stopovers, r.Stopovers)}");
            return obj is Route route &&
                   DepartureAirport == route.DepartureAirport &&
                   ArrivalAirport == route.ArrivalAirport &&
                   Distance == route.Distance &&
                   CompareList(r.Stopovers, Stopovers);
        }
        private static bool CompareList(List<string> l1, List<string> l2) {
            if (l1.Count != l2.Count) { return false; }
            for (int i = 0; i < l1.Count; i++ ){
                if (l1[i] != l2[i]) {
                    return false;
                }
            }
            return true;
            
        }

        public override int GetHashCode() {
            Console.WriteLine(HashCode.Combine(DepartureAirport, ArrivalAirport, Distance));
            return HashCode.Combine(DepartureAirport, ArrivalAirport, Distance);
        }  
    }
}
