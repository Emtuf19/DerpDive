using DeepDive.Data;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class BCDRepository : IBCDRepository
    {
        private readonly EquipmentContext _context;
        public BCDRepository(EquipmentContext context)
        {
            _context = context;
        }

        public async Task Add(BCD bcd)
        {
            _context.BCDs.Add(bcd);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var bcd = _context.BCDs.Find(id);
            if (bcd != null)
            {
                _context.BCDs.Remove(bcd);
                _context.SaveChanges();
            }
        }

        public async Task<List<BCD>> GetAll()
        {
            return await _context.BCDs.ToListAsync();
        }

        public async Task<BCD?> GetById(int id)
        {
            return await _context.BCDs.FirstOrDefaultAsync(b => b.BCDId == id);
        }

        public async Task Update(BCD bcd)
        {
            _context.BCDs.Update(bcd);
            _context.SaveChanges();
        }
    }
}
