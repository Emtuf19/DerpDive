using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IFinnsRepository
    {
        Task Add(Finns finns);
        Task Delete(int id);
        Task<List<Finns>> GetAll();
        Task<Finns?> GetById(int id);
        Task Update(Finns finns);
    }
}
