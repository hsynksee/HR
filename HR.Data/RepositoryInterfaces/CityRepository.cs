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
    public class CityRepository : IRepositoryBase<City>, ICityRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public CityRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<City>> GetAll()
        {
            return await _ctx.Cities.OrderBy(o => o.Name).ToListAsync();
        }

        public async Task<List<City>> GetCitiesByCountryId(int countryId)
        {
            return await _ctx.Cities.Where(w => w.CountryId == countryId).OrderBy(o => o.Name).ToListAsync();
        }

        public async Task<City> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<City> Create(City entity)
        {
            throw new NotImplementedException();
        }

        public void Update(City entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
