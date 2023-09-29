﻿using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Exceptions.LogicExceptions;

namespace Domain;

public class SingularPromotionCondition : PromotionCondition
{
    public override void SelfValidate()
    {
        try
        {
            TryToParse();

        }
        catch (ParseException e)
        {
            throw new InvalidConditionArgumentException(LogicExceptionMessages.InvalidCondition, e);
        }
    }

    private void TryToParse()
    {
        var product = new Product()
        {
            Brand = "a",
            Category = "a",
            Colors = new List<string> { "a" },
            Description = "a",
            Name = "a",
            Price = 1
        };

        var products = new List<Product>
        {
            product
        };


        products.AsQueryable().GroupBy(ProductPropertyCondition).Any(QuantityCondition);
    }
}