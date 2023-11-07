using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using ILogic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Tests.WebApiTests;
[TestClass]
public class PurchaseControllerTests
{
    private Purchase _expectedPurchase;
    private PurchaseRequest _receivedRequest;
    private Guid _userId;
    [TestInitialize]
    public void Initialize()
    {
        _userId = Guid.NewGuid();
        PurchaseProduct product1 = new PurchaseProduct
        {
            ProductId = Guid.NewGuid(),
            Product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product1",
                Price = 100,
                Description = "Description1",
                Brand = "Brand1",
                Category = "Category1",
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = "Color1"
                    }
                }
            },
            Quantity = 1
        };
        PurchaseProduct product2 = new PurchaseProduct
        {
            ProductId = Guid.NewGuid(),
            Product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product2",
                Price = 150,
                Description = "Description2",
                Brand = "Brand2",
                Category = "Category2",
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = "Color2"
                    }
                }
            },
            Quantity = 2
        };
            _expectedPurchase = new Purchase
        {
            UserId = _userId,
            Products = new List<PurchaseProduct>
            {
                product1,
                product2
            },
            TotalPrice = 350,
            Discount = 0,
            FinalPrice = 350,
            PromotionName = "",
            PaymentMethod = "CreditCard"
        };
        _receivedRequest = new PurchaseRequest()
        {
            UserId = _userId
        };
    }

    [TestMethod]
    public void CreatePurchase_Ok()
    {
        // Arrange
        Purchase expectedPurchase = _expectedPurchase;
        Guid userId = _userId;
        PurchaseRequest receivedRequest = _receivedRequest;
        Mock<IPurchaseLogic> mockPurchaseLogic = new Mock<IPurchaseLogic>();
        mockPurchaseLogic.Setup(m => m.CreatePurchase(It.IsAny<PurchaseRequest>())).Returns(expectedPurchase);
        PurchaseController purchaseController = new PurchaseController(mockPurchaseLogic.Object);
        PurchaseResponse expectedResponse = new PurchaseResponse(expectedPurchase);
        CreatedAtActionResult expectedActionResult = new CreatedAtActionResult("CreatePurchase", "Purchase", new { id = expectedPurchase.Id }, expectedResponse);
        

        // Act
        var result = purchaseController.CreatePurchase(receivedRequest);
        PurchaseResponse resultValue = ((CreatedAtActionResult)result).Value as PurchaseResponse;

        // Assert
        Assert.AreEqual(resultValue.PurchaseId, expectedResponse.PurchaseId);

    }
}