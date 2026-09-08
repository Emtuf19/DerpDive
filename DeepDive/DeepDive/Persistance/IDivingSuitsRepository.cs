using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IDivingSuitsRepository
    {
        void Add(DivingSuits divingSuit);
        void Delete(int id);
        List<DivingSuits> GetAll();
        DivingSuits? GetById(int id);
        void Update(DivingSuits divingSuit);
    }
}
