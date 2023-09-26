
using Exceptions.LogicExceptions;

namespace Domain;

public class PromotionCondition
{
    public int Count { get; set; }

    public void SelfValidate()
    {
        if (Count <= 0)
            throw new InvalidConditionArgument(LogicExceptionMessages.InvalidConditionProductCount);
        
    }
}