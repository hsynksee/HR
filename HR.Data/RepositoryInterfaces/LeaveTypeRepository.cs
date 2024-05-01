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
    public class LeaveTypeRepository : IRepositoryBase<LeaveType>, ILeaveTypeRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public LeaveTypeRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<LeaveType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveType> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveType> Create(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public void Update(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
