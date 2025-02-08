
using QingYuan.Dto.User;
using QingYuan.Model.Tables;

namespace QingYuan.Services
{
    public interface IUserService
    {
        public Task<long> CreateAsync(User dto);

        public Task<User?> GetAsync(QueryUserParamDto dto);

        public Task<User?> GetAsync(long id);

        public Task<bool> UpdateAsync(User dto);

        public Task<bool> DeleteAsync(long id);
    }
}
