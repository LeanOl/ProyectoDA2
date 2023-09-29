using Domain;

namespace APIModels.OutputModels;

public class PromotionResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PromotionType { get; set; }

    public PromotionResponse(Promotion aPromotion)
    {
        Id = aPromotion.Id;
        Name = aPromotion.Name;
        PromotionType = aPromotion.GetType().Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is PromotionResponse other)
        {
            return Id == other.Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

   
}