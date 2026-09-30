using DeepDive.Data;
using DeepDive.Enums;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class PackageRepository : IPackageRepository
    {
        private readonly EquipmentContext _context;

        public PackageRepository(EquipmentContext equipmentContext)
        {
            _context = equipmentContext;
        }


        public void Add(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var package = _context.Packages.Find(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
                _context.SaveChanges();
            }
        }

        public List<Package> GetAll()
        {
            return _context.Packages.Include(p => p.PackageItems).ToList();
        }

        public Package? GetById(int id)
        {
            return _context.Packages.Include(p => p.PackageItems).FirstOrDefault(p => p.PackageId == id);
        }

        public void Update(Package package)
        {
            _context.Packages.Update(package);
            _context.SaveChanges();
        }

        public void AddItem(int packageId, EquipmentType equipmentType, int equipmentId)
        {
            var item = new PackageItem
            {
                PackageId = packageId,
                EquipmentType = equipmentType,
                EquipmentId = equipmentId                
            };

            _context.PackageItems.Add(item);
            _context.SaveChanges();
        }

        public void RemoveItem(int packageItemId)
        {
            var item = _context.PackageItems.Find(packageItemId);
            if (item != null)
            {
                _context.PackageItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
