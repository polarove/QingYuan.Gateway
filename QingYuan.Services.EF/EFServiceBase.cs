namespace QingYuan.Services.EF
{
    public class EFServiceBase(ApplicationDbContext dbContext)
    {
        protected ApplicationDbContext DbContext { get; } = dbContext;
    }
}
