namespace FlightAggregatorAPI.Models
{
    public class Ticket
    {
        public string TicketNumber { get; set; }
        public int BookingId { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
