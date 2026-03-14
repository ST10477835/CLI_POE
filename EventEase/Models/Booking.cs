using EventEase.Models;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public String UserName { get; set; } 
        public Event Event { get; set; }
    }
}
