using DeepDive.Data;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class BookingRepository : IBookingRepository
    {
        private readonly EquipmentContext _context;
        public BookingRepository(EquipmentContext context)
        {
            _context = context;
        }
        public async Task<List<Booking>> GetAll()
        {
            return await _context.Bookings
                .Include(b => b.BookingItems)
                .Include(b => b.ApplicationUser)   // så admin kan se email
                .ToListAsync();
        }

        public async Task<List<Booking>> GetByUser(string userId)
        {
            return await _context.Bookings
                .Include(b => b.BookingItems)
                .Where(b => b.ApplicationUserId == userId)   // kun egne
                .ToListAsync();
        }

        public async Task<Booking?> GetById(int id)
        {
            return await _context.Bookings
               .Include(b => b.BookingItems)
               .Include(b => b.ApplicationUser)
               .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<BookingItem?> GetItemById(int id)
        {
            return await _context.BookingItems.FindAsync(id);
        }

        public async Task UpdateItem(BookingItem item)
        {
            _context.BookingItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.BookingItems.FindAsync(id);
            if (item != null)
            {
                _context.BookingItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }


    }
}
