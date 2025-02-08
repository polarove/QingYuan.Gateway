using QingYuan.Model.Tables;

namespace QingYuan.Services.EF.Impl
{
    public class UserService(ApplicationDbContext dbContext) : EFServiceBase(dbContext), IUserService, IScopedService<IUserService>
    {
        public async Task Create()
        {
            await DbContext.User.AddAsync(new User
            {
                Name = "Test"
            });
            return;
        }
    }
}
