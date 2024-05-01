using HR.Application.Service.Request;
using HR.Data.Entities;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Service.Interfaces
{
    public interface IUserRoleService
    {
        Task<BaseResponse<List<UserRole>>> GetUsers();
    }
}
