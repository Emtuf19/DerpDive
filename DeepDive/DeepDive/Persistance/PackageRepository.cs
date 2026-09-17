using DeepDive.Data;
using DeepDive.Enums;
using DeepDive.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Persistance
{
    public class PackageRepository : IPackageRepository
    {
        private readonly EquipmentContext _equipmentContext;

        public PackageRepository(EquipmentContext equipmentContext)
        {
            _equipmentContext = equipmentContext;
        }


        public void Add(Package package)
        {
            _equipmentContext.Packages.Add(package);
            _equipmentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var package = _equipmentContext.Packages.Find(id);
            if (package != null)
            {
                _equipmentContext.Packages.Remove(package);
                _equipmentContext.SaveChanges();
            }
        }

        public List<Package> GetAll()
        {
            return _equipmentContext.Packages.Include(p => p.PackageItems).ToList();
        }

        public Package? GetById(int id)
        {
            return _equipmentContext.Packages.Include(p => p.PackageItems).FirstOrDefault(p => p.PackageId == id);
        }

        public void Update(Package package)
        {
            _equipmentContext.Packages.Update(package);
            _equipmentContext.SaveChanges();
        }

        public void AddItem(int packageId, EquipmentType equipmentType, int equipmentId)
        {
            var item = new PackageItem
            {
                PackageId = packageId,
                EquipmentType = equipmentType,
                EquipmentId = equipmentId                
            };

            _equipmentContext.PackageItems.Add(item);
            _equipmentContext.SaveChanges();
        }

        public void RemoveItem(int packageItemId)
        {
            var item = _equipmentContext.PackageItems.Find(packageItemId);
            if (item != null)
            {
                _equipmentContext.PackageItems.Remove(item);
                _equipmentContext.SaveChanges();
            }
        }
    }
}
