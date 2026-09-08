using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IFinnsRepository
    {
        void Add(Finns finns);
        void Delete(int id);
        List<Finns> GetAll();
        Finns? GetById(int id);
        void Update(Finns finns);
    }
}
