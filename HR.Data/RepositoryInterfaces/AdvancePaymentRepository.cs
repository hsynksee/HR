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
    public class AdvancePaymentRepository : IRepositoryBase<AdvancePayment>, IAdvancePaymentRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public AdvancePaymentRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<AdvancePayment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<AdvancePayment> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdvancePayment> Create(AdvancePayment entity)
        {
            await _ctx.AdvancePayments.AddAsync(entity);
            return entity;
        }

        public void Update(AdvancePayment entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdvancePayment>> FindByUserId(int userId)
        {
            return await _ctx.AdvancePayments.Where(w => w.UserId == userId)
                    .Include(i => i.User)
                .ToListAsync();
        }
    }
}
