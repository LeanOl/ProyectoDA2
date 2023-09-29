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
            Conditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition
                {
                    ProductPropertyCondition= "Brand",
                    QuantityCondition = "Count() >= 3",
                }
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
    public void CreatePromotion_InvalidCondition_Error()
    {
        // Arrange
        Promotion expected = new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            Conditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition()
                {
                    ProductPropertyCondition= "Brand",
                    QuantityCondition = "InvalidCondition",
                }
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
        Assert.AreEqual(LogicExceptionMessages.InvalidCondition,ex.Message );
    }

    [TestMethod]
    public void AddPromotion_InvalidConditionProperty_Error()
    {
                // Arrange
        Promotion expected = new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            Conditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition()
                {
                    ProductPropertyCondition= "InvalidProperty",
                    QuantityCondition = "Count() >= 3",
                }
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
        Assert.AreEqual(LogicExceptionMessages.InvalidCondition, ex.Message);
    }

    [TestMethod]
    public void GetAllPromotionsOk()
    {
        // Arrange
        Promotion expected = new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            Conditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition
                {
                    ProductPropertyCondition= "Brand",
                    QuantityCondition = "Count() >= 3",
                }
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

    [TestMethod]
    public void DeletePromotionOk()
    {
        Guid id = Guid.NewGuid();
        Promotion expected = new FreeProductPromotion
        {
            Id = id,
            Name = "Test Promotion",
            Conditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition
                {
                    ProductPropertyCondition= "Brand",
                    QuantityCondition = "Count() >= 3",
                }
            },
            FreeProductCount = 1
        };
        Mock<IGenericRepository<Promotion>> mockRepo = new Mock<IGenericRepository<Promotion>>();
        mockRepo.Setup(repo => repo.Get(p => p.Id == id,null)).Returns(expected);
        mockRepo.Setup(repo => repo.Delete(expected));

        PromotionLogic logic = new PromotionLogic(mockRepo.Object);

        // Act
        logic.DeletePromotion(id);

        // Assert
        mockRepo.VerifyAll();
    }

    [TestMethod]
    public void UpdatePromotionOk()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        Promotion expected = new FreeProductPromotion
        {
            Id = id,
            Name = "Test Promotion",
            Conditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition
                {
                    ProductPropertyCondition= "Brand",
                    QuantityCondition = "Count() >= 3",
                }
            },
            FreeProductCount = 1
        };
        Mock<IGenericRepository<Promotion>> mockRepo = new Mock<IGenericRepository<Promotion>>();
        mockRepo.Setup(repo => repo.Get(p => p.Id == id,null)).Returns(expected);
        mockRepo.Setup(repo => repo.Update(expected)).Returns(expected);
        PromotionLogic logic = new PromotionLogic(mockRepo.Object);
        // Act
        Promotion result = logic.UpdatePromotion(id, expected);
        // Assert
        mockRepo.VerifyAll();
        Assert.AreEqual(expected, result);
    }
}