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

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application")]
        public async Task<IActionResult> Index()
        {
            return View(await _bookingRepository.GetAll());
        }

        public async Task<IActionResult> BookingByUser(bool showPast = false)
         {
            var userId = _userManager.GetUserId(User);
            var bookings = await _bookingRepository.GetByUser(userId);

            if (!showPast)
            {
                bookings = bookings 
                .Where(b => b.BookingItems.Any(i => i.DateTo >= DateTime.Today))
                       .ToList();
            }
            ViewBag.ShowPast = showPast;
            return View(bookings);
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application")]
        [HttpPost]
        public async Task<IActionResult> Edit(Booking booking)
        {
            await _bookingRepository.Update(booking);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingRepository.Delete(id);
            return RedirectToAction("Index");
        }


    }
    
}
