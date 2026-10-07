using DeepDive.Data;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class DivingSuitRepository : IDivingSuitsRepository
    {
        private readonly EquipmentContext _context;
        public DivingSuitRepository(EquipmentContext context)
        {
            _context = context;
        }

        public async Task Add(DivingSuits divingSuit)
        {
            _context.DivingSuits.Add(divingSuit);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var divingSuit = _context.DivingSuits.Find(id);
            if (divingSuit != null)
            {
                _context.DivingSuits.Remove(divingSuit);
                _context.SaveChanges();
            }
        }

        public async Task<List<DivingSuits>> GetAll()
        {
            return await _context.DivingSuits.ToListAsync();
        }

        public async Task<DivingSuits?> GetById(int id)
        {
            return await _context.DivingSuits.FirstOrDefaultAsync(d => d.DivingSuitsId == id);
        }

        public async Task Update(DivingSuits divingSuit)
        {
            _context.DivingSuits.Update(divingSuit);
            _context.SaveChanges();
        }
    }
}
