using DeepDive.Data;
using DeepDive.Models;

namespace DeepDive.Persistance
{
    public class DivingSuitRepository : IDivingSuitsRepository
    {
        private readonly EquipmentContext _context;
        public DivingSuitRepository(EquipmentContext context)
        {
            _context = context;
        }

        public void Add(DivingSuits divingSuit)
        {
            _context.DivingSuits.Add(divingSuit);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var divingSuit = _context.DivingSuits.Find(id);
            if (divingSuit != null)
            {
                _context.DivingSuits.Remove(divingSuit);
                _context.SaveChanges();
            }
        }

        public List<DivingSuits> GetAll()
        {
            return _context.DivingSuits.ToList();
        }

        public DivingSuits? GetById(int id)
        {
            return _context.DivingSuits.FirstOrDefault(d => d.DivingSuitsId == id);
        }

        public void Update(DivingSuits divingSuit)
        {
            _context.DivingSuits.Update(divingSuit);
            _context.SaveChanges();
        }
    }
}
