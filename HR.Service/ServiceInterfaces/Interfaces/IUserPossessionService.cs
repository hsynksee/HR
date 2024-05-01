using HR.Data.Entities;
using HR.Service.Request.Possession;
using HR.Service.Request.User;
using HR.Service.Response.Possession;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces.Interfaces
{
    public interface IUserPossessionService
    {
        Task<BaseResponse<List<UserPossessionResponse>>> GetPossessions();
        Task<BaseResponse<UserPossessionResponse>> GetPossessionById(int id);
        Task<BaseResponse<int>> CreatePossession([FromBody] UserPossessionRequest request);
        Task<BaseResponse<int>> UpdatePossession([FromBody] UserPossessionRequest request);
        Task<BaseResponse<bool>> DeletePossession(int id);
    }
}
