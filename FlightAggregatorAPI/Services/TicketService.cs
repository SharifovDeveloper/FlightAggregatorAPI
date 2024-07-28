using FlightAggregatorAPI.Data;
using FlightAggregatorAPI.Models;
using Stl.Fusion;

namespace FlightAggregatorAPI.Services
{
    public interface ITicketService
    {
        Task<Ticket> IssueTicketAsync(Booking booking);
    }

    public class TicketService : ITicketService
    {
        private readonly FlightContext _context;
        private readonly ITicketNumberService _ticketNumberService;
        private readonly ILogger<TicketService> _logger;

        public TicketService(FlightContext context, ITicketNumberService ticketNumberService, ILogger<TicketService> logger)
        {
            _context = context;
            _ticketNumberService = ticketNumberService;
            _logger = logger;
        }

        [ComputeMethod]
        public async Task<Ticket> IssueTicketAsync(Booking booking)
        {
            var ticketNumber = await _ticketNumberService.GenerateTicketNumberAsync();
            var ticket = new Ticket
            {
                TicketNumber = ticketNumber,
                BookingId = booking.Id,
                IssueDate = DateTime.UtcNow
            };

            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Issued ticket {TicketNumber} for booking {BookingId}", ticketNumber, booking.Id);
                return ticket;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while issuing ticket for booking {BookingId}", booking.Id);
                return null;
            }
        }
    }
}
