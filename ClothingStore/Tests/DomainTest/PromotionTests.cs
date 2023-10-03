using Domain;

namespace Tests.DomainTest
{
    [TestClass]
    public class PromotionTests
{
    [TestMethod]
    public void GetDiscountFreeProductPromotionOk()
    {
        // Arrange
        var cart = new ShoppingCart{ProductList = new List<Product>
        {
            new Product
            {
                Name = "Product 1",
                Price = 10,
                Category = "Category 1",
                Colors = new List<string> { "Red", "Blue" }
            },
            new Product
            {
                Name = "Product 2",
                Price = 20,
                Category = "Category 1",
                Colors = new List<string> { "Red", "Blue" }
            },
            new Product
            {
                Name = "Product 3",
                Price = 30,
                Category = "Category 2",
                Colors = new List<string> { "Blue", "Yellow" }
            }
        }
    };

    var promotion1 = new FreeProductPromotion
        {
            Name = "Test Promotion",
            PromotionConditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition()
                {
                    ProductPropertyCondition= "Category",
                    QuantityCondition = "Count() >= 2",
                }
            },
            FreeProductCount = 1
        };

        // Act
        decimal discount=promotion1.GetDiscount(cart);

        // Assert
        Assert.AreEqual(10,discount);
    }

    [TestMethod]
    public void GetDiscountPercentagePromotionOk()
    {
        // Arrange
        var cart = new ShoppingCart{ProductList = new List<Product>
        {
            new Product
            {
                Name = "Product 1",
                Price = 10,
                Category = "Category 1",
                Colors= new List<string> {"Red","Blue"}
            },
            new Product
            {
                Name = "Product 2",
                Price = 20,
                Category = "Category 1",
                Colors= new List<string> {"Red","Blue"}
            },
            new Product
            {
                Name = "Product 3",
                Price = 30,
                Category = "Category 2",
                Colors= new List<string> {"Blue","Yellow"}
            }
        }};
        var promotion1 = new DiscountPromotion()
        {
            Name = "Test Promotion",
            PromotionConditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition()
                {
                    ProductPropertyCondition= "Category",
                    QuantityCondition = "Count() >= 2",
                }
            },
            DiscountPercentage = 50
        };
        // Act
        decimal discount=promotion1.GetDiscount(cart);
        // Assert
        Assert.AreEqual(15,discount);
    }
}
}