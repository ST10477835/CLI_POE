using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
