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
            Id = Guid.NewGuid(),
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

    [TestMethod]
    public void ClearShoppingCart_Ok()
    {
                // Arrange
        var dbContext = createDbContext("ClearShoppingCart");
        var shoppingCartManagement = new ShoppingCartManagement(dbContext);
        ShoppingCart expected = new ShoppingCart()
        {
            UserId = Guid.NewGuid(),
            Id = Guid.NewGuid(),
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
        shoppingCartManagement.ClearShoppingCart(expected);
        var result = shoppingCartManagement.GetShoppingCartByUserId(expected.UserId);

        // Assert
        Assert.AreEqual(0,result.ShoppingCartProducts.Count);
    }

    [TestMethod]
    public void DeleteCartProduct_Ok()
    {
        //Arrange
        var dbContext = createDbContext("DeleteCartProduct");
        var shoppingCartManagement = new ShoppingCartManagement(dbContext);
        Guid cartId = Guid.NewGuid();
        Guid productId = Guid.NewGuid();
        ShoppingCart cart = new ShoppingCart()
        {
            UserId = cartId,
            Id = cartId,
            ShoppingCartProducts = new List<ShoppingCartProducts>()
            {
                new ShoppingCartProducts()
                {
                    ProductId = productId,
                    Product = new Product()
                    {
                        Id = productId,
                        Name = "Air Force 1",
                        Description = "Nike Air Force 1",
                        Brand = "Nike",
                        Category = "Shoes",
                        Price = 150,
                        Colors = new List<ProductColor>()
                    },
                    Quantity = 1
                }
            }
        };

        dbContext.Set<ShoppingCart>().Add(cart);
        dbContext.SaveChanges();

        //Act
        shoppingCartManagement.DeleteProduct(cartId, productId);

        //Assert
        Assert.AreEqual(0, cart.ShoppingCartProducts.Count);

    }
    
}