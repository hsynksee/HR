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
    public class UserJobPositionRepository : IRepositoryBase<UserJobPosition>, IUserJobPositionRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public UserJobPositionRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<UserJobPosition>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserJobPosition> FindById(int id)
        {
            return await _ctx.UserJobPositions
                    .Include(i => i.User)
                    .Include(i => i.Manager)
                    .Include(i => i.JobTitle)
                        .ThenInclude(i => i.Department)
                            .ThenInclude(i => i.BranchOffice)
                .SingleOrDefaultAsync(w => w.Id == id);
        }

        public async Task<List<UserJobPosition>> FindAllByUserId(int userId)
        {
            return await _ctx.UserJobPositions.Where(w => w.UserId == userId)
                    .Include(i => i.User)
                    .Include(i => i.JobTitle)
                    .Include(i => i.Manager)
                .ToListAsync();
        }

        public async Task<UserJobPosition> Create(UserJobPosition entity)
        {
            await _ctx.UserJobPositions.AddAsync(entity);
            return entity;
        }

        public void Update(UserJobPosition entity)
        {
            _ctx.UserJobPositions.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.UserJobPositions.Remove(await this.FindById(id));
        }

        public async Task<bool> UserJobPositionActive(int userId, DateTime startDate, int? id = null)
        {
            var activeUserJobPosition = await _ctx.UserJobPositions.
                Where(w => (w.UserId == userId && (w.EndDate == null || w.EndDate.Value <= startDate)) && (id == null || w.Id != id))
                .SingleOrDefaultAsync();
            return activeUserJobPosition != null;
        }
    }
}
