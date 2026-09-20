using DeepDive.Enums;
using DeepDive.Validation;
namespace DeepDive.ViewModels
{
    public class SpecificPackage
    {
        public int PackageId { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }

        public List<EquipmentType> Content { get; set; } = new();

        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
