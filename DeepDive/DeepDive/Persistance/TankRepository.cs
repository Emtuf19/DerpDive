using DeepDive.Data;
using DeepDive.Models;

namespace DeepDive.Persistance
{
    public class TankRepository : ITankRepository
    {
        private readonly EquipmentContext _context;
        public TankRepository(EquipmentContext context)
        {
            _context = context;
        }

        public void Add(Tank tank)
        {
            _context.Tanks.Add(tank);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tank = _context.Tanks.Find(id);
            if (tank != null)
            {
                _context.Tanks.Remove(tank);
                _context.SaveChanges();
            }
        }

        public List<Tank> GetAll()
        {
            return _context.Tanks.ToList();
        }

        public Tank? GetById(int id)
        {
            return _context.Tanks.FirstOrDefault(t => t.TankId == id);
        }

        public void Update(Tank tank)
        {
            _context.Tanks.Update(tank);
            _context.SaveChanges();
        }
    }
}
