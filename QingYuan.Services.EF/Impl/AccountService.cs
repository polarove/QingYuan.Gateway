using QingYuan.Model.Tables;
using QingYuan.Services.EF.Base;

namespace QingYuan.Services.EF.Impl
{
    public class AccountService(ApplicationDbContext dbContext) : EFServiceBase(dbContext), IAccnountService, IScopedService<IAccnountService>
    {
        public Task LoginAsync(User user)
        {
            return Task.CompletedTask;
        }
    }
}
