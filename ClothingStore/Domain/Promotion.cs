using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Exceptions.LogicExceptions;

namespace Domain;
public class Promotion
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<PromotionCondition> Conditions;

    public void SelfValidate()
    {
        ValidateCondition();
    }

    private void ValidateCondition()
    {
        try
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
            var products = new List<Product> { product };
            foreach (var condition in Conditions)
            {
                products.AsQueryable().GroupBy(condition.ProductPropertyCondition).Any(condition.CountCondition);
            }
            
        }
        catch (ParseException e)
        {
            throw new InvalidConditionArgument(LogicExceptionMessages.InvalidCondition, e);
        }
    }
}