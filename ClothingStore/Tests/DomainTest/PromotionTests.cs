using Domain;

namespace Tests.DomainTest;
[TestClass]
public class PromotionTests
{
    [TestMethod]
    public void VerifyCartConditionSingularPromotionOk()
    {
                // Arrange
        var cart = new ShoppingCart(new List<Product>
        {
            new Product
            {
                Name = "Product 1",
                Price = 10,
                Category = "Category 1"
            },
            new Product
            {
                Name = "Product 2",
                Price = 20,
                Category = "Category 1"
            },
            new Product
            {
                Name = "Product 3",
                Price = 30,
                Category = "Category 2"
            }
        }, null);
        var condition = new SingularPromotionCondition
        {
            ProductPropertyCondition = "Category",
            QuantityCondition = "Count() >= 2"
        };
        // Act
        var result = condition.VerifyCartCondition(cart);
        // Assert
        Assert.IsTrue(result);
    
    }
}