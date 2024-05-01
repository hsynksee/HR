using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces
{
    public class RoleRepository : IRepositoryBase<Role>, IRoleRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public RoleRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _ctx.Roles.ToListAsync();
        }

        public async Task<Role> FindById(int id)
        {
            return await _ctx.Roles.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Role> Create(Role entity)
        {
            CheckDuplicate(entity);
            await _ctx.Roles.AddAsync(entity);
            return entity;
        }

        public void Update(Role entity)
        {
            CheckDuplicate(entity);
            _ctx.Roles.Update(entity);
        }

        public async Task Delete(int id)
        {
            _ctx.Roles.Remove(await FindById(id));
        }

        public async Task<Role> GetRoleWithPermissionsAsync(int roleId)
        {
            return await _ctx.Roles.Include(r => r.RolePermissions)
                                                    .ThenInclude(rp => rp.Permission)
                                                    .SingleOrDefaultAsync(r => r.Id == roleId);
        }

        private void CheckDuplicate(Role obj)
        {
            if (_ctx.Roles.Any(c => c.Name.Equals(obj.Name) && !c.Id.Equals(obj.Id)))
                throw new DuplicateRoleException(obj.Name);
        }
    }
}
