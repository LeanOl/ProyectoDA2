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
        return _repository.GetAll<Promotion>();
    }

    public void DeletePromotion(Guid id)
    {
        Promotion promotion = _repository.Get(x => x.Id == id);
        _repository.Delete(promotion);
    }

    public Promotion UpdatePromotion(Guid id, Promotion isAny)
    {
        throw new NotImplementedException();
    }
}