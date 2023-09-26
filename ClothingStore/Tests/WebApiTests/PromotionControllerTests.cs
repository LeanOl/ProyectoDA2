using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Tests.WebApiTests;

[TestClass]
public class PromotionControllerTests
{
    private PromotionRequest _receivedFreePromotionRequest;
    private PromotionRequest _receivedDiscountPromotionRequest;
    private Promotion _expectedFreePromotion;
    private Promotion _expectedDiscountPromotion;

    [TestInitialize]
    public void Initialize()
    {
        _receivedFreePromotionRequest = new PromotionRequest
        {
            Name = "Test Promotion",
            PromotionType = "FreeProducts",
            Condition = new PromotionConditionRequest
            {
                Category = new ConditionPropertyRequest { Count = 2, Match = "Same" },
                Brand = new ConditionPropertyRequest { Count = 2, Match = "Same" },
                Color = new ConditionPropertyRequest { Count = 2, Match = "Different" }
            },
            FreeProductCount = 1
        };
        _expectedFreePromotion= new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            Condition = new PromotionCondition
            {
                Category = new ConditionProperty { Count = 2, Match = "Same" },
                Brand = new ConditionProperty { Count = 2, Match = "Same" },
                Color = new ConditionProperty { Count = 2, Match = "Different" }
            },
            FreeProductCount = 1
        };
        _receivedDiscountPromotionRequest = new PromotionRequest
        {
            Name = "Test Promotion",
            PromotionType = "Discount",
            Condition = new PromotionConditionRequest
            {
                Category = new ConditionPropertyRequest { Count = 2, Match = "Same" }
            },
            DiscountPercentage = 10
        };
        _expectedDiscountPromotion = new DiscountPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            Condition = new PromotionCondition
            {
                Category = new ConditionProperty { Count = 2, Match = "Same" },

            },
            DiscountPercentage = 10
        };

    }

    [TestCleanup]
    public void Cleanup()
    {
        _receivedFreePromotionRequest = null;
        _receivedDiscountPromotionRequest = null;
        _expectedFreePromotion = null;
        _expectedDiscountPromotion = null;
    }

    [TestMethod]
    public void CreateFreeProductPromotionOk()
    {
        // Arrange
        PromotionRequest received = _receivedFreePromotionRequest;
        Promotion expected = _expectedFreePromotion;

        var expectedMappedResult = new PromotionResponse(expected);
        Mock<IPromotionLogic> logic = new Mock<IPromotionLogic>(MockBehavior.Strict);
        logic.Setup(l => l.CreatePromotion(It.IsAny<Promotion>())).Returns(expected);
        PromotionController controller = new PromotionController(logic.Object);
        CreatedAtActionResult expectedObjectResult = new CreatedAtActionResult("CreatePromotion", "CreatePromotion",
            new { id = 5 }, expectedMappedResult);

        // Act
        IActionResult result = controller.CreatePromotion(received);

        // Assert
        logic.VerifyAll();
        CreatedAtActionResult resultObject = result as CreatedAtActionResult;
        PromotionResponse resultValue = resultObject.Value as PromotionResponse;
        Assert.AreEqual(expectedObjectResult.StatusCode, resultObject.StatusCode);
        Assert.AreEqual(expectedMappedResult, resultValue);
    }

    [TestMethod]
    public void CreateDiscountPromotionOk()
    {
        // Arrange
        PromotionRequest received = _receivedDiscountPromotionRequest;
        Promotion expected = _expectedDiscountPromotion;
        var expectedMappedResult = new PromotionResponse(expected);
        Mock<IPromotionLogic> logic = new Mock<IPromotionLogic>(MockBehavior.Strict);
        logic.Setup(l => l.CreatePromotion(It.IsAny<Promotion>())).Returns(expected);
        PromotionController controller = new PromotionController(logic.Object);
        CreatedAtActionResult expectedObjectResult = new CreatedAtActionResult("CreatePromotion", "CreatePromotion",
            new { id = 5 }, expectedMappedResult);
        // Act
        IActionResult result = controller.CreatePromotion(received);

        // Assert
        logic.VerifyAll();
        CreatedAtActionResult resultObject = result as CreatedAtActionResult;
        PromotionResponse resultValue = resultObject.Value as PromotionResponse;
        Assert.AreEqual(expectedObjectResult.StatusCode, resultObject.StatusCode);
        Assert.AreEqual(expectedMappedResult, resultValue);
    }

    [TestMethod]
    public void GetAllPromotionsOk()
    {
        // Arrange
        IEnumerable<Promotion> expected = new List<Promotion>
        {
            _expectedFreePromotion,
            _expectedDiscountPromotion
        };

        var expectedMappedResult = expected.Select(p => new PromotionResponse(p));
        Mock<IPromotionLogic> logic = new Mock<IPromotionLogic>(MockBehavior.Strict);
        logic.Setup(l => l.GetAllPromotions()).Returns(expected);
        PromotionController controller = new PromotionController(logic.Object);
        OkObjectResult expectedObjectResult = new OkObjectResult(expectedMappedResult);

        // Act
        IActionResult result = controller.GetAllPromotions();

        // Assert
        logic.VerifyAll();
        OkObjectResult resultObject = result as OkObjectResult;
        IEnumerable<PromotionResponse> resultValue = resultObject.Value as List<PromotionResponse>;
        Assert.AreEqual(expectedObjectResult.StatusCode, resultObject.StatusCode);
        CollectionAssert.AreEquivalent(expectedMappedResult.ToList(), resultValue.ToList());
    }

    [TestMethod]
    public void DeletePromotion()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        Mock<IPromotionLogic> logic = new Mock<IPromotionLogic>(MockBehavior.Strict);
        logic.Setup(l => l.DeletePromotion(id));
        PromotionController controller = new PromotionController(logic.Object);
        OkResult expectedObjectResult = new OkResult();
        // Act
        IActionResult result = controller.DeletePromotion(id);
        // Assert
        logic.VerifyAll();
        OkResult resultObject = result as OkResult;
        Assert.AreEqual(expectedObjectResult.StatusCode, resultObject.StatusCode);
    }


}


