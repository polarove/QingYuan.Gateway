using QingYuan.Model.Base;

namespace QingYuan.Model.Tables
{
    public class User : BaseSoftDelete
    {
        public string? Name { get; set; }

        public string? Content { get; set; }
    }
}
