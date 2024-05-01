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
    public class CompanyRepository : IRepositoryBase<Company>, ICompanyRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public CompanyRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Company>> GetAll()
        {
            return await _ctx.Companies.ToListAsync();
        }

        public async Task<Company> FindById(int Id)
        {
            return await _ctx.Companies
                    .Include(i => i.BranchOffices)
                .SingleOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<Company> Create(Company entity)
        {
            await _ctx.Companies.AddAsync(entity);
            return entity;
        }

        public void Update(Company entity)
        {
            _ctx.Companies.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.Companies.Remove(await this.FindById(id));
        }
    }
}
