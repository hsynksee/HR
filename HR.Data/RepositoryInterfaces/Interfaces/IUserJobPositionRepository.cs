using HR.Data.Abstractions;
using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces.Interfaces
{
    public interface IUserJobPositionRepository : IRepositoryBase<UserJobPosition>
    {
        Task<List<UserJobPosition>> FindAllByUserId(int userId);
        Task<bool> UserJobPositionActive(int userId, DateTime startDate, int? id = null);
    }
}
