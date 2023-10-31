using IData;
using Domain;
using Logic;

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
        IEnumerable<Product> result = logic.GetFilteredProducts("");

        // Assert
        CollectionAssert.AreEquivalent(expectedProducts.ToList(), result.ToList());

    }

    [TestMethod]
    public void GetFilteredProducts_Ok()
    {
        // Arrange 
        IEnumerable<Product> expectedProducts = new List<Product>()
        {
            new Product("Test Product 1", 10, "Test Description 1", "Test Brand 1", "Test Category 1",
                               new List<ProductColor>()),
            new Product("Test Product 2", 20, "Test Description 2", "Test Brand 2", "Test Category 2",
                               new List<ProductColor>()),
            new Product("Test Product 3", 30, "Test Description 3", "Test Brand 3", "Test Category 3",
                               new List<ProductColor>())
        };
        Mock<IProductManagement> mock = new(MockBehavior.Strict);
        mock.Setup(m => m.GetFilteredProducts("Test")).Returns(expectedProducts);
        ProductLogic logic = new(mock.Object);

        // Act
        IEnumerable<Product> result = logic.GetFilteredProducts("Test");

        // Assert
        CollectionAssert.AreEquivalent(expectedProducts.ToList(), result.ToList());

    }
}