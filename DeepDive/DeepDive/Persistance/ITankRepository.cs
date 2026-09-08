using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface ITankRepository
    {
        void Add(Tank tank);
        void Delete(int id);
        List<Tank> GetAll();
        Tank? GetById(int id);
        void Update(Tank tank);
    }
}
