using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces.Interfaces
{
    public interface ILeaveSettingRepository:IRepositoryBase<LeaveSetting>
    {
        Task<List<LeaveSetting>> GetLeaveSettingsByLeaveTypeId(int leaveTypeId);
    }
}
