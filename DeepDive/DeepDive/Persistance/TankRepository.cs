using DeepDive.Data;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class TankRepository : ITankRepository
    {
        private readonly EquipmentContext _context;
        public TankRepository(EquipmentContext context)
        {
            _context = context;
        }

        public async Task Add(Tank tank)
        {
            _context.Tanks.Add(tank);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var tank = _context.Tanks.Find(id);
            if (tank != null)
            {
                _context.Tanks.Remove(tank);
                _context.SaveChanges();
            }
        }

        public async Task<List<Tank>> GetAll()
        {
            return await _context.Tanks.ToListAsync();
        }

        public async Task<Tank?> GetById(int id)
        {
            return await _context.Tanks.FirstOrDefaultAsync(t => t.TankId == id);
        }

        public async Task Update(Tank tank)
        {
            _context.Tanks.Update(tank);
            _context.SaveChanges();
        }
    }
}
