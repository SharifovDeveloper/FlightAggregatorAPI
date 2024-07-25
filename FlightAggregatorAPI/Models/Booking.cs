using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string FlightNumber { get; set; }

    [Required]
    public string PassengerName { get; set; }

    [Required]
    [EmailAddress]
    public string PassengerEmail { get; set; }
}
