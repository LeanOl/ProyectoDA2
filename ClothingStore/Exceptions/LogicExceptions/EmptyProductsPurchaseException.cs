namespace Exceptions.LogicExceptions;

public class EmptyProductsPurchaseException : Exception
{
    public EmptyProductsPurchaseException(string message, Exception exception) : base(message, exception)
    {
    }

    public EmptyProductsPurchaseException(string message) : base(message)
    {
    }
}