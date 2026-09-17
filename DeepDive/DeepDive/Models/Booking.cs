using DeepDive.Data;

namespace DeepDive.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public List<BookingItem> BookingItems { get; set; } = new();
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
