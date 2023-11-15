using IPromotionProject;

namespace Promotions;

public class ThreeProductFidelity : IPromotion
{
    public string Name { get; set; } = "3x1 Fidelity";

    public decimal GetDiscount(IEnumerable<ProductDto> products)
    {
        
        var productsByBrand = products.GroupBy(p => p.Brand);

        decimal discount = FindDiscount(productsByBrand);
        return discount;
    }

    private decimal FindDiscount(IEnumerable<IGrouping<string, ProductDto>> productsByBrand)
    {
        decimal discount = 0;
        foreach (var categoryGroup in productsByBrand)
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