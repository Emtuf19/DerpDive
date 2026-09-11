using DeepDive.Validation;

namespace DeepDive.Models
{
    public class Tank
    {
        public int TankId { get; set; }
        public string Brand { get; set; }
        public int Volumen { get; set; }
        public double Price { get; set; }

        [DateNotInPast]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
