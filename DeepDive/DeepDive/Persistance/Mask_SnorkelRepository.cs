using DeepDive.Data;
using DeepDive.Models;

namespace DeepDive.Persistance
{
    public class Mask_SnorkelRepository : IMask_SnorkelRepository
    {
        private readonly EquipmentContext _context;
        public Mask_SnorkelRepository(EquipmentContext context)
        {
            _context = context;
        }

        public void Add(Mask_Snorkel mask_Snorkel)
        {
            _context.Mask_Snorkels.Add(mask_Snorkel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var mask_snorkel = _context.Mask_Snorkels.Find(id);
            if (mask_snorkel != null)
            {
                _context.Mask_Snorkels.Remove(mask_snorkel);
                _context.SaveChanges();
            }
        }

        public List<Mask_Snorkel> GetAll()
        {
            return _context.Mask_Snorkels.ToList();
        }

        public Mask_Snorkel? GetById(int id)
        {
            return _context.Mask_Snorkels.FirstOrDefault(m => m.Mask_SnorkelId == id);
        }

        public void Update(Mask_Snorkel mask_Snorkel)
        {
            _context.Mask_Snorkels.Update(mask_Snorkel);
            _context.SaveChanges();
        }
    }
}
