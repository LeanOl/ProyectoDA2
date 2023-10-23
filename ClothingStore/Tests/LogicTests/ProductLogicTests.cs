using Data.Interfaces;
using Domain;
using Logic.Concrete;

namespace Tests.LogicTests;
[TestClass]
public class ProductLogicTests
{
    [TestMethod]
    public void GetAllPromotions_Ok()
    {
        // Arrange 
        ICollection<Product> expectedProducts = new List<Product>()
        {
            new Product("Test Product 1", 10, "Test Description 1", "Test Brand 1", "Test Category 1",
                new List<ProductColor>()),
            new Product("Test Product 2", 20, "Test Description 2", "Test Brand 2", "Test Category 2",
                new List<ProductColor>()),
            new Product("Test Product 3", 30, "Test Description 3", "Test Brand 3", "Test Category 3",
                new List<ProductColor>())
        };
        Mock<IProductManagement> mock = new(MockBehavior.Strict);
        mock.Setup(m => m.GetAllProducts()).Returns(expectedProducts);
        ProductLogic logic = new(mock.Object);

        // Act
        IEnumerable<Product> result = logic.GetAllProducts();

        // Assert
        CollectionAssert.AreEquivalent(expectedProducts.ToList(), result.ToList());


    }
}