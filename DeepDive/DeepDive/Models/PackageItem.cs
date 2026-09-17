using DeepDive.Enums;

namespace DeepDive.Models
{
    public class PackageItem
    {
        public int PackageItemId { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public int EquipmentId { get; set; }

        public int PackageId { get; set; }
        public Package? Package { get; set; }


    }
}
