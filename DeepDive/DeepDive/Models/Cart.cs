namespace DeepDive.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new();

        public void AddItem(CartItem item)
        {
            item.CartItemId = Items.Any()
                ? Items.Max(x => x.CartItemId) + 1 : 1;
            Items.Add(item);
        }
    }
}
