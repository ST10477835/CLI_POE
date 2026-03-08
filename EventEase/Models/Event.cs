using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
