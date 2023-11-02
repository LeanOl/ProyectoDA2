using Data;
using Domain;

namespace Tests.DataTests;
[TestClass]
public class ShoppingCartRepositoryTests : ContextInMemory
{
    [TestMethod]
    public void UpdateShoppingCart_Ok() 
    {
        // Arrange
        var dbContext = createDbContext("UpdateShoppingCart");
        var shoppingCartManagement = new ShoppingCartManagement(dbContext);
        ShoppingCart expected = new ShoppingCart()
        {
            UserId = Guid.NewGuid(),
            IdCart = Guid.NewGuid(),
            ShoppingCartProducts = new List<ShoppingCartProducts>()
            {
                new ShoppingCartProducts()
                {
                    ProductId = Guid.NewGuid(),
                    Quantity = 1
                }
            }
        };
        dbContext.Set<ShoppingCart>().Add(expected);
        dbContext.SaveChanges();

        // Act
        expected.ShoppingCartProducts.First().Quantity = 2;
        expected.ShoppingCartProducts.Add(new ShoppingCartProducts()
        {
            ProductId = Guid.NewGuid(),
            Quantity = 3
        });
        var result = shoppingCartManagement.Update(expected);

        // Assert
        CollectionAssert.AreEquivalent(expected.ShoppingCartProducts,result.ShoppingCartProducts);



    }
}