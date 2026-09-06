namespace DeepDive.Models
{
    public class Package : IEquipmentItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ImageUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
