using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QingYuan.Model.Base
{
    public class BaseTable : ITable, IEntity, ICreateTime, IUpdateTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("create_time")]
        public DateTimeOffset CreateTime { get; set; }

        [Column("update_time")]
        public DateTimeOffset? UpdateTime { get; set; }
    }
}
