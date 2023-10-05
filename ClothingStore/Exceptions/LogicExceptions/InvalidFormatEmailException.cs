namespace Exceptions.LogicExceptions
{
    public class InvalidFormatEmailException : Exception
    {
        public InvalidFormatEmailException(string message, Exception exception) : base(message, exception)
        {
        }
        public InvalidFormatEmailException(string message) : base(message)
        {
        }
    }
}
