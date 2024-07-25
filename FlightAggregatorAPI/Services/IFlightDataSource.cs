using FlightAggregatorAPI.Models;

namespace FlightAggregatorAPI.Services
{
    public interface IFlightDataSource
    {
        Task<IEnumerable<FlightInfo>> GetFlightsAsync();
        Task<bool> BookFlightAsync(Booking request);
    }
}
