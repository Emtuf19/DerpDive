using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        List<Booking> GetByUser(string userId);
        Booking? GetById(int id);
        void Update(Booking booking);
        void Delete(int id);
        BookingItem? GetItemById(int id);
        void UpdateItem(BookingItem item);
        void DeleteItem(int id);


    }
}
