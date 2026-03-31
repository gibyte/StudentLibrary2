using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentLibrary2
{
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new ObjectResult("Внутренняя ошибка сервера")
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }

        }
    }
}
