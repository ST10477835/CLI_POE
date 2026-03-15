using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class VenueController : Controller
    {
        private readonly AppDbContext _context;
        public VenueController(AppDbContext context)
        {
            _context = context;
        }
    }
}
