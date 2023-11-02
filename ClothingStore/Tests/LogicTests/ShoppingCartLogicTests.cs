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
            scp1.Quantity = 1;
            scp2.Quantity = 1;
            scp3.Quantity = 1;


            cartProducts.Add(scp1);
            cartProducts.Add(scp2);
            cartProducts.Add(scp3);
     
            var shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartProducts = cartProducts;

            Mock<IPromotionLogic> promotionLogic = new Mock<IPromotionLogic>(MockBehavior.Strict);
            promotionLogic.Setup(h => h.GetPromotions()).Returns(promotions);
            Mock<IShoppingCartManagement> shoppingCartRepository = new Mock<IShoppingCartManagement>(MockBehavior.Strict);
            IShoppingCartLogic shoppingCartLogic = new ShoppingCartLogic(promotionLogic.Object,shoppingCartRepository.Object);

            // Act
            shoppingCartLogic.ApplyBestPromotion(shoppingCart);

            // Assert
            Assert.AreEqual(testPromotion1.Name, shoppingCart.PromotionName);
            Assert.AreEqual(50, shoppingCart.Discount);
        }

        [TestMethod]
        public void UpdateShoppingCart_Ok()
        {
            // Arrange
            ShoppingCart expectedShoppingCart = new ShoppingCart()
            {
                ShoppingCartProducts = new List<ShoppingCartProducts>(),
            };
            Mock<IShoppingCartManagement> shoppingCartRepository = new Mock<IShoppingCartManagement>(MockBehavior.Strict);
            shoppingCartRepository.Setup(m => m.UpdateShoppingCart(It.IsAny<ShoppingCart>())).Returns(expectedShoppingCart);
            Mock<IPromotionLogic> promotionLogic = new Mock<IPromotionLogic>(MockBehavior.Strict);
            promotionLogic.Setup(h => h.GetPromotions()).Returns(new List<IPromotion>());
            IShoppingCartLogic shoppingCartLogic = new ShoppingCartLogic(promotionLogic.Object ,shoppingCartRepository.Object);

            // Act
            ShoppingCart result = shoppingCartLogic.UpdateShoppingCart(expectedShoppingCart);

            // Assert
            Assert.AreEqual(expectedShoppingCart, result);
        }
    }

    
}