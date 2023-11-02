using Domain;

namespace Tests.DomainTest;

[TestClass]
public class ShoppingCartTests
{
    [TestMethod]
    public void UpdatePrice_Ok()
    {
        // Arrange
        ShoppingCart shoppingCart = new ShoppingCart();
        List<ShoppingCartProducts> cartProducts = new List<ShoppingCartProducts>();
        ShoppingCartProducts scp1 = new ShoppingCartProducts();
        scp1.Product = new Product()
        {
            Id = new Guid(),
            Brand = "Nike",
            Category = "Shoes",
            Price = 150
        };

        ShoppingCartProducts scp2 = new ShoppingCartProducts();
        scp2.Product = new Product()
        {
            Id = new Guid(),
            Brand = "Nike",
            Category = "Shoes",
            Price = 100
        };
        ShoppingCartProducts scp3 = new ShoppingCartProducts();
        scp3.Product = new Product()
        {
            Id = new Guid(),
            Brand = "Nike",
            Category = "Shoes",
            Price = 50
        };
        scp1.Quantity = 1;
        scp2.Quantity = 1;
        scp3.Quantity = 1;

        shoppingCart.Discount = 20;

        cartProducts.Add(scp1);
        cartProducts.Add(scp2);
        cartProducts.Add(scp3);

        shoppingCart.ShoppingCartProducts = cartProducts;

        // Act
        shoppingCart.UpdatePrices();

        // Assert
        Assert.AreEqual(300, shoppingCart.TotalPrice);
        Assert.AreEqual(280, shoppingCart.FinalPrice);
    }
}