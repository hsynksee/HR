using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces
{
    public class UserPossessionRepository: IRepositoryBase<UserPossession>, IUserPossessionRepository
    {
        protected HumanResourcesContext _ctx { get; set; }

        public UserPossessionRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<UserPossession>> GetAll()
        {
            return await _ctx.Possessions.ToListAsync();
        }

        public async Task<UserPossession> FindById(int id)
        {
            return await _ctx.Possessions.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<UserPossession> Create(UserPossession entity)
        {
            await _ctx.Possessions.AddAsync(entity);
            return entity;
        }

        public void Update(UserPossession entity)
        {
            _ctx.Possessions.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.Possessions.Remove(await this.FindById(id));
        }
    }
}
