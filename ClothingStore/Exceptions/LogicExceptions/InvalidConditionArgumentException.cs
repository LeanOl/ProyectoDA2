namespace Exceptions.LogicExceptions;

public class InvalidConditionArgumentException: Exception
{
    public InvalidConditionArgumentException(string message, Exception exception) : base(message, exception)
    {
    }
}