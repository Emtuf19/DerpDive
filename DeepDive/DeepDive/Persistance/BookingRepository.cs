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
        public List<Booking> GetAll()
        {
            return _context.Bookings
                .Include(b => b.BookingItems)
                .Include(b => b.ApplicationUser)   // så admin kan se email
                .ToList();
        }

        public List<Booking> GetByUser(string userId)
        {
            return _context.Bookings
                .Include(b => b.BookingItems)
                .Where(b => b.ApplicationUserId == userId)   // kun egne
                .ToList();
        }

        public Booking? GetById(int id)
        {
            return _context.Bookings
               .Include(b => b.BookingItems)
               .Include(b => b.ApplicationUser)
               .FirstOrDefault(b => b.BookingId == id);
        }

        public void Update(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
        public BookingItem? GetItemById(int id)
        {
            return _context.BookingItems.Find(id);
        }

        public void UpdateItem(BookingItem item)
        {
            _context.BookingItems.Update(item);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = _context.BookingItems.Find(id);
            if (item != null)
            {
                _context.BookingItems.Remove(item);
                _context.SaveChanges();
            }
        }


    }
}
