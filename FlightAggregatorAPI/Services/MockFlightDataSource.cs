using FlightAggregatorAPI.Models;

namespace FlightAggregatorAPI.Services
{
    public class MockFlightDataSource : IFlightDataSource
    {
        public Task<IEnumerable<FlightInfo>> GetFlightsAsync()
        {
            return Task.FromResult(new List<FlightInfo>
            {
                new FlightInfo { FlightNumber = "MF123", Airline = "MockAirline1", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(6), Price = 100, Stops = 0 },
                new FlightInfo { FlightNumber = "MF100", Airline = "AirBus", DepartureTime = DateTime.Now.AddHours(7), ArrivalTime = DateTime.Now.AddHours(12), Price = 300, Stops = 1 },
                new FlightInfo { FlightNumber = "FF100", Airline = "Boing777", DepartureTime = DateTime.Now.AddHours(1), ArrivalTime = DateTime.Now.AddHours(5), Price = 150, Stops = 0},
                new FlightInfo { FlightNumber = "MD101", Airline = "FlightPop", DepartureTime = DateTime.Now.AddHours(5), ArrivalTime = DateTime.Now.AddHours(17), Price = 500, Stops = 3 },
                new FlightInfo { FlightNumber = "MF123", Airline = "UzAirways", DepartureTime = DateTime.Now.AddHours(4), ArrivalTime = DateTime.Now.AddHours(4), Price = 200, Stops = 1 },
            }.AsEnumerable());
        }

        public Task<bool> BookFlightAsync(Booking request)
        {
            return Task.FromResult(true);
        }
    }
}
