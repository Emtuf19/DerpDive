using DeepDive.Enums;
using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IPackageRepository
    {
        Task Add(Package package);
        Task Delete(int id);
        Task<List<Package>> GetAll();
        Task<Package?> GetById(int id);
        Task Update(Package package);
        Task AddItem(int packageId, EquipmentType equipmentType, int equipmentId);
        Task RemoveItem(int packageItemId);
    }
}
