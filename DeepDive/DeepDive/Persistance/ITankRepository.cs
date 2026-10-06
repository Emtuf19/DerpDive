using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface ITankRepository
    {
        Task Add(Tank tank);
        Task Delete(int id);
        Task<List<Tank>> GetAll();
        Task<Tank?> GetById(int id);
        Task Update(Tank tank);
    }
}
