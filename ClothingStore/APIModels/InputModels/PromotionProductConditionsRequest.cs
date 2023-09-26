using Domain;

namespace APIModels.InputModels;

public class PromotionProductConditionsRequest
{
    public PromotionConditionRequest? Category { get; set; }
    public PromotionConditionRequest? Brand { get; set; }
    public PromotionConditionRequest? Color { get; set; }

    public PromotionProductCondition ToEntity()
    {
        return new PromotionProductCondition
        {
            Category = Category?.ToEntity(),
            Brand = Brand?.ToEntity(),
            Color = Color?.ToEntity()
        };
    }
}