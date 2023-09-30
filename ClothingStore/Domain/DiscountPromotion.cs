namespace Domain;

public class DiscountPromotion : Promotion
{
    public double DiscountPercentage { get; set; }

    public override decimal GetDiscount(ShoppingCart cart)
    {
        bool isConditionApplicable = true;
        decimal discount = 0;
        foreach (var condition in PromotionConditions)
        {
            isConditionApplicable= isConditionApplicable && condition.VerifyCartCondition(cart);
        }

        if (isConditionApplicable)
        {
            Product? mostExpensiveProduct = FindMostExpensiveProduct(cart);
            discount = ApplyDiscount(mostExpensiveProduct);
        }
        return discount;
    }

    private Product? FindMostExpensiveProduct(ShoppingCart cart)
    {
        return cart.ProductList.MaxBy(x => x.Price);
    }

    private decimal ApplyDiscount(Product? mostExpensiveProduct)
    {
        if (mostExpensiveProduct == null)
            return 0;
        return mostExpensiveProduct.Price * (decimal)DiscountPercentage / 100;
    }
}