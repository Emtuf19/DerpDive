using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IDivingSuitsRepository
    {
        Task Add(DivingSuits divingSuit);
        Task Delete(int id);
        Task<List<DivingSuits>> GetAll();
        Task<DivingSuits?> GetById(int id);
        Task Update(DivingSuits divingSuit);
    }
}
