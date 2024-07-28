using FlightAggregatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightAggregatorAPI.Data
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options) { }

        public DbSet<FlightInfo> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FlightInfo>().HasData(
                new FlightInfo { FlightNumber = "MF123", Airline = "MockAirline1", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(6), Price = 100, Stops = 0, TicketsAvailable = 30 },
                new FlightInfo { FlightNumber = "MF100", Airline = "AirBus", DepartureTime = DateTime.Now.AddHours(7), ArrivalTime = DateTime.Now.AddHours(12), Price = 300, Stops = 1, TicketsAvailable = 50 },
                new FlightInfo { FlightNumber = "FF100", Airline = "Boing777", DepartureTime = DateTime.Now.AddHours(1), ArrivalTime = DateTime.Now.AddHours(5), Price = 150, Stops = 0, TicketsAvailable = 70 },
                new FlightInfo { FlightNumber = "MD101", Airline = "FlightPop", DepartureTime = DateTime.Now.AddHours(5), ArrivalTime = DateTime.Now.AddHours(17), Price = 500, Stops = 3, TicketsAvailable = 90 }
            );

            modelBuilder.Entity<Ticket>().HasKey(t => t.TicketNumber);
        }
    }
}
