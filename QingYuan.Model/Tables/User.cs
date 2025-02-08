using System.ComponentModel.DataAnnotations;

namespace QingYuan.Model.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
