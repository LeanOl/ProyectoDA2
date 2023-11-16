using System.Security.Principal;
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
            UserId = Guid.NewGuid(),
            PaymentMethod = "Credit Card"
        };

        // Act
        var result = purchaseManagement.AddPurchase(expected);

        // Assert
        Assert.AreEqual(expected.UserId, result.UserId);
        Assert.AreEqual(expected.PaymentMethod, result.PaymentMethod);
    }

    [TestMethod]
    public void GetAllPurchases_Ok()
    {
        // Arrange
        var dbContext = createDbContext("GetAllPurchases");
        var purchaseManagement = new PurchaseManagement(dbContext);
        Purchase expected = new Purchase()
        {
            UserId = Guid.NewGuid(),
            PaymentMethod = "Credit Card"
        };
        Purchase expected2 = new Purchase()
        {
            UserId = Guid.NewGuid(),
            PaymentMethod = "Credit Card"
        };
        List<Purchase> expectedList = new List<Purchase>()
        {
            expected,
            expected2
        };
        dbContext.Set<Purchase>().Add(expected);
        dbContext.Set<Purchase>().Add(expected2);
        dbContext.SaveChanges();
        // Act
        List<Purchase> result = purchaseManagement.GetAllPurchases().ToList();

        // Assert
        CollectionAssert.AreEquivalent(expectedList, result);
    }

    [TestMethod]
    public void GetPurchasesByUser_Ok()
    {
        // Arrange
        var dbContext = createDbContext("GetPurchasesByUser");
        var purchaseManagement = new PurchaseManagement(dbContext);
        Guid userId = Guid.NewGuid();
        Purchase expected = new Purchase()
        {
            UserId = userId,
            PaymentMethod = "Credit Card"
        };
        Purchase expected2 = new Purchase()
        {
            UserId = Guid.NewGuid(),
            PaymentMethod = "Credit Card"
        };
        List<Purchase> expectedList = new List<Purchase>()
        {
            expected
        };
        dbContext.Set<Purchase>().Add(expected);
        dbContext.Set<Purchase>().Add(expected2);
        dbContext.SaveChanges();
        // Act
        List<Purchase> result = purchaseManagement.GetPurchasesByUser(userId).ToList();

        // Assert
        CollectionAssert.AreEquivalent(expectedList, result);
    }

}