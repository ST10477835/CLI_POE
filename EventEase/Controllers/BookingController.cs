using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class BookingController : Controller
    {

        static List<Booking> bookings = new List<Booking>();
         static int nextId = 1;
        public IActionResult Index()
        {
            return View(bookings);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            booking.Id = nextId++;
            bookings.Add(booking);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == Id);
            if (booking == null) return NotFound();

            return View(booking);
        }

        [HttpPost]
        public IActionResult Update(Booking updatedBooking)
        {
            var booking = bookings.FirstOrDefault(b=>b.Id == updatedBooking.Id);
            if (booking == null) return NotFound();

            booking.venue = updatedBooking.venue;
            booking.evt = updatedBooking.evt;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == Id);
            if (booking == null) return NotFound();

            bookings.Remove(booking);
            return RedirectToAction("Index");
        }
    }

}
