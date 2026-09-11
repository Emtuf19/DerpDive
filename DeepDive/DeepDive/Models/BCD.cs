using DeepDive.Enums;

namespace DeepDive.Models
{
    public class BCD
    {
        public int BCDId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<EquipmentSize> Size { get; set; } = new();
        public double Price { get; set; }
    }
}
