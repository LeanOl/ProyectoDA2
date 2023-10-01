namespace Exceptions.ApiModelExceptions
{
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException(string message) : base(message)
        {
        }
    }
}