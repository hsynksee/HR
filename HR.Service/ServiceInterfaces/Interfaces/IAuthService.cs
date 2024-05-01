using HR.Service.Request.User;
using HR.Service.Response.User;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<CurrentUser>> Login([FromBody] AuthenticateRequest request);
        Task<BaseResponse<CurrentUser>> CurrentUser();
    }
}
