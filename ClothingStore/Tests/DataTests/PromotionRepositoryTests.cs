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
            ProductCondition = new PromotionProductCondition
            {
                Category = new PromotionCondition { Count = 2 },
                Brand = new PromotionCondition { Count = 2 },
                Color = new PromotionCondition { Count = 2 }
            },
            FreeProductCount = 1
        };

        // Act
        var result= promotionManagement.Insert(expected);

        // Assert
        Assert.AreEqual(expected, result);


    }

    private DbContext createDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ClothingStoreContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        return new ClothingStoreContext(options);
    }
}