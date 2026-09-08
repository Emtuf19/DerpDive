using DeepDive.Models;

namespace DeepDive.Persistance
{
    public interface IMask_SnorkelRepository
    {
        void Add(Mask_Snorkel mask_Snorkel);
        void Delete(int id);
        List<Mask_Snorkel> GetAll();
        Mask_Snorkel? GetById(int id);
        void Update(Mask_Snorkel mask_Snorkel);
    }
}
