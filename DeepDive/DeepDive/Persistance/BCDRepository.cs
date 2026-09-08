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

        public void Add(BCD bcd)
        {
            _context.BCDs.Add(bcd);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var bcd = _context.BCDs.Find(id);
            if (bcd != null)
            {
                _context.BCDs.Remove(bcd);
                _context.SaveChanges();
            }
        }

        public List<BCD> GetAll()
        {
            return _context.BCDs.ToList();
        }

        public BCD? GetById(int id)
        {
            return _context.BCDs.FirstOrDefault(b => b.BCDId == id);
        }

        public void Update(BCD bcd)
        {
            _context.BCDs.Update(bcd);
            _context.SaveChanges();
        }
    }
}
