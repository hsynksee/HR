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
    public class ExpenseRepository : IRepositoryBase<Expense>, IExpenseRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public ExpenseRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Expense>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> FindById(int id)
        {
            return await _ctx.Expenses.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Expense> Create(Expense entity)
        {
            await _ctx.Expenses.AddAsync(entity);
            return entity;
        }

        public void Update(Expense entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Expense>> FindByUserId(int userId)
        {
            return await _ctx.Expenses.Where(w => w.UserId == userId)
                    .Include(i => i.User)
                .ToListAsync();
        }
    }
}
