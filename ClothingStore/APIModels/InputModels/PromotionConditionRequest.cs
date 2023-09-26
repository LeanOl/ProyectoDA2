using Domain;

namespace APIModels.InputModels;

public class PromotionConditionRequest
{
    public int Count { get; set; }
    public string Match { get; set; }

    public PromotionCondition? ToEntity()
    {
        switch (Match)
        {
            case ConditionMatchType.Same:
                return new ConditionSame()
                {
                    Count = Count
                };
            case ConditionMatchType.Any:
                return new ConditionAny()
                {
                    Count = Count
                };
            default:
                return null;
        }
    }
}