using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QingYuan.Model.Base
{
    public class BaseTable : ITable, IEntity, ICreateTime, IUpdateTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset? UpdateTime { get; set; }
    }
}
