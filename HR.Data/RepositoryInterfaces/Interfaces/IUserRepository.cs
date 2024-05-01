using HR.Data.Abstractions;
using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByAuthKey(Guid forgotPasswordKey);
    }
}
