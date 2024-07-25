using System.ComponentModel.DataAnnotations;

namespace FlightAggregatorAPI.Models
{
    public class BookingRequest
    {
        [Key]
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
    }
}
