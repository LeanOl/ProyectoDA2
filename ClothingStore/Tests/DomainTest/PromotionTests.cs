using Domain;

namespace Tests.DomainTest
{
    [TestClass]
    public class PromotionTests
    {
        [TestMethod]
        public void GetDiscountFreeProductPromotionOk()
        {
            List<ShoppingCartProducts> cartProducts = new List<ShoppingCartProducts>();
            ShoppingCartProducts scp1 = new ShoppingCartProducts();
            scp1.Product = new Product
            {
                Name = "Product 1",
                Price = 10,
                Category = "Category 1",

                Colors = new List<ProductColor>
                {
                    new ProductColor { Color = "Red" },
                    new ProductColor { Color = "Blue" }
                },
               Stock = 100,
            };

            ShoppingCartProducts scp2 = new ShoppingCartProducts();
            scp2.Product = new Product
            {
                Name = "Product 2",
                Price = 20,
                Category = "Category 1",
                Colors = new List<ProductColor>
                {
                    new ProductColor { Color = "Red" },
                    new ProductColor { Color = "Blue" }
                }
            };
            ShoppingCartProducts scp3 = new ShoppingCartProducts();
            scp3.Product = new Product
            {
                Name = "Product 3",
                Price = 30,
                Category = "Category 2",
                Colors = new List<ProductColor>
                {
                    new ProductColor { Color = "Blue" },
                    new ProductColor { Color = "Yellow" }
                }
            };


            cartProducts.Add(scp1);
            cartProducts.Add(scp2);
            cartProducts.Add(scp3);
            // Arrange
            var cart = new ShoppingCart();
            cart.ShoppingCartProducts = cartProducts;
        

        var promotion1 = new FreeProductPromotion
            {
                Name = "Test Promotion",
                PromotionConditions = new List<PromotionCondition>()
                {
                    new SingularPromotionCondition()
                    {
                        ProductPropertyCondition= "Category",
                        QuantityCondition = "Count() >= 2",
                    }
                },
                FreeProductCount = 1
            };

            // Act
            decimal discount=promotion1.GetDiscount(cart);

            // Assert
            Assert.AreEqual(10,discount);
        }

        [TestMethod]
        public void GetDiscountPercentagePromotionOk()
        {
            // Arrange
            List<ShoppingCartProducts> cartProducts = new List<ShoppingCartProducts>();
            ShoppingCartProducts scp1 = new ShoppingCartProducts();
            scp1.Product = new Product
            {
                Name = "Product 1",
                Price = 10,
                Category = "Category 1",
                Colors = new List<ProductColor>
                {
                    new ProductColor { Color = "Red" },
                    new ProductColor { Color = "Blue" }
                }
            };

            ShoppingCartProducts scp2 = new ShoppingCartProducts();
            scp2.Product = new Product
            {
                Name = "Product 2",
                Price = 20,
                Category = "Category 1",
                Colors = new List<ProductColor>
                {
                    new ProductColor { Color = "Red" },
                    new ProductColor { Color = "Blue" }
                }
            };
            ShoppingCartProducts scp3 = new ShoppingCartProducts();
            scp3.Product = new Product
            {
                Name = "Product 3",
                Price = 30,
                Category = "Category 2",
                Colors = new List<ProductColor>
                {
                    new ProductColor { Color = "Blue" },
                    new ProductColor { Color = "Yellow" }
                }
            };


            cartProducts.Add(scp1);
            cartProducts.Add(scp2);
            cartProducts.Add(scp3);
            // Arrange
            var cart = new ShoppingCart();
            cart.ShoppingCartProducts = cartProducts;
            var promotion1 = new DiscountPromotion()
            {
                Name = "Test Promotion",
                PromotionConditions = new List<PromotionCondition>()
                {
                    new SingularPromotionCondition()
                    {
                        ProductPropertyCondition= "Category",
                        QuantityCondition = "Count() >= 2",
                    }
                },
                DiscountPercentage = 50
            };
            // Act
            decimal discount=promotion1.GetDiscount(cart);
            // Assert
            Assert.AreEqual(15,discount);
        }
    }   
}