using EventEase.Models;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public Venue venue { get; set; }
        public Event evt { get; set; }
    }
}
