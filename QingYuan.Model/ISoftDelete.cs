namespace QingYuan.Model
{
    public interface ISoftDelete
    {
        public long Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
