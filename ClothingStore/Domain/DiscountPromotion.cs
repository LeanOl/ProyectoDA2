namespace Domain;

public class DiscountPromotion : Promotion
{
    public double DiscountPercentage { get; set; }

    public decimal GetDiscount(ShoppingCart cart)
    {
        bool isConditionApplicable = true;
        decimal discount = 0;
        foreach (var condition in PromotionConditions)
        {
            isConditionApplicable= isConditionApplicable && condition.VerifyCartCondition(cart);
        }

        if (isConditionApplicable)
        {
            Product mostExpensiveProduct = cart.ProductList
                .OrderByDescending(x => x.Price)
                .FirstOrDefault();
            discount = mostExpensiveProduct.Price * (decimal)DiscountPercentage / 100;
        }
        return discount;
    }
}