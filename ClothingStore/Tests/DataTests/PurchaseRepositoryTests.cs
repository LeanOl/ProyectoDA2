using Data;
using Domain;

namespace Tests.DataTests;
[TestClass]
public class PurchaseRepositoryTests : ContextInMemory
{
    [TestMethod]
    public void CreatePurchase_Ok()
    {
        // Arrange
        var dbContext = createDbContext("CreatePurchase");
        var purchaseManagement = new PurchaseManagement(dbContext);
        Purchase expected = new Purchase()
        {
            UserId = new Guid(),
            PaymentMethod = "Credit Card"
        };

        // Act
        var result = purchaseManagement.AddPurchase(expected);

        // Assert
        Assert.AreEqual(expected.UserId, result.UserId);
        Assert.AreEqual(expected.PaymentMethod, result.PaymentMethod);
    }
}