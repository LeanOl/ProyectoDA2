using Data.Interfaces;
using Domain;
using Exceptions.LogicExceptions;
using Logic.Concrete;

namespace Tests.LogicTests;
[TestClass]
public class PromotionLogicTests
{
    [TestMethod]
    public void CreateNewPromotionOk()
    {
        Promotion expected = new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            ProductCondition = new PromotionProductCondition
            {
                Category = new PromotionCondition { Count = 2 },
                Color = new PromotionCondition { Count = 2 }
            },
            FreeProductCount = 1
        };
        Mock<IGenericRepository<Promotion>> mockRepo = new Mock<IGenericRepository<Promotion>>();
        mockRepo.Setup(repo => repo.Insert(It.IsAny<Promotion>())).Returns(expected);
        PromotionLogic logic = new PromotionLogic(mockRepo.Object);

        // Act
        Promotion result = logic.CreatePromotion(expected);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CreatePromotion_ConditionCountLessThanOne_Error()
    {
        // Arrange
        Promotion expected = new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            ProductCondition = new PromotionProductCondition
            {
                Category = new PromotionCondition { Count = 0 },
                Color = new PromotionCondition { Count = -1 },
                Brand = new PromotionCondition { Count = -2 }
            },
            FreeProductCount = 1
        };
        Mock<IGenericRepository<Promotion>> mockRepo = new Mock<IGenericRepository<Promotion>>();

        PromotionLogic logic = new PromotionLogic(mockRepo.Object);
        Exception ex = null;
        try
        {
            // Act
            Promotion result = logic.CreatePromotion(expected);
        }
        catch (Exception e)
        {
            ex = e;
        }

        // Assert
        mockRepo.VerifyAll();
        Assert.IsNotNull(ex);
        Assert.IsInstanceOfType(ex, typeof(InvalidConditionArgument));
        Assert.AreEqual(ex.Message, LogicExceptionMessages.InvalidConditionProductCount);
    }

    [TestMethod]
    public void GetAllPromotionsOk()
    {
        // Arrange
        Promotion expected = new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            ProductCondition = new PromotionProductCondition
            {
                Category = new PromotionCondition { Count = 2 },
                Color = new PromotionCondition { Count = 2 }
            },
            FreeProductCount = 1
        };
        Mock<IGenericRepository<Promotion>> mockRepo = new Mock<IGenericRepository<Promotion>>();
        mockRepo.Setup(repo => repo.GetAll<Promotion>()).Returns(new List<Promotion> { expected });
        PromotionLogic logic = new PromotionLogic(mockRepo.Object);
        // Act
        IEnumerable<Promotion> result = logic.GetAllPromotions();
        // Assert
        mockRepo.VerifyAll();
        Assert.AreEqual(expected, result.First());
    }
}