using Domain;

namespace APIModels.InputModels;

public class PromotionRequest
{
    public string Name { get; set; }
    public string PromotionType { get; set; }
    public PromotionProductConditionsRequest Condition { get; set; }
    public int FreeProductCount { get; set; }
    public double DiscountPercentage { get; set; }

    public Promotion ToEntity()
    {
        switch (PromotionType)
        {
            case "FreeProducts":
                return ToFreeProductPromotion();
            case "Discount":
                return ToDiscountPromotion();
            default:
                throw new ArgumentException("Invalid promotion type");
        }
    }

    private Promotion ToFreeProductPromotion()
    {
        return new FreeProductPromotion
        {
            Name = Name,
            ProductCondition = Condition.ToEntity(),
            FreeProductCount = FreeProductCount
        };
    }

    public Promotion ToDiscountPromotion()
    {
        return new DiscountPromotion
        {
            Name = Name,
            ProductCondition = Condition.ToEntity(),
            DiscountPercentage = DiscountPercentage
        };
    }
}