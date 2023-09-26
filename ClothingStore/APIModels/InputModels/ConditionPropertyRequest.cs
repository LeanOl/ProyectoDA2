using Domain;

namespace APIModels.InputModels;

public class ConditionPropertyRequest
{
    public int Count { get; set; }
    public string Match { get; set; }

    public ConditionProperty ToEntity()
    {
        return new ConditionProperty
        {
            Count = Count,
            Match = Match
        };
    }
}