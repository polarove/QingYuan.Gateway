using QingYuan.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingYuan.Common.Exceptions
{
    public class ServiceResponseException : Exception
    {
        public ServiceResponseException(EnumApiResponseResultCode code) : this(code, null)
        {
        }

        public ServiceResponseException(string message) : this(EnumApiResponseResultCode.Fail, message)
        {
        }

        public ServiceResponseException(EnumApiResponseResultCode code, string? message) : base(message)
        {
            Result = new ApiResponseResult
            {
                Code = code,
                Message = message
            };
        }

        public ApiResponseResult Result { get; }


        public static ServiceResponseException Forbidden(string message = "禁止访问") => new(EnumApiResponseResultCode.Forbidden, message);

        public static ServiceResponseException UnAuthorized(string message = "无权访问") => new(EnumApiResponseResultCode.Unauthorized, message);

        public static ServiceResponseException NotFound(string message = "未找到资源") => new(EnumApiResponseResultCode.NotFound, message);

        public static ServiceResponseException BadRequest(string message = "请求错误") => new(EnumApiResponseResultCode.BadRequest, message);

        public static ServiceResponseException InternalServerError(string message = "服务错误") => new(EnumApiResponseResultCode.InternalServerError, message);

        public static ServiceResponseException Fail(string message = "请求失败") => new(EnumApiResponseResultCode.Fail, message);
    }
}