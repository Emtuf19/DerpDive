using DeepDive.Validation;

namespace DeepDive.Models
{
    public class RegulatorSet
    {
        public int RegulatorSetId { get; set; }
        public string Brand { get; set; }
        public string FirstStep { get; set; }
        public string SecondStep { get; set; }
        public string Octopus { get; set; }
        public double Price { get; set; }

        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
