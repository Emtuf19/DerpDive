using DeepDive.Enums;
using DeepDive.Validation;

namespace DeepDive.ViewModels
{
    public class SpecificBCD
    {
        public int BCDId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<EquipmentSize> AvailableSizes { get; set; } = new();
        public EquipmentSize SelectedSize { get; set; }
        public double Price { get; set; }

        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
