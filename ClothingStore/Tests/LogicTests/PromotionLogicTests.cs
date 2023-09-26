using Data.Interfaces;
using Domain;
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
            Condition = new PromotionCondition
            {
                Category = new ConditionProperty { Count = 2, Match = "Same" },
                Color = new ConditionProperty { Count = 2, Match = "Different" }
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
}