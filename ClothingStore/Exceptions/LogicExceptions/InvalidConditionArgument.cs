namespace Exceptions.LogicExceptions;

public class InvalidConditionArgument: Exception
{
    public InvalidConditionArgument(string message) : base(message)
    {
    }
}