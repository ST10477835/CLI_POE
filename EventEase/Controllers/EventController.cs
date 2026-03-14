using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class EventController : Controller
    {
        public static List<Event> events = new List<Event>
        {
            new Event { Id = 1, Name = "Startup Networking Night", StartDate = new DateTime(2026, 4, 5), EndDate = new DateTime(2026, 4, 5), Venue = VenueController.venues.First(v => v.Id == 8) },
            new Event { Id = 2, Name = "Tech Innovators Conference", StartDate = new DateTime(2026, 4, 12), EndDate = new DateTime(2026, 4, 14), Venue = VenueController.venues.First(v => v.Id == 4) },
            new Event { Id = 3, Name = "Local Music Festival", StartDate = new DateTime(2026, 5, 2), EndDate = new DateTime(2026, 5, 2), Venue = VenueController.venues.First(v => v.Id == 9) },
            new Event { Id = 4, Name = "Community Charity Dinner", StartDate = new DateTime(2026, 5, 10), EndDate = new DateTime(2026, 5, 10), Venue = VenueController.venues.First(v => v.Id == 6) },
            new Event { Id = 5, Name = "University Research Symposium", StartDate = new DateTime(2026, 5, 18), EndDate = new DateTime(2026, 5, 19), Venue = VenueController.venues.First(v => v.Id == 10) },
            new Event { Id = 6, Name = "Gaming Expo Cape Town", StartDate = new DateTime(2026, 6, 6), EndDate = new DateTime(2026, 6, 7), Venue = VenueController.venues.First(v => v.Id == 3) },
            new Event { Id = 7, Name = "Entrepreneur Workshop", StartDate = new DateTime(2026, 6, 15), EndDate = new DateTime(2026, 6, 15), Venue = VenueController.venues.First(v => v.Id == 2) },
            new Event { Id = 8, Name = "Art & Design Showcase", StartDate = new DateTime(2026, 7, 1), EndDate = new DateTime(2026, 7, 3), Venue = VenueController.venues.First(v => v.Id == 7) },
            new Event { Id = 9, Name = "Community Coding Bootcamp", StartDate = new DateTime(2026, 7, 10), EndDate = new DateTime(2026, 7, 12), Venue = VenueController.venues.First(v => v.Id == 5) },
            new Event { Id = 10, Name = "Indie Game Jam Meetup", StartDate = new DateTime(2026, 7, 20), EndDate = new DateTime(2026, 7, 20), Venue = VenueController.venues.First(v => v.Id == 1) }
        };
        static int nextId = 1;

        public IActionResult Index()
        {
            return View(events);
        }

        public IActionResult Create()
        {
            ViewBag.Venue = VenueController.venues;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event evt)
        {
            evt.Id = nextId++;
            evt.Venue = VenueController.venues[evt.Venue.Id];
            events.Add(evt);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Event updatedEvent)
        {
            var evt = events.FirstOrDefault(e => e.Id == updatedEvent.Id);
            if (evt == null) return NotFound();
            evt.Name = updatedEvent.Name;
            evt.Venue = VenueController.venues[updatedEvent.Venue.Id];
            evt.StartDate = updatedEvent.StartDate;
            evt.EndDate = updatedEvent.EndDate;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var evt = events.FirstOrDefault(e => e.Id == Id);
            if (evt == null) return NotFound();
            events.Remove(evt);
            return RedirectToAction("Index");
        }
    }
}
