using Domain;

namespace APIModels.InputModels;

public class PromotionConditionRequest
{
    public string ProductPropertyCondition { get; set; }
    public string QuantityCondition { get; set; }

    public PromotionCondition ToEntity()
    {
       return new PromotionCondition
       {
           ProductPropertyCondition = ProductPropertyCondition,
           CountCondition = QuantityCondition
       };
   }
}