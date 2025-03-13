namespace QingYuan.Model
{
    public interface ISoftDelete
    {
        public long Id { get; set; }

        public byte IsDeleted { get; set; }
    }
}
