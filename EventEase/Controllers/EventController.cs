using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Event> events = _context.Events.Include(e=>e.Venue).ToList();
            //uness explicitely stated to include venue, this will only load the events table
            return View(events);
        }

        public IActionResult Create()
        {
            ViewBag.Venue = _context.Venues.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event evt)
        {
            _context.Attach(evt.Venue);
            _context.Events.Add(evt);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            var evt = _context.Events.ToList().FirstOrDefault(e => e.Id == Id);
            if (evt == null) return NotFound();
            ViewBag.Venue = _context.Venues.ToList();
            return View(evt);
        }
        [HttpPost]
        public IActionResult Update(Event updatedEvent)
        {
            var evt = _context.Events.ToList().FirstOrDefault(e => e.Id == updatedEvent.Id);
            if (evt == null) return NotFound();
            evt.Name = updatedEvent.Name;
            evt.Venue = _context.Venues.ToList().FirstOrDefault(v=>v.Id==updatedEvent.Venue.Id);
            //was confusing array indices with Id's thus the "-1" 
            evt.StartDate = updatedEvent.StartDate;
            evt.EndDate = updatedEvent.EndDate;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var evt = _context.Events.ToList().FirstOrDefault(e => e.Id == Id);
            if (evt == null) return NotFound();
            _context.Events.Remove(evt);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
