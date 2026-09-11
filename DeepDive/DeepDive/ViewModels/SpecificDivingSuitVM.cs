using DeepDive.Enums;

namespace DeepDive.ViewModels
{
    public class SpecificDivingSuitVM
    {
        public int DivingSuitsId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public List<EquipmentSize> AvailableSizes { get; set; } = new();
        public EquipmentSize SelectedSize { get; set; }

        public string Type { get; set; }

        public List<EquipmentGender> AvailableGenders { get; set; } = new();
        public EquipmentGender SelectedGender { get; set; }

        public int Thickness { get; set; }
        public double Price { get; set; }
    }
}
