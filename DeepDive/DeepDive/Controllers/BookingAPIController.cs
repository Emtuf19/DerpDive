using DeepDive.Data;
using DeepDive.Models;
using DeepDive.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookingAPIController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingAPIController(IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager)
        {
            _bookingRepository = bookingRepository;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("admin")]
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingRepository.GetAll();
            return Ok(bookings);
        }

        [HttpGet]
        public async Task<IActionResult> BookingByUser()
        {
            var userId = _userManager.GetUserId(User);
            var bookings = await _bookingRepository.GetByUser(userId);
            return Ok(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [Route("admin")]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            if (id <= 0)
                return BadRequest();

            var existingBooking = await _bookingRepository.GetById(id);

            if (existingBooking == null)
                return NotFound();

            await _bookingRepository.Update(booking);
            return Ok(booking);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [Route("admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();
            
            var booking = await _bookingRepository.GetById(id);

            if (booking == null)
                return NotFound();
            
            await _bookingRepository.Delete(id);

            return Ok();
        }


    }
}
