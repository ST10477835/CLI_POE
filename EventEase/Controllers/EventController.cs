using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class EventController : Controller
    {
        static List<Event> events = new List<Event>();
        static int nextId = 1;
        public IActionResult Index()
        {
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event evt)
        {
            evt.Id = nextId++;
            events.Add(evt);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            var evt = events.FirstOrDefault(e => e.Id == Id);
            if(evt==null) return NotFound();
            return View(evt);
        }
        [HttpPost]
        public IActionResult Update(Event updatedEvent)
        {
            var evt = events.FirstOrDefault(e => e.Id == updatedEvent.Id);
            if (evt == null) return NotFound();

            evt.Name = updatedEvent.Name;
            evt.Capacity = updatedEvent.Capacity;
            evt.StartDate = updatedEvent.StartDate;
            evt.EndDate = updatedEvent.EndDate;

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var evt = events.FirstOrDefault(e => e.Id == Id);
            if (evt == null) return NotFound();

            events.Remove(evt);
            return RedirectToAction("Index");
        }
    }
}
