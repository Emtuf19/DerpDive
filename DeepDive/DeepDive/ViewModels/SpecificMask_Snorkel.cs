using DeepDive.Validation;

namespace DeepDive.ViewModels
{
    public class SpecificMask_Snorkel
    {
        public int Mask_SnorkelId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
