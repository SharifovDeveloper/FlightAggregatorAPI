using FlightAggregatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightAggregatorAPI.Data
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options) { }

        public DbSet<FlightInfo> Flights { get; set; }
        public DbSet<BookingRequest> Bookings { get; set; }
    }
}
