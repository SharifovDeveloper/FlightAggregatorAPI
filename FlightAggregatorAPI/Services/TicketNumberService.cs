namespace FlightAggregatorAPI.Services
{
    public interface ITicketNumberService
    {
        Task<string> GenerateTicketNumberAsync();
    }

    public class TicketNumberService : ITicketNumberService
    {
        public Task<string> GenerateTicketNumberAsync()
        {
            var ticketNumber = $"TICKET-{Guid.NewGuid()}";
            return Task.FromResult(ticketNumber);
        }
    }
}
