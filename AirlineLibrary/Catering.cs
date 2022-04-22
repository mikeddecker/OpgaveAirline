﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineLibrary {
    public class Catering {
        public Dictionary<string, List<CateringOrder>> _ordersPerAirport = new Dictionary<string, List<CateringOrder>>(); //airports with all it's ordered meals

        public void OnNewFlight(object source, FlightEventArgs args) { // this should react on the newlyRegisterd flight from Airline if we got the connection in Program.
            //airport already ordered something?
            Console.WriteLine("Catering - OnNewFlight");
            CateringOrder order = new CateringOrder(args.latestNewFlight);
            AddOrder(order); // Finance is notified in add order
            // _________ VERWITTIG FINANCE __________
            Console.WriteLine("-- NewCateringOrder - host event");
            NewCateringOrder(order);
        }

        // Event hosten:
        public event EventHandler<CateringEventArgs> CateringOrder;
        protected virtual void NewCateringOrder(CateringOrder order) {
            CateringOrder?.Invoke(this, new CateringEventArgs() { cateringOrder = order });
        }

        private void AddOrder(CateringOrder order) {
            if (!_ordersPerAirport.ContainsKey(order.Airport)) {
                _ordersPerAirport.Add(order.Airport, new List<CateringOrder> { order });
            } else {
                _ordersPerAirport[order.Airport].Add(order);
            }
        }
        public void ShowOrders() {
            Console.WriteLine("\n====ShowOrders====");
            foreach (string airport in _ordersPerAirport.Keys) {
                Console.WriteLine($"=== {airport} ===");
                foreach (CateringOrder order in _ordersPerAirport[airport]) {
                    Console.WriteLine($"{order.Date} - {order.Quantity} meals ordered");
                }
            }
        }
    }
}
