using Mapster;
using Microsoft.EntityFrameworkCore;
using QingYuan.Dto.User;
using QingYuan.Exceptions;
using QingYuan.Model.Tables;
using QingYuan.Services.EF.Base;

namespace QingYuan.Services.EF.Impl
{
    public class UserServiceImpl(ApplicationDbContext dbContext) : EFServiceBase(dbContext), IUserService, IScopedService<IUserService>
    {
        public async Task<long> CreateAsync(CreateUserParamDto dto)
        {
            var user = dto.Adapt<User>();
            DbContext.User.Add(user);
            await DbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<List<User>?> GetAsync(QueryUserParamDto dto)
        {
            var query = DbContext.User.AsQueryable();
            query = AddFilters(query, dto);
            var user = await query.ToListAsync();
            return user;
        }

        public async Task<User?> GetAsync(long id)
        {
            return await DbContext.User.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var user = await GetAsync(id) ?? throw ServiceResponseException.NotFound();
            DbContext.User.Remove(user);
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(UpdateUserParamDto dto)
        {
            var user = await GetAsync(dto.Id) ?? throw ServiceResponseException.NotFound();
            user.Name = dto.Name;
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
