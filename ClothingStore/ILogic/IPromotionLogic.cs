using System.Reflection;
using IPromotionProject;

namespace ILogic;

public interface IPromotionLogic
{
    public IEnumerable<IPromotion> GetPromotions();


}