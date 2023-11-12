using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using ILogic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Tests.WebApiTests;
[TestClass]
public class ShoppingCartControllerTests
{
    
    private ShoppingCartRequest _receivedShoppingCartRequest;
    private List<ShoppingCartProductRequest> _receivedShoppingCartProductRequest;
    private ShoppingCart _expectedShoppingCart;
    

    [TestInitialize]
    public void TestInitialize()
    {
        Guid idCart = Guid.NewGuid();
        _receivedShoppingCartProductRequest = new List<ShoppingCartProductRequest>
        {
            new ShoppingCartProductRequest
            {
                Product = new ProductRequest
                {
                    Brand = "Nike",
                    Category = "Shoes",
                    Price = 150,
                    Colors = new List<string>()
                },
                Quantity = 1
            },
            new ShoppingCartProductRequest
            {
                Product = new ProductRequest
                {
                    Brand = "Nike",
                    Category = "Shoes",
                    Price = 100,
                    Colors = new List<string>()
                },
                Quantity = 2
            }
        };
        _receivedShoppingCartRequest = new ShoppingCartRequest
        {
            Products = _receivedShoppingCartProductRequest,
            UserId = Guid.NewGuid()
        };
        _expectedShoppingCart = new ShoppingCart
        {
            UserId = _receivedShoppingCartRequest.UserId,
            Id = idCart,
            ShoppingCartProducts = _receivedShoppingCartProductRequest.ConvertAll(product =>
                               new ShoppingCartProducts()
                               {
                                   Product = new Product
                                   {
                                       Brand = "Nike",
                                       Category = "Shoes",
                                       Price = 150,
                                       Colors = new List<ProductColor>()
                                   },
                                   Quantity = product.Quantity
                               })
        };


    }

    [TestMethod]
    public void UpdateShoppingCart_Ok()
    {
        // Arrange
        ShoppingCartRequest received = _receivedShoppingCartRequest;
        ShoppingCart expected = _expectedShoppingCart;
        var expectedMappedResult = new ShoppingCartResponse(expected);
        var shoppingCartLogic = new Mock<IShoppingCartLogic>(MockBehavior.Strict);
        shoppingCartLogic.Setup(m => m.UpdateShoppingCart(It.IsAny<ShoppingCart>())).Returns(expected);
        OkObjectResult expectedActionResult = new OkObjectResult(expectedMappedResult);
        var controller = new ShoppingCartController(shoppingCartLogic.Object);
        // Act
        IActionResult result = controller.UpdateShoppingCart(received);
        // Assert
        shoppingCartLogic.VerifyAll();
        OkObjectResult resultObject = result as OkObjectResult;
        ShoppingCartResponse resultValue = resultObject.Value as ShoppingCartResponse;
        Assert.AreEqual(expectedActionResult.StatusCode, resultObject.StatusCode);
        Assert.AreEqual(expectedMappedResult.Id, resultValue.Id);

    }

    [TestMethod]
    public void DeleteCartProduct_Ok()
    {
        // Arrange
        Guid productId = Guid.NewGuid();
        DeleteShoppingCartProductRequest request = new DeleteShoppingCartProductRequest()
        {
            Cart = _receivedShoppingCartRequest,
            ProductId = productId
        };
        ShoppingCart expected = _expectedShoppingCart;
        var expectedMappedResult = new ShoppingCartResponse(expected);
        var shoppingCartLogic = new Mock<IShoppingCartLogic>(MockBehavior.Strict);
        shoppingCartLogic.Setup(m => m.DeleteProduct(It.IsAny<ShoppingCart>(), It.IsAny<Guid>())).Returns(expected);

        OkObjectResult expectedActionResult = new OkObjectResult(expectedMappedResult);
        var controller = new ShoppingCartController(shoppingCartLogic.Object);

        // Act
        IActionResult result = controller.DeleteCartProduct(request);

        //Assert
        shoppingCartLogic.VerifyAll();
        OkObjectResult resultObject = result as OkObjectResult;
        ShoppingCartResponse resultValue = resultObject.Value as ShoppingCartResponse;
        Assert.AreEqual(expectedActionResult.StatusCode, resultObject.StatusCode);
        Assert.AreEqual(resultValue.Id, resultValue.Id);
    }

    [TestMethod]
    public void GetCartByUserId_Ok()
    {
        // Arrange
        ShoppingCart expected = _expectedShoppingCart;
        Guid userId = expected.UserId;
        var expectedMappedResult = new ShoppingCartResponse(expected);
        var shoppingCartLogic = new Mock<IShoppingCartLogic>(MockBehavior.Strict);
        shoppingCartLogic.Setup(m => m.GetShoppingCartByUserId(It.IsAny<Guid>())).Returns(expected);
        OkObjectResult expectedActionResult = new OkObjectResult(expectedMappedResult);

        // Act
        IActionResult result = new ShoppingCartController(shoppingCartLogic.Object).GetCartByUserId(userId);

        // Assert
        shoppingCartLogic.VerifyAll();
        OkObjectResult resultObject = result as OkObjectResult;
        ShoppingCartResponse resultValue = resultObject.Value as ShoppingCartResponse;
        Assert.AreEqual(expectedActionResult.StatusCode, resultObject.StatusCode);
        Assert.AreEqual(expectedMappedResult.Id, resultValue.Id);

    }
}