using System;
using AirlineLibrary;

namespace AirlineConsoleApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            Airline a = new Airline("Air Miles");
            Catering c = new Catering();
            Finance f = new Finance();
            Sales s = new Sales();

            a.NewlyRegisteredFlight += c.OnNewFlight;
            a.NewlyRegisteredFlight += f.OnNewFlight;
            a.NewlyRegisteredFlight += s.OnNewFlight;
            c.CateringOrder += f.OnNewCateringOrder;

            Airplane a1 = new Airplane("BA501", 112, 850, 60);
            Airplane a2 = new Airplane("BA502", 112, 850, 60);
            Flight f1 = new Flight(1001, new DateTime(2021, 03, 05), new Route("BRU", "TXL", 635), 84, a1 );
            a.AddNewFlight(f1);
            Flight f2 = new Flight(1002, new DateTime(2021, 03, 05), new Route("BRU", "ARN", 1290), 108, a2);
            a.AddNewFlight(f2);
            Flight f3 = new Flight(2222, new DateTime(2021, 04, 05), new Route("BRU", "TXL", 635), 84, a1 );
            a.AddNewFlight(f3);
            Flight f4 = new Flight(2223, new DateTime(2021, 03, 05), new Route("ARN", "TXL", 635), 84, a1 );
            a.AddNewFlight(f4);

            f.ShowCateringRapport();
            f.ShowFuelCost(2021);
            c.ShowOrders();
            s.ShowAverageOccupancyRate();


        }
    }
}
