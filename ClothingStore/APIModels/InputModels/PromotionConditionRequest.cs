using Domain;
using Exceptions.ApiModelExceptions;

namespace APIModels.InputModels;

public class PromotionConditionRequest
{
    public string ProductPropertyCondition { get; set; }
    public string QuantityCondition { get; set; }
    public string ConditionType { get; set; }

    public PromotionCondition ToEntity()
    {
        switch (ConditionType)
        {
            case "Singular":
                return ToSingularPromotionCondition();
            case "Collection":
                return ToCollectionPromotionCondition();
            default:
                throw new InvalidTypeException("Invalid condition type");
        }
   }

    private PromotionCondition ToCollectionPromotionCondition()
    {
        return new CollectionPromotionCondition
        {
            ProductPropertyCondition = ProductPropertyCondition,
            QuantityCondition = QuantityCondition
        };
    }

    private PromotionCondition ToSingularPromotionCondition()
    {
        return new SingularPromotionCondition
        {
            ProductPropertyCondition = ProductPropertyCondition,
            QuantityCondition = QuantityCondition
        };
    }
}