﻿using Domain;

namespace APIModels.InputModels;

public class PromotionRequest
{
    public string Name { get; set; }
    public string PromotionType { get; set; }
    public PromotionConditionRequest Condition { get; set; }
    public int FreeProductCount { get; set; }
    public double DiscountPercentage { get; set; }

    public Promotion ToEntity()
    {
        return new FreeProductPromotion
        {
            Name = Name,
            Condition = Condition.ToEntity(),
            FreeProductCount = FreeProductCount
        };
    }
}