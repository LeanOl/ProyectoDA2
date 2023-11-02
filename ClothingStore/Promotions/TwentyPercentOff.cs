using IPromotionProject;

namespace Promotions;

public class TwentyPercentOff {
    public string Name { get; set; } = "20% OFF";

    public decimal GetDiscount(IEnumerable<ProductDto> products)
    {
        decimal discount = FindDiscount(products);
        return discount;
    }

    private decimal FindDiscount(IEnumerable<ProductDto> products)
    {
        List<ProductDto> productList = products.ToList();
        decimal discount = 0;
        if (productList.Count() >= 2)
        {
            ProductDto mostExpensiveProductPrice = productList.OrderByDescending(p => p.Price).First();
            discount = mostExpensiveProductPrice.Price * 0.2m;
        }
        return discount;
    }
}