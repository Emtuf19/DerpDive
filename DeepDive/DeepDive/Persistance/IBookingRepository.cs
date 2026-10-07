using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAll();
        Task<List<Booking>> GetByUser(string userId);
        Task<Booking?> GetById(int id);
        Task Update(Booking booking);
        Task Delete(int id);
        Task<BookingItem?> GetItemById(int id);
        Task UpdateItem(BookingItem item);
        Task DeleteItem(int id);


    }
}
