using DeepDive.Validation;

namespace DeepDive.ViewModels
{
    public class SpecificTank
    {
        public int TankId { get; set; }
        public string Brand { get; set; }
        public int Volumen { get; set; }
        public double Price { get; set; }

        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }


        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        [DateNotInPast]
        public DateTime DateTo { get; set; }
    }
}
