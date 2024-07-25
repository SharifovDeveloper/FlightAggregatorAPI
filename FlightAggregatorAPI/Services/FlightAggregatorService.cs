using FlightAggregatorAPI.Data;
using FlightAggregatorAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FlightAggregatorAPI.Services
{
    public class FlightAggregatorService
    {
        private readonly IEnumerable<IFlightDataSource> _dataSources;
        private readonly FlightContext _context;
        private readonly IMemoryCache _cache;

        public FlightAggregatorService(IEnumerable<IFlightDataSource> dataSources, FlightContext context, IMemoryCache cache)
        {
            _dataSources = dataSources;
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<FlightInfo>> SearchFlightsAsync()
        {
            const string cacheKey = "flights";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<FlightInfo> flights))
            {
                var tasks = _dataSources.Select(ds => ds.GetFlightsAsync());
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(10));

                var completedTask = await Task.WhenAny(Task.WhenAll(tasks), timeoutTask);

                if (completedTask == timeoutTask)
                {
                    throw new TimeoutException("Data sources took too long to respond.");
                }

                flights = tasks.Where(t => t.Status == TaskStatus.RanToCompletion)
                               .SelectMany(t => t.Result);

                foreach (var flight in flights)
                {
                    if (!_context.Flights.Any(f => f.FlightNumber == flight.FlightNumber))
                    {
                        _context.Flights.Add(flight);
                    }
                }

                await _context.SaveChangesAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                _cache.Set(cacheKey, flights, cacheEntryOptions);
            }

            return flights;
        }

        public async Task<bool> BookFlightAsync(BookingRequest request)
        {
            _context.Bookings.Add(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
