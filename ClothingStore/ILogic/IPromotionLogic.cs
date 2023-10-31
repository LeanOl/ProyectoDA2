using Domain;

namespace ILogic
{

    public interface IPromotionLogic
    {
        Promotion CreatePromotion(Promotion aPromotion);
        IEnumerable<Promotion> GetAllPromotions();
        void DeletePromotion(Guid id);
        Promotion UpdatePromotion(Guid id, Promotion isAny);
    }
}