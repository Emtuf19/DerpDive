using DeepDive.Data;
using DeepDive.Models;

namespace DeepDive.Persistance
{
    public class FinnsRepository : IFinnsRepository
    {
        private readonly EquipmentContext _context;
        public FinnsRepository(EquipmentContext context)
        {
            _context = context;
        }

        public void Add(Finns finns)
        {
            _context.Finns.Add(finns);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var finns = _context.Finns.Find(id);
            if (finns != null)
            {
                _context.Finns.Remove(finns);
                _context.SaveChanges();
            }
        }

        public List<Finns> GetAll()
        {
            return _context.Finns.ToList();
        }

        public Finns? GetById(int id)
        {
            return _context.Finns.FirstOrDefault(f => f.FinnsId == id);
        }

        public void Update(Finns finns)
        {
            _context.Finns.Update(finns);
            _context.SaveChanges();
        }
    }
}
