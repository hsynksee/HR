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
    public class CountryRepository : IRepositoryBase<Country>, ICountryRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public CountryRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Country>> GetAll()
        {
            return await _ctx.Countries.OrderBy(o => o.Name).ToListAsync();
        }

        public Task<Country> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Country> Create(Country entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
