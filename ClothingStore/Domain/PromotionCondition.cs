﻿
using Exceptions.LogicExceptions;

namespace Domain;

public class PromotionCondition
{
    public Guid Id { get; set; }
    public int Count { get; set; }

    public void SelfValidate()
    {
        if (Count <= 0)
            throw new InvalidConditionArgument(LogicExceptionMessages.InvalidConditionProductCount);
        
    }
}