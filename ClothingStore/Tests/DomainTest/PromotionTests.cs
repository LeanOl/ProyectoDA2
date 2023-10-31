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
    }
}