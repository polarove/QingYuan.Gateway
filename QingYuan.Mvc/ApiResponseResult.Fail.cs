using QingYuan.Mvc.Enums;

namespace QingYuan.Mvc
{
    public partial class ApiResponseResult
    {

        public const string DefaultNotFoundMessage = "数据不存在";

        public const string DefaultForbiddenMessage = "禁止访问";

        public static ApiResponseResult Fail(EnumApiResponseResultCode code, string? message) => new()
        {
            Code = code,
            Message = message
        };

        public static ApiResponseResult Fail(string? alert) => Fail(EnumApiResponseResultCode.Fail, alert);
        public static ApiResponseResult Fail(EnumApiResponseResultCode code) => Fail(code, null);
        public static ApiResponseResult Fail() => Fail(null);

        public static ApiResponseResult NotFound(string alert = DefaultForbiddenMessage) => Fail(EnumApiResponseResultCode.NotFound, alert);
        public static ApiResponseResult Forbidden(string alert = DefaultForbiddenMessage) => Fail(EnumApiResponseResultCode.Forbidden, alert);
    }

}
