namespace QingYuan.Model.Base
{
    public class BaseSoftDelete : BaseTable, ISoftDelete
    {
        public byte IsDeleted { get; set; }
    }
}
