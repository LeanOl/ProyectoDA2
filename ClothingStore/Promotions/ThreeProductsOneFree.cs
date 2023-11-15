using Domain;
using IPromotionProject;

namespace Promotions
{
    public class ThreeProductsOneFree : IPromotion
    {
        public string Name { get; set; } = "3x2";
        public decimal GetDiscount(IEnumerable<ProductDto> products )
        {
            var productsByCategory = products.GroupBy(p => p.Category);

            decimal discount = FindDiscount(productsByCategory);
            return discount;
        }

        private decimal FindDiscount(IEnumerable<IGrouping<string, ProductDto>> productsByCategory)
        {
            decimal discount = 0;
            foreach (var categoryGroup in productsByCategory)
            {
                if (categoryGroup.Count() >= 3)
                {
                    var cheapestProduct = categoryGroup.OrderBy(p => p.Price).First();
                    discount = cheapestProduct.Price;
                    break;
                }
            }

            return discount;
        }
    }
}