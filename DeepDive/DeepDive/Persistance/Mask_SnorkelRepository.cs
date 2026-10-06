using DeepDive.Data;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class Mask_SnorkelRepository : IMask_SnorkelRepository
    {
        private readonly EquipmentContext _context;
        public Mask_SnorkelRepository(EquipmentContext context)
        {
            _context = context;
        }

        public async Task Add(Mask_Snorkel mask_Snorkel)
        {
            _context.Mask_Snorkels.Add(mask_Snorkel);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var mask_snorkel = _context.Mask_Snorkels.Find(id);
            if (mask_snorkel != null)
            {
                _context.Mask_Snorkels.Remove(mask_snorkel);
                _context.SaveChanges();
            }
        }

        public async Task<List<Mask_Snorkel>> GetAll()
        {
            return await _context.Mask_Snorkels.ToListAsync();
        }

        public async Task<Mask_Snorkel?> GetById(int id)
        {
            return await _context.Mask_Snorkels.FirstOrDefaultAsync(m => m.Mask_SnorkelId == id);
        }

        public async Task Update(Mask_Snorkel mask_Snorkel)
        {
            _context.Mask_Snorkels.Update(mask_Snorkel);
            _context.SaveChanges();
        }
    }
}
