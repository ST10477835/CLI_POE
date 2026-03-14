using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class VenueController : Controller
    {
        public static List<Venue> venues = new List<Venue>
        {
            new Venue { Id = 1, Capacity = 10, Location = "10 Pritchet Street, Cape Town", Name = "BunkHouse Venue" },
            new Venue { Id = 2, Capacity = 120, Location = "45 River Road, Stellenbosch", Name = "Riverside Conference Room" },
            new Venue { Id = 3, Capacity = 350, Location = "22 Ocean Drive, Camps Bay", Name = "Ocean View Auditorium" },
            new Venue { Id = 4, Capacity = 200, Location = "88 Albert Road, Woodstock", Name = "Tech Innovation Hub" },
            new Venue { Id = 5, Capacity = 150, Location = "14 Greenfields Ave, Bellville", Name = "Greenfields Community Hall" },
            new Venue { Id = 6, Capacity = 300, Location = "67 Beach Road, Sea Point", Name = "Sunset Banquet Hall" },
            new Venue { Id = 7, Capacity = 250, Location = "102 Vineyard Lane, Constantia", Name = "Mountain View Pavilion" },
            new Venue { Id = 8, Capacity = 60, Location = "5 Loop Street, Cape Town CBD", Name = "Downtown Meeting Room" },
            new Venue { Id = 9, Capacity = 400, Location = "1 Dock Road, V&A Waterfront", Name = "Waterfront Event Space" },
            new Venue { Id = 10, Capacity = 180, Location = "12 University Ave, Rondebosch", Name = "University Lecture Theatre" }
        };
    }
}
