using FlightAggregatorAPI.Models;

namespace FlightAggregatorAPI.Services
{
    public interface IFlightAggregatorService
    {
        Task<IEnumerable<FlightInfo>> SearchFlightsAsync(DateTime? date, string airline, decimal? minPrice, decimal? maxPrice, int? maxStops, string sortBy, bool descending, string searchString);
        Task<bool> BookFlightAsync(Booking booking);
    }
}
