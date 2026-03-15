using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Booking> bookings = _context.Bookings.Include(b => b.Event).ToList();
            return View(bookings);
        }

        public IActionResult Create()
        {
            ViewBag.Event = _context.Events.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            _context.Attach(booking.Event);
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var booking = _context.Bookings.ToList().FirstOrDefault(b => b.Id == Id);
            if (booking == null) return NotFound();
            ViewBag.Event = _context.Events.ToList();
            return View(booking);
        }

        [HttpPost]
        public IActionResult Update(Booking updatedBooking)
        {
            Console.WriteLine(updatedBooking.Event.Id);
            var booking = _context.Bookings.ToList().FirstOrDefault(b => b.Id == updatedBooking.Id);
            if (booking == null) return NotFound();
            booking.UserName = updatedBooking.UserName;
            booking.Event = _context.Events.ToList().FirstOrDefault(e => e.Id == updatedBooking.Event.Id);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var booking = _context.Bookings.ToList().FirstOrDefault(b => b.Id == Id);
            if (booking == null) return NotFound();
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
