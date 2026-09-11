namespace DeepDive.ViewModels
{
    public class CartVM
    {
        public List<CartItemVM> Items { get; set; } = new();
        public double TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price);
            }
        }
    }
}
