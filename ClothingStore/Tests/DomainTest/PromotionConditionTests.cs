using Domain;

namespace Tests.DomainTest;
[TestClass]
public class PromotionConditionTests
{
    [TestMethod]
    public void VerifyCartConditionSingularPromotionOk()
    {
        // Arrange
        var cart = new ShoppingCart{ProductList = new List<Product>
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
        }
    };

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

    [TestMethod]
    public void VerifyCartConditionCollectionPromotionOk()
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
                Colors = new List<string> {"White","Yellow","Blue"}

            },
            new Product
            {
                Name = "Product 3",
                Price = 30,
                Category = "Category 2",
                Colors = new List<string> {"Black"}
            }
        }};
        var condition = new CollectionPromotionCondition
        {
            ProductPropertyCondition = "Colors",
            QuantityCondition = "Count() >= 2"
        };
        // Act
        var result = condition.VerifyCartCondition(cart);
        // Assert
        Assert.IsTrue(result);
    }
}