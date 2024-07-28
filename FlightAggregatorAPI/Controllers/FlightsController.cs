using FlightAggregatorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Stl.Fusion;
using ZiggyCreatures.Caching.Fusion;

namespace FlightAggregatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightAggregatorService _flightAggregatorService;
        private readonly ITicketService _ticketService;
        private readonly IFusionCache _cache;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(IFlightAggregatorService flightAggregatorService, ITicketService ticketService, IFusionCache cache, ILogger<FlightsController> logger)
        {
            _flightAggregatorService = flightAggregatorService;
            _ticketService = ticketService;
            _cache = cache;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> SearchFlights(
            [FromQuery] DateTime? date = null,
            [FromQuery] string airline = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] int? maxStops = null,
            [FromQuery] string sortBy = null,
            [FromQuery] bool descending = false,
            [FromQuery] string searchString = null
        )
        {
            try
            {
                var cacheKey = $"Flights_Search_{date}_{airline}_{minPrice}_{maxPrice}_{maxStops}_{sortBy}_{descending}_{searchString}";

                var flights = await _cache.GetOrSetAsync(cacheKey, async cacheEntry =>
                {

                    return await _flightAggregatorService.SearchFlightsAsync(date, airline, minPrice, maxPrice, maxStops, sortBy, descending, searchString);
                });

                return Ok(flights);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching for flights.");
                return StatusCode(500, "Internal server error");
            }
        }

        [ComputeMethod]
        [HttpPost]
        public async Task<IActionResult> BookFlight([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking cannot be null.");
            }

            try
            {
                _logger.LogInformation("Booking flight for {PassengerName}", booking.PassengerName);
                var success = await _flightAggregatorService.BookFlightAsync(booking);

                if (!success)
                {
                    return StatusCode(500, "Booking failed");
                }

                var ticket = await _ticketService.IssueTicketAsync(booking);

                if (ticket == null)
                {
                    return StatusCode(500, "Ticket issuance failed");
                }

                return Ok(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while booking flight for {PassengerName}", booking.PassengerName);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
