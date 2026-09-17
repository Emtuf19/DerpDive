using DeepDive.Enums;
using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IPackageRepository
    {
        void Add(Package package);
        void Delete(int id);
        List<Package> GetAll();
        Package? GetById(int id);
        void Update(Package package);
        void AddItem(int packageId, EquipmentType equipmentType, int equipmentId);
        void RemoveItem(int packageItemId);
    }
}
