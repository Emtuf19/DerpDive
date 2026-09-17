namespace DeepDive.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public string Title { get; set; }

        public int Price { get; set; }

        public List<PackageItem> PackageItems { get; set; } = new();
    }
}
