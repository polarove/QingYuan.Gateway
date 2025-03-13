namespace QingYuan.Model.Base
{
    public class BaseSoftDelete : BaseTable, ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
