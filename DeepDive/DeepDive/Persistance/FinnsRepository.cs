using DeepDive.Data;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class FinnsRepository : IFinnsRepository
    {
        private readonly EquipmentContext _context;
        public FinnsRepository(EquipmentContext context)
        {
            _context = context;
        }

        public async Task Add(Finns finns)
        {
            _context.Finns.Add(finns);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var finns = _context.Finns.Find(id);
            if (finns != null)
            {
                _context.Finns.Remove(finns);
                _context.SaveChanges();
            }
        }

        public async Task<List<Finns>> GetAll()
        {
            return await _context.Finns.ToListAsync();
        }

        public async Task<Finns?> GetById(int id)
        {
            return await _context.Finns.FirstOrDefaultAsync(f => f.FinnsId == id);
        }

        public async Task Update(Finns finns)
        {
            _context.Finns.Update(finns);
            _context.SaveChanges();
        }
    }
}
