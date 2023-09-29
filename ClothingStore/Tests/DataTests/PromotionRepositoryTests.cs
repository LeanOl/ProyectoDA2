using Data;
using Data.Concrete;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Tests.DataTests;
[TestClass]
public class PromotionRepositoryTests
{
    [TestMethod]
    public void AddPromotion()
    {
        // Arrange
        var dbContext = createDbContext("AddUser");
        var promotionManagement = new PromotionManagement(dbContext);
        var expected = new FreeProductPromotion
        {
            Id = Guid.NewGuid(),
            Name = "Test Promotion",
            Conditions = new List<PromotionCondition>()
            {
                new SingularPromotionCondition()
                {
                    ProductPropertyCondition= "Brand",
                    QuantityCondition = "Count() >= 3",
                }
            },
            FreeProductCount = 1
        };

        // Act
        var result= promotionManagement.Insert(expected);

        // Assert
        Assert.AreEqual(expected, result);


    }

    [TestMethod]
    public void GetAllPromotions()
    {
        // Arrange
        var dbContext = createDbContext("GetAllPromotions");
        var promotionManagement = new PromotionManagement(dbContext);
        var expected = new FreeProductPromotion
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
        dbContext.Set<Promotion>().Add(expected);
        dbContext.SaveChanges();
        // Act
        var result = promotionManagement.GetAll<Promotion>();
        // Assert
        Assert.AreEqual(expected, result.First());
    }



    private DbContext createDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ClothingStoreContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        return new ClothingStoreContext(options);
    }
}