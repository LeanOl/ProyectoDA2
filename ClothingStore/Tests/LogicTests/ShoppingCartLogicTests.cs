using Data.Interfaces;
using Domain;
using Logic.Concrete;
using Logic.Interfaces;

namespace Tests.LogicTests
{
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

            List<ShoppingCartProducts> cartProducts = new List<ShoppingCartProducts>();
            ShoppingCartProducts scp1 = new ShoppingCartProducts();
            scp1.Product = new Product()
            {
                Id = new Guid(),
                Brand = "Nike",
                Category = "Shirt",
                Price = 150
            };

            ShoppingCartProducts scp2 = new ShoppingCartProducts();
            scp2.Product = new Product()
            {
                Id = new Guid(),
                Brand = "Nike",
                Category = "Shoes",
                Price = 100
            };
            ShoppingCartProducts scp3 = new ShoppingCartProducts();
            scp3.Product = new Product()
            {
                Id = new Guid(),
                Brand = "Nike",
                Category = "Shoes",
                Price = 50
            };


            cartProducts.Add(scp1);
            cartProducts.Add(scp2);
            cartProducts.Add(scp3);
            // Arrange
            var shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartProducts = cartProducts;

            Mock<IGenericRepository<Promotion>> repo = new Mock<IGenericRepository<Promotion>>(MockBehavior.Strict);
            repo.Setup(x => x.GetAll<Promotion>()).Returns(promotions);
            IShoppingCartLogic shoppingCartLogic = new ShoppingCartLogic(repo.Object);

            // Act
            shoppingCartLogic.ApplyBestPromotion(shoppingCart);

            // Assert
            Assert.AreEqual(testPromotion2, shoppingCart.AppliedPromotion);
        }
    }
}