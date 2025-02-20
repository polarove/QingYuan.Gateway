using QingYuan.Common.Extensions;
using System.Reflection;

namespace QingYuan.Model.Tables
{
    public class Member(string sheetName)
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

        public string? OrderDate { get; set; }

        public void SetData()
        {
            if (DateTime.TryParse(Birthday, out DateTime birthDate))
            {
                Age = CalculateAge(birthDate).ToString();
            }
            else
            {
                Age = null;
            }
            OrderDate = sheetName;
        }

        private static int CalculateAge(DateTime datetime) => datetime.CalculateAge();

        public bool AreAllPropertiesNull()
        {
            ArgumentNullException.ThrowIfNull(this);
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.All(property => property.GetValue(this) is null or (object?) "");
        }
    }
}
