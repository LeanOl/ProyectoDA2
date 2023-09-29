using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Exceptions.LogicExceptions;

namespace Domain;
public abstract class Promotion
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<PromotionCondition> PromotionConditions;

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
            var product2 = new Product()
            {
                Brand = "b",
                Category = "b",
                Colors = new List<string> { "a" },
                Description = "b",
                Name = "b",
                Price = 2
            };
            var product3 = new Product()
            {
                Brand = "c",
                Category = "c",
                Colors = new List<string> { "b","a" },
                Description = "c",
                Name = "c",
                Price = 3
            };
            var products = new List<Product>
            {
                product, product2, product3
            };
            
            foreach (var condition in PromotionConditions)
            {
                condition.SelfValidate();
                
            }
            
        }
        catch (ParseException e)
        {
            throw new InvalidConditionArgumentException(LogicExceptionMessages.InvalidCondition, e);
        }
    }
}