using QingYuan.Model.Tables;

namespace QingYuan.Services
{
    public interface IAccnountService
    {
        public Task LoginAsync(User user);
    }
}
