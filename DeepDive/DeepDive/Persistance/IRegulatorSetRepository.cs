using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IRegulatorSetRepository
    {
        void Add(RegulatorSet regulatorSet);
        void Delete(int id);
        List<RegulatorSet> GetAll();
        RegulatorSet? GetById(int id);
        void Update(RegulatorSet regulatorSet);
    }
}
