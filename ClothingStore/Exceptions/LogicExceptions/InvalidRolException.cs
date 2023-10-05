namespace Exceptions.LogicExceptions
{
    public class InvalidRolException : Exception
    {
        public InvalidRolException(string message, Exception exception) : base(message, exception)
        {
        }
        public InvalidRolException(string message) : base(message)
        {
        }
    }
}
