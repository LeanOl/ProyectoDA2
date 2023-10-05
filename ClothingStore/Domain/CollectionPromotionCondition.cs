using Exceptions.LogicExceptions;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Dynamic.Core;


namespace Domain
{
    public class CollectionPromotionCondition : PromotionCondition
{
    public override void SelfValidate()
    {
        try
        {
            TryToParse();
        }
        catch (ParseException e)
        {
            throw new InvalidConditionArgumentException(LogicExceptionMessages.InvalidCondition, e);
        }
    }

    private void TryToParse()
    {
        var product = new Product()
        {
            Brand = "a",
            Category = "a",
            Colors = new List<ProductColor>
            {
                new ProductColor
                {
                    Color = "a"
                }
            },
            Description = "a",
            Name = "a",
            Price = 1
        };

        var products = new List<Product>
        {
            product
        };
        products.AsQueryable().SelectMany(ProductPropertyCondition).GroupBy("it").Any(QuantityCondition);

    }

    public override bool VerifyCartCondition(ShoppingCart cart)
    {
        var products = cart.GetProducts().AsQueryable();
        var groupedProducts = products.Select(ProductPropertyCondition).GroupBy("it");
        return groupedProducts.Any(QuantityCondition);
    }
}
}