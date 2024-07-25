using FlightAggregatorAPI.Models;
using FlightAggregatorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FlightAggregatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly FlightAggregatorService _flightAggregatorService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(FlightAggregatorService flightAggregatorService, IMemoryCache cache, ILogger<FlightsController> logger)
        {
            _flightAggregatorService = flightAggregatorService;
            _cache = cache;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> SearchFlights()
        {
            const string cacheKey = "flights";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<FlightInfo> flights))
            {
                flights = await _flightAggregatorService.SearchFlightsAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                _cache.Set(cacheKey, flights, cacheEntryOptions);
            }

            return Ok(flights);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookFlight([FromBody] BookingRequest request)
        {
            _logger.LogInformation("Booking flight for {PassengerName}", request.PassengerName);
            var success = await _flightAggregatorService.BookFlightAsync(request);
            return success ? Ok() : StatusCode(500, "Booking failed");
        }
    }
}
