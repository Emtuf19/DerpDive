using DeepDive.Models;

namespace DeepDive.ViewModels
{
    public class AllEquipmentViewData
    {
        public List<BCD> bcds { get; set; } = new List<BCD>();

        public List<DivingSuits> divingSuits { get; set; } = new List<DivingSuits>();

        public List<Finns> finns { get; set; } = new List<Finns>();

        public List<Mask_Snorkel> mask_Snorkels { get; set; } = new List<Mask_Snorkel>();  

        public List<RegulatorSet> regulatorSets { get; set; } = new List<RegulatorSet>();

        public List<Tank> tanks { get; set; } = new List<Tank>();
    }
}
