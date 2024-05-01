using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Data.RepositoryInterfaces
{
    public class UserRepository : IRepositoryBase<User>, IUserRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public UserRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<User>> GetAll()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await _ctx.Users
                .Include(i => i.UserRoles)
                    .ThenInclude(i => i.Role.RolePermissions)
                        .ThenInclude(i => i.Permission)
                .SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<User> Create(User entity)
        {
            await _ctx.Users.AddAsync(entity);
            return entity;
        }

        public void Update(User entity)
        {
            _ctx.Users.Update(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _ctx.Users.SingleOrDefaultAsync(f => f.EmailBusiness == email);
        }

        public async Task<User> GetByAuthKey(Guid forgotPasswordKey)
        {
            return await _ctx.Users.SingleOrDefaultAsync(f => f.ForgotPasswordKey == forgotPasswordKey);
        }
    }
}
