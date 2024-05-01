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
    public class PermissionRepository : IRepositoryBase<Permission>, IPermissionRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public PermissionRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<Permission>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Permission> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> Create(Permission entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Permission entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
