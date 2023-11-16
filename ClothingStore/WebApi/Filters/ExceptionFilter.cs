using Exceptions.ApiModelExceptions;
using Exceptions.LogicExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter  
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case InvalidTypeException:
                    context.Result = new ObjectResult(new { Message = context.Exception.Message }) { StatusCode = 400 };
                    break;
                default:
                    context.Result = new ObjectResult(new { Message = $"Internal Server Error: {context.Exception.Message}" }) { StatusCode = 500 };
                    break;
            }
        }
    }
}