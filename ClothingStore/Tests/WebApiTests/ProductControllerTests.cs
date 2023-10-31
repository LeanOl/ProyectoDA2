using APIModels.OutputModels;
using Domain;
using ILogic;
using Microsoft.AspNetCore.Mvc;

namespace Tests.WebApiTests;

[TestClass]
public class ProductControllerTests
{
    [TestMethod]
    public void GetAllProducts_Ok()
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
        var expectedMappedResult = expectedProducts.Select(p => new ProductResponse(p));
        Mock<IProductLogic> logic = new Mock<IProductLogic>(MockBehavior.Strict);
        logic.Setup(l => l.GetFilteredProducts("")).Returns(expectedProducts);
        ProductsController controller = new ProductsController(logic.Object);
        OkObjectResult expected = new OkObjectResult(expectedMappedResult);

        // Act
        IActionResult result = controller.GetFilteredProducts("");

        // Assert
        logic.VerifyAll();
        OkObjectResult resultObject = result as OkObjectResult;
        List<ProductResponse> resultValue = resultObject.Value as List<ProductResponse>;
        Assert.AreEqual(expected.StatusCode, resultObject.StatusCode);
        CollectionAssert.AreEquivalent(expectedMappedResult.ToList(), resultValue.ToList());

    }

    [TestMethod]
    public void GetFilteredProducts_Ok()
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
        var expectedMappedResult = expectedProducts.Select(p => new ProductResponse(p));
        Mock<IProductLogic> logic = new Mock<IProductLogic>(MockBehavior.Strict);
        logic.Setup(l => l.GetFilteredProducts("Test")).Returns(expectedProducts);
        ProductsController controller = new ProductsController(logic.Object);
        OkObjectResult expected = new OkObjectResult(expectedMappedResult);

        // Act
        IActionResult result = controller.GetFilteredProducts("Test");

        // Assert
        logic.VerifyAll();
        OkObjectResult resultObject = result as OkObjectResult;
        List<ProductResponse> resultValue = resultObject.Value as List<ProductResponse>;
        Assert.AreEqual(expected.StatusCode, resultObject.StatusCode);
        CollectionAssert.AreEquivalent(expectedMappedResult.ToList(), resultValue.ToList());

    }

}