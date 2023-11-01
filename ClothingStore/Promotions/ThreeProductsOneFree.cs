using Domain;
using IPromotionProject;

namespace Promotions
{
    public class ThreeProductsOneFree : IPromotion
    {
        public string Name { get; set; } = "3x1";
        public decimal GetDiscount(IEnumerable<ProductDto> products )
        {
            decimal discount = 0;
            var productsByCategory = products.GroupBy(p => p.Category);

            discount = FindDiscount(productsByCategory, discount);
            return discount;
        }

        private decimal FindDiscount(IEnumerable<IGrouping<string, ProductDto>> productsByCategory, decimal discount)
        {
            foreach (var categoryGroup in productsByCategory)
            {
                if (categoryGroup.Count() == 3)
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