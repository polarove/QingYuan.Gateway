namespace QingYuan.Model.Base
{
    public class BaseTable : ITable, IEntity, ICreateTime, IUpdateTime
    {
        public long Id { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset? UpdateTime { get; set; }
    }
}
