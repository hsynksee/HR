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
    public class BranchOfficeRepository : IRepositoryBase<BranchOffice>, IBranchOfficeRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public BranchOfficeRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<BranchOffice>> GetAll()
        {
            return await _ctx.BranchOffices
                    .Include(i => i.Company)
                .ToListAsync();
        }

        public async Task<BranchOffice> FindById(int Id)
        {
            return await _ctx.BranchOffices
                    .Include(i => i.Company)
                    .Include(i => i.Departments)
                .SingleOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<List<BranchOffice>> FindByCompanyId(int companyId)
        {
            return await _ctx.BranchOffices
                    .Include(i => i.Company)
                    .Include(i => i.Departments)
                .Where(f => f.CompanyId == companyId).ToListAsync();
        }

        public async Task<BranchOffice> Create(BranchOffice entity)
        {
            await _ctx.BranchOffices.AddAsync(entity);
            return entity;
        }

        public void Update(BranchOffice entity)
        {
            _ctx.BranchOffices.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.BranchOffices.Remove(await this.FindById(id));
        }
    }
}
