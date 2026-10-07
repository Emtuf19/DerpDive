using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IMask_SnorkelRepository
    {
        Task Add(Mask_Snorkel mask_Snorkel);
        Task Delete(int id);
        Task<List<Mask_Snorkel>> GetAll();
        Task<Mask_Snorkel?> GetById(int id);
        Task Update(Mask_Snorkel mask_Snorkel);
    }
}
