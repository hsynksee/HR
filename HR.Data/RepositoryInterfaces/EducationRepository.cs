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
    public class EducationRepository : IRepositoryBase<Education>, IEducationRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public EducationRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Education>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Education> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Education> Create(Education entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Education entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
