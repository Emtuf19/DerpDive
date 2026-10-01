using DeepDive.ViewModels;
namespace DeepDiveTest;

[TestClass]
public class CartTest
{
    [TestMethod]
    public void EmptyCart_ReturnsZero()
    {
        var cart = new CartVM();

        Assert.AreEqual(0, cart.TotalPrice);
    }

    [TestMethod]
    public void TotalPriceForThreeDays()
    {
        // Arrange
        var cart = new CartVM();
        cart.Items.Add(new CartItemVM
        {
            Price = 100,
            DateFrom = new DateTime(2026, 10, 1),
            DateTo = new DateTime(2026, 10, 4)
        });

        double total = cart.TotalPrice;

        Assert.AreEqual(300, total, 0.001);
    }

    [TestMethod]
    public void TotalPriceforTwoItems()
    {
        var cart = new CartVM();
        cart.Items.Add(new CartItemVM { Price = 100, DateFrom = new DateTime(2026, 10, 1), DateTo = new DateTime(2026, 10, 3) }); 
        cart.Items.Add(new CartItemVM { Price = 50, DateFrom = new DateTime(2026, 10, 1), DateTo = new DateTime(2026, 10, 2) }); 

        Assert.AreEqual(250, cart.TotalPrice, 0.001);
    }
}
