using QingYuan.Mvc;
using QingYuan.Mvc.Enums;

namespace QingYuan.Gateway.Middlewares
{
    public class HttpNotFoundMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public Task Invoke(HttpContext context)
        {
            var endPoint = context.GetEndpoint();
            if (endPoint != null)
            {
                return _next(context);
            }
            context.Response.StatusCode = 404;
            return context.Response.WriteAsJsonAsync(ApiResponseResult.Fail(EnumApiResponseResultCode.NotFound, "未找到服务"));
        }

    }
}
