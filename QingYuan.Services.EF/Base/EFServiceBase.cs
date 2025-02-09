namespace QingYuan.Services.EF.Base
{
    public class EFServiceBase(ApplicationDbContext dbContext)
    {
        protected ApplicationDbContext DbContext { get; } = dbContext;
    }
}
