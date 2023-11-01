using IPromotionProject;

namespace Promotions;

public class TotalLook : IPromotion
{
    public string Name { get; set; } = "TotalLook";
    public decimal GetDiscount(IEnumerable<ProductDto> products)
    {
        decimal discount = 0;
        List<ProductDto> productList= products.ToList();
        var flattenedColors = productList.SelectMany(p => p.Colors);
        var groupedColors = flattenedColors.GroupBy(c => c);

        discount = FindDiscount(groupedColors, productList, discount);

        return discount;

    }

    private decimal FindDiscount(IEnumerable<IGrouping<string, string>> groupedColors, List<ProductDto> productList, decimal discount)
    {
        foreach (var colorGroup in groupedColors)
        {
            if (colorGroup.Count() == 3)
            {
                var productsWithColor = productList.Where(p => p.Colors.Contains(colorGroup.Key));
                var mostExpensiveProduct = productsWithColor.OrderByDescending(p => p.Price).First();
                discount = mostExpensiveProduct.Price / 2;
                break;
            }
        }

        return discount;
    }
}