using QingYuan.Mvc;
using QingYuan.Mvc.Enums;

namespace QingYuan.Gateway.Middlewares
{
    public class HttpNotFoundMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {

        public Task Invoke(HttpContext context)
        {
            var endPoint = context.GetEndpoint();
            if (endPoint != null)
            {
                return next(context);
            }
            else if (env.IsDevelopment())
            {
                context.Response.Redirect("/openapi/v1.json");
                return Task.CompletedTask;
            }
            context.Response.StatusCode = 404;
            return context.Response.WriteAsJsonAsync(ApiResponseResult.Fail(EnumApiResponseResultCode.NotFound, "未找到服务"));
        }
    }
}
