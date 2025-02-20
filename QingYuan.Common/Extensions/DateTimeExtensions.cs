namespace QingYuan.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dateTime)
        {
            int age = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now < dateTime.AddYears(age))
                age--;
            return age;
        }
    }
}
