
using QingYuan.Dto.User;
using QingYuan.Model.Tables;

namespace QingYuan.Services
{
    public interface IUserService
    {
        public Task<long> CreateAsync(CreateUserParamDto dto);

        public Task<List<User>?> GetAsync(QueryUserParamDto dto);

        public Task<User?> GetAsync(long id);

        public Task<bool> UpdateAsync(UpdateUserParamDto dto);

        public Task<bool> DeleteAsync(long id);

        public Task<bool> ExceptionAsync();
    }
}
