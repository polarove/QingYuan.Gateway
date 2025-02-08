using Mapster;
using Microsoft.EntityFrameworkCore;
using QingYuan.Common;
using QingYuan.Common.Exceptions;
using QingYuan.Dto.User;
using QingYuan.Model.Tables;

namespace QingYuan.Services.EF.Impl
{
    public class UserService(ApplicationDbContext dbContext) : EFServiceBase(dbContext), IUserService, IScopedService<IUserService>
    {
        public async Task<long> CreateAsync(User dto)
        {
            dto.CreateTime = DateTimeOffset.Now;
            await DbContext.AddAsync(dto);
            await DbContext.SaveChangesAsync();
            return dto.Id;
        }

        public async Task<User?> GetAsync(QueryUserParamDto dto)
        {
            var query = DbContext.User.AsQueryable();
            query = AddFilters(query, dto);
            var user = await query.FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetAsync(long id)
        {
            return await DbContext.User.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var user = await GetAsync(id) ?? throw ServiceResponseException.Fail();
            DbContext.User.Remove(user);
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            user.UpdateTime = DateTime.Now;
            DbContext.User.Update(user);
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        private static IQueryable<User> AddFilters(IQueryable<User> query, QueryUserParamDto dto)
        {
            if (dto.Name != null)
            {
                query = query.Where(x => x.Name == dto.Name);
            }
            return query;
        }
    }
}
