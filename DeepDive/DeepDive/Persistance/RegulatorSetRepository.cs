using DeepDive.Data;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class RegulatorSetRepository : IRegulatorSetRepository
    {
        private readonly EquipmentContext _context;
        public RegulatorSetRepository(EquipmentContext context)
        {
            _context = context;
        }

        public async Task Add(RegulatorSet regulatorSet)
        {
            _context.RegulatorSets.Add(regulatorSet);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var regulatorSet = _context.RegulatorSets.Find(id);
            if (regulatorSet != null)
            {
                _context.RegulatorSets.Remove(regulatorSet);
                _context.SaveChanges();
            }
        }

        public async Task<List<RegulatorSet>> GetAll()
        {
            return await _context.RegulatorSets.ToListAsync();
        }

        public async Task<RegulatorSet?> GetById(int id)
        {
            return await _context.RegulatorSets.FirstOrDefaultAsync(r => r.RegulatorSetId == id);
        }

        public async Task Update(RegulatorSet regulatorSet)
        {
            _context.RegulatorSets.Update(regulatorSet);
            _context.SaveChanges();
        }
    }
}
