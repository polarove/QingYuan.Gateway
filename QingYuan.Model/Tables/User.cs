using QingYuan.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace QingYuan.Model.Tables
{
    [Table("user")]
    public class User : BaseTable
    {
        public string? Name { get; set; }
    }
}
