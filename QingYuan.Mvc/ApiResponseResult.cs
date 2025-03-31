using QingYuan.Mvc.Enums;

namespace QingYuan.Mvc
{
    public partial class ApiResponseResult
    {
        public EnumApiResponseResultCode Code { get; set; }

        public string? Message { get; set; }

        public virtual object? GetData()
        {
            return null;
        }

    }

    public class ApiResponseResult<T> : ApiResponseResult
    {
        public T? Data { get; set; }

        public override object? GetData() => Data;
    }

}
