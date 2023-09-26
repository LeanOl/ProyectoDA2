using Data.Interfaces;
using Domain;
using Logic.Interfaces;

namespace Logic.Concrete;

public class PromotionLogic : IPromotionLogic
{
    private readonly IGenericRepository<Promotion> _repository;
    public PromotionLogic(IGenericRepository<Promotion> repository)
    {
        _repository = repository;
    }

    public Promotion CreatePromotion(Promotion aPromotion)
    {
        aPromotion.SelfValidate();
        return _repository.Insert(aPromotion);
    }

    public IEnumerable<Promotion> GetAllPromotions()
    {
        throw new NotImplementedException();
    }

    public void DeletePromotion(Guid id)
    {
        throw new NotImplementedException();
    }

    public Promotion UpdatePromotion(Guid id, Promotion isAny)
    {
        throw new NotImplementedException();
    }
}