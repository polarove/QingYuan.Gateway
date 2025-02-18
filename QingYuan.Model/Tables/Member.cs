namespace QingYuan.Model.Tables
{
    public class Member
    {
        public string? Name { get; set; }

        public string? DepartingFlight { get; set; }

        public string? ArrivalFlight { get; set; }

        public string? Identity { get; set; }

        public string? Gender { get; set; }

        public string? Birthday { get; set; }

        public string? Age { get; set; }

        public string? Contact { get; set; }

        public string? Remark { get; set; }

        public DateOnly? OrderDate { get; set; }
    }
}
