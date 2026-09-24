using DeepDive.Validation;

namespace DeepDive.ViewModels
{
    public class SpecificRegulatorSet
    {
        public int RegulatorSetId { get; set; }
        public string Brand { get; set; }
        public string FirstStep { get; set; }
        public string SecondStep { get; set; }
        public string Octopus { get; set; }
        public double Price { get; set; }

        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }


        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        [DateNotInPast]
        public DateTime DateTo { get; set; }
    }
}
