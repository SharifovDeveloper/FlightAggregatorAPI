using FlightAggregatorAPI.Data;
using FlightAggregatorAPI.Models;
using FlightAggregatorAPI.Services;
using Microsoft.EntityFrameworkCore;
using Stl.Fusion;

public class FlightAggregatorService : IFlightAggregatorService
{
    private readonly FlightContext _context;
    private readonly ILogger<FlightAggregatorService> _logger;

    public FlightAggregatorService(FlightContext context, ILogger<FlightAggregatorService> logger)
    {
        _context = context;
        _logger = logger;
    }

    [ComputeMethod]
    public async Task<IEnumerable<FlightInfo>> SearchFlightsAsync(
        DateTime? date = null,
        string airline = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        int? maxStops = null,
        string sortBy = null,
        bool descending = false,
        string searchString = null)
    {
        _logger.LogInformation("Executing SearchFlightsAsync with parameters: Date={Date}, Airline={Airline}, MinPrice={MinPrice}, MaxPrice={MaxPrice}, MaxStops={MaxStops}, SortBy={SortBy}, Descending={Descending}, SearchString={SearchString}",
            date, airline, minPrice, maxPrice, maxStops, sortBy, descending, searchString);

        IQueryable<FlightInfo> query = _context.Flights;

        if (date.HasValue)
        {
            query = query.Where(f => f.DepartureTime.Date == date.Value.Date);
        }

        if (!string.IsNullOrEmpty(airline))
        {
            query = query.Where(f => f.Airline == airline);
        }

        if (minPrice.HasValue)
        {
            query = query.Where(f => f.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(f => f.Price <= maxPrice.Value);
        }

        if (maxStops.HasValue)
        {
            query = query.Where(f => f.Stops <= maxStops.Value);
        }

        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(f => f.Airline.Contains(searchString) || f.FlightNumber.Contains(searchString));
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            query = sortBy.ToLower() switch
            {
                "price" => descending ? query.OrderByDescending(f => f.Price) : query.OrderBy(f => f.Price),
                "departuretime" => descending ? query.OrderByDescending(f => f.DepartureTime) : query.OrderBy(f => f.DepartureTime),
                _ => query
            };
        }

        var result = await query.ToListAsync();

        _logger.LogInformation($"Number of Flights Found: {result.Count}");

        return result;
    }

    [ComputeMethod]
    public async Task<bool> BookFlightAsync(Booking booking)
    {
        _logger.LogInformation("Executing BookFlightAsync for FlightNumber={FlightNumber}", booking.FlightNumber);

        var flight = await _context.Flights
            .Where(f => f.FlightNumber == booking.FlightNumber)
            .FirstOrDefaultAsync();

        if (flight == null || flight.TicketsAvailable <= 0)
        {
            _logger.LogWarning("Flight not available or no tickets left for FlightNumber={FlightNumber}", booking.FlightNumber);
            return false;
        }

        try
        {
            flight.TicketsAvailable -= 1;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Booking Flight for FlightNumber={FlightNumber}", booking.FlightNumber);
            return false;
        }
    }
}
