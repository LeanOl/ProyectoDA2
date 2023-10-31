using IPromotionProject;

namespace Utilities;

public interface IPromotionHelper
{
    public IEnumerable<IPromotion> GetPromotions();
}