
using QingYuan.Model.Tables;

namespace QingYuan.Services
{
    public interface IUserService
    {
        public Task CreateAsync();

        public Task<User?> GetAsync(int id);
    }
}
