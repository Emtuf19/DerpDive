using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IBCDRepository
    {
        Task Add(BCD bcd);
        Task Delete(int id);
        Task<List<BCD>> GetAll();
        Task<BCD?> GetById(int id);
        Task Update(BCD bcd);
    }
}
