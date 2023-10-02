using Data.Interfaces;
using Domain;
using Logic.Concrete;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Tests.LogicTests;
[TestClass]
public class ShoppingCartLogicTests
{
    [TestMethod]
    public void ApplyBestPromotionOk()
    {
        // Arrange
        Promotion testPromotion1 = new DiscountPromotion
        {
            Id = new Guid(),
            PromotionConditions = new List<PromotionCondition>
            {
                new SingularPromotionCondition()
                {
                    Id = new Guid(),
                    ProductPropertyCondition = "Brand",
                    QuantityCondition = "Count() >= 3"
                }
            },
            DiscountPercentage = 20
        };
        Promotion testPromotion2 = new FreeProductPromotion()
        {
            Id = new Guid(),
            PromotionConditions = new List<PromotionCondition>
            {
                new SingularPromotionCondition()
                {
                    Id = new Guid(),
                    ProductPropertyCondition = "Brand",
                    QuantityCondition = "Count() >= 2"
                }
            },
            FreeProductCount = 1
        };
        List<Promotion> promotions = new List<Promotion>()
        {
            testPromotion1,
            testPromotion2
        };
        List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = new Guid(),
                Brand = "Nike",
                Category = "Shirt",
                Price = 150
            },
            new Product()
            {
                Id = new Guid(),
                Brand = "Nike",
                Category = "Shoes",
                Price = 100
            },
            new Product()
            {
                Id = new Guid(),
                Brand = "Nike",
                Category = "Shoes",
                Price = 50
            }
        };
        ShoppingCart shoppingCart = new ShoppingCart
        {
            ProductList = products
        };
        Mock<IGenericRepository<Promotion>> repo = new Mock<IGenericRepository<Promotion>>(MockBehavior.Strict);
        repo.Setup(x => x.GetAll<Promotion>()).Returns(promotions);
        IShoppingCartLogic shoppingCartLogic = new ShoppingCartLogic(repo.Object);

        // Act
        shoppingCartLogic.ApplyBestPromotion(shoppingCart);

        // Assert
        Assert.AreEqual(testPromotion2, shoppingCart.AppliedPromotion);
    }
}