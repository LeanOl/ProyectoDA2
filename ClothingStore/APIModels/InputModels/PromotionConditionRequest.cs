using Domain;

namespace APIModels.InputModels;

public class PromotionConditionRequest
{
    public ConditionPropertyRequest? Category { get; set; }
    public ConditionPropertyRequest? Brand { get; set; }
    public ConditionPropertyRequest? Color { get; set; }

    public PromotionCondition ToEntity()
    {
        return new PromotionCondition
        {
            Category = Category?.ToEntity(),
            Brand = Brand?.ToEntity(),
            Color = Color?.ToEntity()
        };
    }
}