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
        public async Task<IActionResult> Index()
        {
            return View(await _bookingRepository.GetAll());
        }

        public async Task<IActionResult> BookingByUser()
         {
            var userId = _userManager.GetUserId(User);
            var bookings = await _bookingRepository.GetByUser(userId);
            return View(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Booking booking)
        {
            await _bookingRepository.Update(booking);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingRepository.Delete(id);
            return RedirectToAction("Index");
        }


    }
    
}
