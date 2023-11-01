using IData;
using Domain;
using ILogic;
using IPromotionProject;
using Logic;
using Promotions;

namespace Tests.LogicTests
{
    [TestClass]
    public class ShoppingCartLogicTests
    {
        [TestMethod]
        public void ApplyPromotionOk()
        {
            // Arrange
            IPromotion testPromotion1 = new ThreeProductsOneFree()
            {
                Name = "Test Promotion 1"
            };
            
            List<IPromotion> promotions = new List<IPromotion>()
            {
                testPromotion1,
            };

            List<ShoppingCartProducts> cartProducts = new List<ShoppingCartProducts>();
            ShoppingCartProducts scp1 = new ShoppingCartProducts();
            scp1.Product = new Product()
            {
                Id = new Guid(),
                Brand = "Nike",
                Category = "Shoes",
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
     
            var shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartProducts = cartProducts;

            Mock<IPromotionLogic> helper = new Mock<IPromotionLogic>(MockBehavior.Strict);
            helper.Setup(h => h.GetPromotions()).Returns(promotions);
            IShoppingCartLogic shoppingCartLogic = new ShoppingCartLogic(helper.Object);

            // Act
            shoppingCartLogic.ApplyBestPromotion(shoppingCart);

            // Assert
            Assert.AreEqual(testPromotion1.Name, shoppingCart.PromotionName);
            Assert.AreEqual(50, shoppingCart.Discount);
        }
    }
}