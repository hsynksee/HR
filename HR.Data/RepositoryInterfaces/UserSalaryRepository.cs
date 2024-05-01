using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Data.RepositoryInterfaces
{
    public class UserSalaryRepository : IRepositoryBase<UserSalary>, IUserSalaryRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public UserSalaryRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<UserSalary>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserSalary> FindById(int id)
        {
            return await _ctx.UserSalaries.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<UserSalary> Create(UserSalary entity)
        {
            await _ctx.UserSalaries.AddAsync(entity);
            return entity;
        }

        public void Update(UserSalary entity)
        {
            _ctx.UserSalaries.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.UserSalaries.Remove(await this.FindById(id));
        }


        public async Task<List<UserSalary>> FindAllByUserId(int userId)
        {
            return await _ctx.UserSalaries.Where(w => w.UserId == userId).ToListAsync();
        }
    }
}
