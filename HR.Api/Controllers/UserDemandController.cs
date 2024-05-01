using HR.Api.Infrastructure.Abstractions;
using HR.Service.Request.UserDemand;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    public class UserDemandController : BaseController
    {
        private IUserDemandService _userDemandService;
        public UserDemandController(ISystemAppService systemAppService, IUserDemandService userDemandService) : base(systemAppService)
        {
            _userDemandService = userDemandService;
        }

        #region Leave
        [HttpPost("CreateLeave")]
        public async Task<IActionResult> CreateLeave([FromBody] UserLeaveCreateRequest request) => Ok(await _userDemandService.CreateLeave(request));

        [HttpGet("GetLeaveByUserId")]
        public async Task<IActionResult> GetLeaveByUserId(int id) => Ok(await _userDemandService.GetLeaveByUserId(id));

        [HttpGet("GetUserLeaveById")]
        public async Task<IActionResult> GetUserLeaveById(int id) => Ok(await _userDemandService.GetUserLeaveById(id));
        [HttpPut("UpdateUserLeave")]
        public async Task<IActionResult> UpdateUserLeave([FromBody] UserLeaveUpdateRequest request) => Ok(await _userDemandService.UpdateUserLeave(request));

        [HttpDelete("DeleteUserLeave")]
        public async Task<IActionResult> DeleteUserLeave(int id) => Ok(await _userDemandService.DeleteUserLeave(id));
        #endregion

        #region AdvancePayment
        [HttpPost("CreateAdvancePayment")]
        public async Task<IActionResult> CreateAdvancePayment([FromBody] AdvancePaymentCreateRequest request) => Ok(await _userDemandService.CreateAdvancePayment(request));

        [HttpGet("GetAdvancePaymentByUserId")]
        public async Task<IActionResult> GetAdvancePaymentByUserId(int id) => Ok(await _userDemandService.GetAdvancePaymentByUserId(id));
        #endregion

        #region Expense
        [HttpPost("CreateExpense")]
        public async Task<IActionResult> CreateExpense([FromForm] ExpenseCreateRequest request) => Ok(await _userDemandService.CreateExpense(request));

        [HttpGet("GetExpenseByUserId")]
        public async Task<IActionResult> GetExpenseByUserId(int id) => Ok(await _userDemandService.GetExpenseByUserId(id));
        #endregion

        #region Overtime
        [HttpPost("CreateOvertime")]
        public async Task<IActionResult> CreateOvertime([FromBody] OvertimeCreateRequest request) => Ok(await _userDemandService.CreateOvertime(request));

        [HttpGet("GetOvertimeByUserId")]
        public async Task<IActionResult> GetOvertimeByUserId(int id) => Ok(await _userDemandService.GetOvertimeByUserId(id));
        #endregion
    }
}
