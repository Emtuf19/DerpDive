using DeepDive.Enums;

namespace DeepDive.Models
{
    public class DivingSuits
    {
        public int DivingSuitsId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<EquipmentSize> Size { get; set; } = new();
        public string Type { get; set; }
        public List<EquipmentGender> Gender { get; set; } = new();
        public int Thickness { get; set; }
        public double Price { get; set; }
    }
}
