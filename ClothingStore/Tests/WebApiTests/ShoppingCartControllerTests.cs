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
                ProductId = Guid.NewGuid(),
                Quantity = 1
            },
            new ShoppingCartProductRequest
            {
                ProductId = Guid.NewGuid(),
                Quantity = 2
            }
        };
        _receivedShoppingCartRequest = new ShoppingCartRequest
        {
            CartProducts = _receivedShoppingCartProductRequest,
            UserId = Guid.NewGuid()
        };
        _expectedShoppingCart = new ShoppingCart
        {
            UserId = _receivedShoppingCartRequest.UserId,
            IdCart = idCart,
            ShoppingCartProducts = _receivedShoppingCartProductRequest.ConvertAll(product =>
                               new ShoppingCartProducts(idCart, product.ProductId, product.Quantity))
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
        shoppingCartLogic.Setup(m => m.UpdateShoppingCart(received)).Returns(expected);
        OkObjectResult expectedActionResult = new OkObjectResult(expectedMappedResult);
        var controller = new ShoppingCartController(shoppingCartLogic.Object);
        // Act
        IActionResult result = controller.UpdateShoppingCart(received);
        // Assert
        shoppingCartLogic.VerifyAll();
        OkObjectResult resultObject = result as OkObjectResult;
        ShoppingCartResponse resultValue = resultObject.Value as ShoppingCartResponse;
        Assert.AreEqual(expectedActionResult.StatusCode, resultObject.StatusCode);
        Assert.AreEqual(expectedMappedResult.IdCart, resultValue.IdCart);

    }
}