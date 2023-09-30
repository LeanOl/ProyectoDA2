using System.Collections;

namespace Domain;

public class FreeProductPromotion : Promotion
{
    public int FreeProductCount { get; set; }

    public decimal ApplyPromotion(ShoppingCart cart)
    {
        bool isConditionApplicable = true;
        decimal discount = 0;
        foreach (var condition in PromotionConditions)
        {
            isConditionApplicable= isConditionApplicable && condition.VerifyCartCondition(cart);

        }

        if (isConditionApplicable)
        {
            IEnumerable<Product> products = cart.ProductList;
            var lessValueableProducts = products
                .OrderBy(x => x.Price)
                .Take(FreeProductCount);
            foreach (var product in lessValueableProducts)
            {
                discount+= product.Price;
            }
        }

        return discount;
    }
}