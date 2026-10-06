using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IRegulatorSetRepository
    {
        Task Add(RegulatorSet regulatorSet);
        Task Delete(int id);
        Task<List<RegulatorSet>> GetAll();
        Task<RegulatorSet?> GetById(int id);
        Task Update(RegulatorSet regulatorSet);
    }
}
