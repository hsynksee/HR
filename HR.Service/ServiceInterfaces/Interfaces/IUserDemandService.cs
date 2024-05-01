using HR.Data.Entities;
using HR.Service.Request.User;
using HR.Service.Request.UserDemand;
using HR.Service.Response.User;
using HR.Service.Response.UserDemand;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;
using SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces.Interfaces
{
    public interface IUserDemandService
    {
        Task<BaseResponse<int>> CreateLeave([FromBody] UserLeaveCreateRequest request);
        Task<BaseResponse<int>> UpdateUserLeave([FromBody] UserLeaveUpdateRequest request);
        Task<BaseResponse<bool>> DeleteUserLeave(int id);
        Task<BaseResponse<UserLeaveListResponse>> GetUserLeaveById(int id);
        Task<BaseResponse<List<UserLeaveListResponse>>> GetLeaveByUserId(int id);

        Task<BaseResponse<int>> CreateAdvancePayment([FromBody] AdvancePaymentCreateRequest model);

        Task<BaseResponse<List<AdvancePaymentListResponse>>> GetAdvancePaymentByUserId(int id);

        Task<BaseResponse<int>> CreateExpense([FromForm] ExpenseCreateRequest model);

        Task<BaseResponse<List<ExpenseListResponse>>> GetExpenseByUserId(int id);

        Task<BaseResponse<int>> CreateOvertime([FromBody] OvertimeCreateRequest request);

        Task<BaseResponse<List<OvertimeListResponse>>> GetOvertimeByUserId(int id);
    }
}
