using Domain;

namespace APIModels.InputModels;

public class PromotionConditionRequest
{
    public string ProductPropertyCondition { get; set; }
    public string QuantityCondition { get; set; }
    public string PromotionType { get; set; }

    public PromotionCondition ToEntity()
    {
        switch (PromotionType)
        {
            case "Singular":
                return ToSingularPromotionCondition();
            case "Collection":
                return ToCollectionPromotionCondition();
            default:
                throw new ArgumentException("Invalid promotion type");
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