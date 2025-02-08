using QingYuan.Model.Tables;

namespace QingYuan.Services.EF.Impl
{
    public class UserService(ApplicationDbContext dbContext) : EFServiceBase(dbContext), IUserService, IScopedService<IUserService>
    {
        public async Task CreateAsync()
        {
            await DbContext.User.AddAsync(new User
            {
                Name = "Test"
            });
            DbContext.SaveChanges();
            return;
        }

        public async Task<User?> GetAsync(int id)
        {
            return await DbContext.User.FindAsync(id);
        }
    }
}
