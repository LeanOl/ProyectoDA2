using Exceptions.LogicExceptions;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Dynamic.Core;


namespace Domain;

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
            throw new InvalidConditionArgument(LogicExceptionMessages.InvalidCondition, e);
        }
    }

    private void TryToParse()
    {
        var product = new Product()
        {
            Brand = "a",
            Category = "a",
            Colors = new List<string> { "a" },
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
}