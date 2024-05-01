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
    public class DepartmentRepository : IRepositoryBase<Department>, IDepartmentRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public DepartmentRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Department>> GetAll()
        {
            return await _ctx.Departments
                    .Include(i => i.BranchOffice)
                .ToListAsync();
        }

        public async Task<Department> FindById(int Id)
        {
            return await _ctx.Departments
                    .Include(i => i.BranchOffice)
                    .Include(i => i.JobTitles)
                    .Include(i => i.DepartmentManagers)
                        .ThenInclude(i => i.User)
                .SingleOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<List<Department>> FindByBranchOfficeId(int branchOfficeId)
        {
            return await _ctx.Departments
                    .Include(i => i.BranchOffice)
                    .Include(i => i.JobTitles)
                    .Include(i => i.DepartmentManagers)
                        .ThenInclude(i => i.User)
                .Where(f => f.BranchOfficeId == branchOfficeId).ToListAsync();
        }

        public async Task<Department> Create(Department entity)
        {
            await _ctx.Departments.AddAsync(entity);
            return entity;
        }

        public void Update(Department entity)
        {
            _ctx.Departments.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.Departments.Remove(await this.FindById(id));
        }

        public async Task<DepartmentManager> DepartmentManagerFindById(int id)
        {
            return await _ctx.DepartmentManagers
                .SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<DepartmentManager>> DepartmentManagerFindAllDepartmentId(int departmentId)
        {
            return await _ctx.DepartmentManagers
                    .Include(i => i.User)
                .Where(f => f.DepartmentId == departmentId).ToListAsync();
        }

        public async Task DepartmentManagerDelete(int id)
        {
            _ctx.DepartmentManagers.Remove(await this.DepartmentManagerFindById(id));
        }
    }
}
