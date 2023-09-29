using Domain;
using Exceptions.ApiModelExceptions;

namespace APIModels.InputModels;

public class PromotionRequest
{
    public string Name { get; set; }
    public string PromotionType { get; set; }
    public List<PromotionConditionRequest> Conditions { get; set; }
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
                throw new InvalidTypeException("Invalid promotion type");
        }
    }

    private Promotion ToFreeProductPromotion()
    {
        return new FreeProductPromotion
        {
            Name = Name,
            Conditions = Conditions.Select(c => c.ToEntity()),
            FreeProductCount = FreeProductCount
        };
    }

    public Promotion ToDiscountPromotion()
    {
        return new DiscountPromotion
        {
            Name = Name,
            Conditions = Conditions.Select(c => c.ToEntity()),
            DiscountPercentage = DiscountPercentage
        };
    }
}