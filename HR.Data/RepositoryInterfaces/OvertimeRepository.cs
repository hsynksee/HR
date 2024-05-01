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
    public class OvertimeRepository : IRepositoryBase<Overtime>, IOvertimeRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public OvertimeRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Overtime>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Overtime> FindById(int id)
        {
            return await _ctx.Overtimes.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Overtime> Create(Overtime entity)
        {
            await _ctx.Overtimes.AddAsync(entity);
            return entity;
        }

        public void Update(Overtime entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Overtime>> FindByUserId(int userId)
        {
            return await _ctx.Overtimes.Where(w => w.UserId == userId)
                    .Include(i => i.User)
                .ToListAsync();
        }
    }
}
