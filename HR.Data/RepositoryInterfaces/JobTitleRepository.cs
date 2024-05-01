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
    public class JobTitleRepository : IRepositoryBase<JobTitle>, IJobTitleRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public JobTitleRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<JobTitle>> GetAll()
        {
            return await _ctx.JobTitles.Include(i => i.Department).ToListAsync();
        }

        public async Task<JobTitle> FindById(int id)
        {
            return await _ctx.JobTitles
                    .Include(i => i.Department)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        public async Task<List<JobTitle>> FindByDepartmentId(int departmentId)
        {
            return await _ctx.JobTitles
                    .Include(i => i.Department)
                .Where(f => f.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<JobTitle> Create(JobTitle entity)
        {
            await _ctx.JobTitles.AddAsync(entity);
            return entity;
        }

        public void Update(JobTitle entity)
        {
            _ctx.JobTitles.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.JobTitles.Remove(await this.FindById(id));
        }
    }
}
