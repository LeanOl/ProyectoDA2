using System.Linq.Dynamic.Core.Exceptions;
using Exceptions.LogicExceptions;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public abstract class Promotion
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PromotionCondition> PromotionConditions;
        public abstract decimal GetDiscount(ShoppingCart cart);

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
           
                var products = new List<Product>
                {
                    product
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
}