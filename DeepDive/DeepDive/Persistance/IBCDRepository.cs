using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IBCDRepository
    {
        void Add(BCD bcd);
        void Delete(int id);
        List<BCD> GetAll();
        BCD? GetById(int id);
        void Update(BCD bcd);
    }
}
