using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces
{
    public class UserLeaveRepository : IRepositoryBase<UserLeave>, IUserLeaveRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public UserLeaveRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<UserLeave>> GetAll()
        {
            return await _ctx.UserLeaves.ToListAsync();
        }

        public async Task<UserLeave> FindById(int id)
        {
            return await _ctx.UserLeaves.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UserLeave> Create(UserLeave entity)
        {
            await _ctx.UserLeaves.AddAsync(entity);
            return entity;
        }

        public void Update(UserLeave entity)
        {
            _ctx.UserLeaves.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.UserLeaves.Remove(await this.FindById(id));
        }

        public async Task<List<UserLeave>> FindByUserId(int userId)
        {
            return await _ctx.UserLeaves.Where(w => w.UserId == userId)
                    .Include(i => i.User)
                    .Include(i => i.TemporaryUser)
                .ToListAsync();
        }
    }
}
