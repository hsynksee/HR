using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Data.RepositoryInterfaces
{
    public class UserPersonelInformationRepository : IRepositoryBase<UserPersonelInformation>, IUserPersonelInformationRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public UserPersonelInformationRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<UserPersonelInformation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserPersonelInformation> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserPersonelInformation> Create(UserPersonelInformation entity)
        {
            await _ctx.UserPersonelInformations.AddAsync(entity);
            return entity;
        }

        public void Update(UserPersonelInformation entity)
        {
            _ctx.UserPersonelInformations.Update(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserPersonelInformation> FindByUserId(int id)
        {
            return await _ctx.UserPersonelInformations
                .SingleOrDefaultAsync(f => f.UserId == id);
        }
    }
}
