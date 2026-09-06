namespace DeepDive.Models
{
    public interface IEquipmentItem
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        string ImageUrl { get; set; }

    }
}
