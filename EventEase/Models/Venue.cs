using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public int Capacity { get; set; }
    }
}
