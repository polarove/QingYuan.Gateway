namespace QingYuan.Model.Tables
{
    public class Sheet
    {
        public DateOnly Date { get; set; }

        public List<List<Member>>? Members { get; set; }
    }
}
