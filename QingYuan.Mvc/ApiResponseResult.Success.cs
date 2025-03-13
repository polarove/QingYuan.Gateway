using QingYuan.Mvc.Enums;

namespace QingYuan.Mvc
{
    public partial class ApiResponseResult
    {

        public static ApiResponseResult Success() => new()
        {
            Code = EnumApiResponseResultCode.Success
        };

        public static ApiResponseResult<T> Success<T>(T value) => new()
        {
            Code = EnumApiResponseResultCode.Success,
            Data = value
        };

        public static ApiResponseResult<T> Success<T>(T value, string? message) => new()
        {
            Code = EnumApiResponseResultCode.Success,
            Data = value,
            Message = message
        };
    }
}
