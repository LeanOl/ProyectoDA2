using IPromotionProject;

namespace Promotions;

public class ThreeProductFidelity : IPromotion
{
    public string Name { get; set; } = "3x1 Fidelity";

    public decimal GetDiscount(IEnumerable<ProductDto> products)
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
                IEnumerable<ProductDto> cheapestTwoProducts = categoryGroup.OrderBy(p => p.Price).Take(2);
                discount = cheapestTwoProducts.Sum(p => p.Price);
            }
        }

        return discount;
    }
}