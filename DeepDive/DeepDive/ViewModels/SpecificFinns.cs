using DeepDive.Enums;

namespace DeepDive.ViewModels
{
    public class SpecificFinns
    {
        public int FinnsId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<EquipmentSize> AvailableSizes { get; set; } = new();
        public EquipmentSize SelectedSize { get; set; }
        public double Price { get; set; }
    }
}
