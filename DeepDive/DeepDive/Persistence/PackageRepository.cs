using DeepDive.Models;
namespace DeepDive.Persistence
{
    public static class PackageRepository
    {
        private static List<Package> packages = new List<Package>
        {
            new Package
        {
            Title = "Alt",
            Description =  " alt du skal bruge"
        }
            };

     public static List<Package> GetAll()
        {
            return packages;
        }


    }
}