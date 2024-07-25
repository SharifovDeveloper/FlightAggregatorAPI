using System.ComponentModel.DataAnnotations;

namespace FlightAggregatorAPI.Models
{
    public class FlightInfo
    {
        [Key]
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int Stops { get; set; }
    }
}
