using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QingYuan.Gateway.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class GlobalExceptionFiltersAttribute : Attribute, IOrderedFilter, IAsyncExceptionFilter, IFilterMetadata
    {
        public int Order => -67;

        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result = new JsonResult(new
                {
                    Code = 1,
                    context.Exception.Message,
                    Type = context.Exception.GetType()
                })
                {
                    StatusCode = 500
                };
            }
            return Task.CompletedTask;
        }
    }
}
