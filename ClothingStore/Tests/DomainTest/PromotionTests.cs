using Domain;
using IPromotionProject;
using Promotions;

namespace Tests.DomainTest
{
    [TestClass]
    public class PromotionTests
    {
        [TestMethod]
        public void ThreeProductsOneFree_ApplyDiscountOk()
        {
            // Arrange
            ThreeProductsOneFree promotion = new ThreeProductsOneFree();
            List<ProductDto> products = new List<ProductDto>
            {
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 10
                },
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 20
                },
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 30
                }
            };
            decimal expectedDiscount = 10;

            // Act
            decimal result = promotion.GetDiscount(products);

            // Assert
            Assert.AreEqual(expectedDiscount, result);


        }

        [TestMethod]
        public void TotalLook_ApplyDiscountOk()
        {
            // Arrange
            TotalLook promotion = new TotalLook();
            List<ProductDto> products = new List<ProductDto>
            {
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 10,
                    Colors = new List<string> { "Red", "Blue" }
                },
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 20,
                    Colors = new List<string> { "Red", "Blue" }
                },
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 30,
                    Colors = new List<string> { "Green", "Red" }
                },
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 40,
                    Colors = new List<string> { "Green", "Orange" }
                },
            };
            decimal expectedDiscount = 15;

            // Act
            decimal result = promotion.GetDiscount(products);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }


        [TestMethod]
        public void TwentyPercentOff_ApplyDiscountOk()
        {
            // Arrange
            TwentyPercentOff promotion = new TwentyPercentOff();
            List<ProductDto> products = new List<ProductDto>
            {
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 10
                },
                new ProductDto()
                {
                    Category = "Test Category 1",
                    Price = 20
                },
            };
            decimal expectedDiscount = 4;

            // Act
            decimal result = promotion.GetDiscount(products);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }

        [TestMethod]
        public void ThreeProductFidelity_ApplyDiscountOk()
        {
            // Arrange
            ThreeProductFidelity promotion = new ThreeProductFidelity();
            List<ProductDto> products = new List<ProductDto>
            {
                new ProductDto()
                {
                    Brand = "Brand 1",
                    Price = 10
                },
                new ProductDto()
                {
                    Brand = "Brand 1",
                    Price = 20
                },
                new ProductDto()
                {
                    Brand = "Brand 1",
                    Price = 30
                }
            };
            decimal expectedDiscount = 30;

            // Act
            decimal result = promotion.GetDiscount(products);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }
    }
    
    
}