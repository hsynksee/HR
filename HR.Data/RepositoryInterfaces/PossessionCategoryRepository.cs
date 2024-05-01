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
    public class PossessionCategoryRepository:IRepositoryBase<PossessionCategory>, IPossessionCategoryRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public PossessionCategoryRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<PossessionCategory> Create(PossessionCategory entity)
        {
            await _ctx.PossessionCategories.AddAsync(entity);
            return entity;
        }

        public async Task Delete(int id)
        {
            _ctx.PossessionCategories.Remove(await this.FindById(id));
        }

        public async Task<PossessionCategory> FindById(int id)
        {
            return await _ctx.PossessionCategories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<PossessionCategory>> GetAll()
        {
            return await _ctx.PossessionCategories.ToListAsync();
        }

        public void Update(PossessionCategory entity)
        {
            _ctx.PossessionCategories.Update(entity);
        }
    }
}
