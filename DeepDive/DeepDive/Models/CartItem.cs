using DeepDive.Enums;

namespace DeepDive.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public int EquipmentId { get; set; }
        public EquipmentSize? SelectedSize { get; set; }
        public EquipmentGender? SelectedGender { get; set; }
        public double Price { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
