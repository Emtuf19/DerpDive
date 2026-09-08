using DeepDive.Data;
using DeepDive.Models;

namespace DeepDive.Persistance
{
    public class RegulatorSetRepository : IRegulatorSetRepository
    {
        private readonly EquipmentContext _context;
        public RegulatorSetRepository(EquipmentContext context)
        {
            _context = context;
        }

        public void Add(RegulatorSet regulatorSet)
        {
            _context.RegulatorSets.Add(regulatorSet);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var regulatorSet = _context.RegulatorSets.Find(id);
            if (regulatorSet != null)
            {
                _context.RegulatorSets.Remove(regulatorSet);
                _context.SaveChanges();
            }
        }

        public List<RegulatorSet> GetAll()
        {
            return _context.RegulatorSets.ToList();
        }

        public RegulatorSet? GetById(int id)
        {
            return _context.RegulatorSets.FirstOrDefault(r => r.RegulatorSetId == id);
        }

        public void Update(RegulatorSet regulatorSet)
        {
            _context.RegulatorSets.Update(regulatorSet);
            _context.SaveChanges();
        }
    }
}
