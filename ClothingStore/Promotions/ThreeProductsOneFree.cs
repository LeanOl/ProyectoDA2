using Domain;
using IPromotionProject;

namespace Promotions
{
    public class ThreeProductsOneFree : IPromotion
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal GetDiscount(IEnumerable<ProductDto> products )
        {
            decimal discount = 0;
            var productsByCategory = products.GroupBy(p => p.Category);

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