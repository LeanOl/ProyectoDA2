﻿namespace Exceptions.LogicExceptions;

public class InvalidConditionArgument: Exception
{
    public InvalidConditionArgument(string message, Exception exception) : base(message, exception)
    {
    }
}