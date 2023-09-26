using Domain;

namespace Logic.Interfaces;

public interface IPromotionLogic
{
    Promotion CreatePromotion(Promotion aPromotion);
    IEnumerable<Promotion> GetAllPromotions();
    void DeletePromotion(Guid id);
}