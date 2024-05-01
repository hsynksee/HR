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
    public class DistrictRepository : IRepositoryBase<District>, IDistrictRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public DistrictRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<District>> GetAll()
        {
            return await _ctx.Districts.ToListAsync();
        }

        public async Task<List<District>> GetDistrictiesByCityId(int cityId)
        {
            return await _ctx.Districts.Where(w => w.CityId == cityId).OrderBy(o => o.Name).ToListAsync();
        }

        public Task<District> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<District> Create(District entity)
        {
            throw new NotImplementedException();
        }

        public void Update(District entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
