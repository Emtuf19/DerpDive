using DeepDive.Data;
using DeepDive.Models;
using DeepDive.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public BookingController(IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager)
        {
            _bookingRepository = bookingRepository;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_bookingRepository.GetAll());
        }

        public IActionResult BookingByUser()
         {
            var userId = _userManager.GetUserId(User);
            var bookings = _bookingRepository.GetByUser(userId);
            return View(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            _bookingRepository.Update(booking);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bookingRepository.Delete(id);
            return RedirectToAction("Index");
        }


    }
    
}
