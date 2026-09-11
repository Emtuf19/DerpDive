using DeepDive.Enums;

namespace DeepDive.ViewModels
{
    public class CartItemVM
    {
        public int CartItemId { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public int EquipmentId { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }
        public string? Type { get; set; }

        public string? FirstStep { get; set; }

        public string? SecondStep { get; set; }

        public string? Octopus { get; set; }
        public int? Volumen { get; set; }
        public int? Thickness { get; set; }

        public EquipmentSize? SelectedSize { get; set; }

        public EquipmentGender? SelectedGender { get; set; }

        public double Price { get; set; }
    }
}
