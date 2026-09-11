using DeepDive.Enums;
using DeepDive.Validation;

namespace DeepDive.Models
{
    public class BCD
    {
        public int BCDId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<EquipmentSize> Size { get; set; } = new();
        public double Price { get; set; }

        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; } 
    }
}
