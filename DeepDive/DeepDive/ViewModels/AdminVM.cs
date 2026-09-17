using DeepDive.Models;
namespace DeepDive.ViewModels
{
    public class AdminVM
    {
        public List<Booking> Bookings { get; set; } = new();
        public AllEquipmentViewData Equipment { get; set; } = new();

    }
}
