using HR.Data.Enums;
using HR.Service.Request.LeaveSetting;
using HR.Service.Request.User;
using HR.Service.Response.LeaveSetting;
using HR.Service.Response.User;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces.Interfaces
{
    public interface ILeaveSettingService
    {
        Task<BaseResponse<int>> CreateLeaveSetting(LeaveSettingResponse request);

        Task<BaseResponse<int>> UpdateLeaveSetting(LeaveSettingUpdateRequest request);

        Task<BaseResponse<List<LeaveSettingResponse>>> GetLeaveSetting();

        Task<BaseResponse<LeaveSettingResponse>> GetLeaveSettingById(int id);
        Task<BaseResponse<List<LeaveSettingResponse>>> GetLeaveSettingByLeaveType(int leaveTypeId);
        Task<BaseResponse<bool>> DeleteLeaveSetting(int id);
    }
}
