using Microsoft.EntityFrameworkCore;
using QingYuan.Dto;
using QingYuan.Model;
using QingYuan.Model.Base;
using QingYuan.Model.Tables;

namespace QingYuan.Services.EF
{
    public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<User> User { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
