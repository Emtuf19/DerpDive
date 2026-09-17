namespace DeepDive.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public List<BookingItem> BookingItems { get; set; } = new();
    }
}
