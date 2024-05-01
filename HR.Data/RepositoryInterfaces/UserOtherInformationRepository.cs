using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Data.RepositoryInterfaces
{
    public class UserOtherInformationRepository : IRepositoryBase<UserOtherInformation>, IUserOtherInformationRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public UserOtherInformationRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<UserOtherInformation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserOtherInformation> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserOtherInformation> Create(UserOtherInformation entity)
        {
            await _ctx.UserOtherInformations.AddAsync(entity);
            return entity;
        }

        public void Update(UserOtherInformation entity)
        {
            _ctx.UserOtherInformations.Update(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserOtherInformation> FindByUserId(int id)
        {
            return await _ctx.UserOtherInformations
                    .Include(i => i.District)
                        .ThenInclude(i => i.City)
                .SingleOrDefaultAsync(f => f.UserId == id);
        }
    }
}
