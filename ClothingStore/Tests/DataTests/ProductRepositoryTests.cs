using Data.Concrete;
using Domain;

namespace Tests.DataTests;
[TestClass]
public class ProductRepositoryTests : ContextInMemory
{
    [TestMethod]
    public void GetAllProducts_Ok()
    {
        // Arrange
        var dbContext = createDbContext("GetAllPromotions");
        var promotionManagement = new ProductManagement(dbContext);
        var expected = new Product("Test Product 1", 10, "Test Description 1", "Test Brand 1", "Test Category 1", new List<ProductColor>());

        dbContext.Set<Product>().Add(expected);
        dbContext.SaveChanges();
        // Act
        var result = promotionManagement.GetAllProducts();
        // Assert
        Assert.AreEqual(expected, result.First());
    }

    [TestMethod]
    public void GetFilteredNameProduct_Ok()
    {
        // Arrange
        var dbContext = createDbContext("GetFilteredNameProduct");
        var promotionManagement = new ProductManagement(dbContext);
        var expected = new Product("Test Product 1", 10, "Test Description 1", "Test Brand 1", "Test Category 1", new List<ProductColor>());

        dbContext.Set<Product>().Add(expected);
        dbContext.SaveChanges();
        // Act
        var result = promotionManagement.GetFilteredProducts("Test");
        // Assert
        Assert.AreEqual(expected, result.First());
    }
}