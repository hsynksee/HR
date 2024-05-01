using HR.Data.Abstractions;
using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces.Interfaces
{
    public interface IUserLeaveRepository : IRepositoryBase<UserLeave>
    {
        Task<List<UserLeave>> FindByUserId(int userId);
    }
}
