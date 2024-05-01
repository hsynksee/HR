using HR.Api.Infrastructure.Abstractions;
using HR.Api.Infrastructure.Attributes;
using HR.Data.Constants;
using HR.Service.Request.LeaveSetting;
using HR.Service.Request.User;
using HR.Service.Response.LeaveSetting;
using HR.Service.ServiceInterfaces;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/[controller]")]
    public class LeaveSettingController : BaseController
    {
        private readonly ILeaveSettingService _leaveSettingService;
        public LeaveSettingController(ISystemAppService systemAppService, ILeaveSettingService leaveSettingService) : base(systemAppService)
        {
            _leaveSettingService = leaveSettingService;
        }

        
        [HttpPost("CreateLeaveSetting")]
        public async Task<IActionResult> CreateLeaveSetting([FromBody] LeaveSettingResponse request) => Ok(await _leaveSettingService.CreateLeaveSetting(request));

        [HttpPut("UpdateLeaveSetting")]
        public async Task<IActionResult> UpdateLeaveSetting([FromBody] LeaveSettingUpdateRequest request) => Ok(await _leaveSettingService.UpdateLeaveSetting(request));

        [HttpGet("GetLeaveSetting")]
        public async Task<IActionResult> GetLeaveSetting() => Ok(await _leaveSettingService.GetLeaveSetting());

        [HttpGet("GetLeaveSettingById")]
        public async Task<IActionResult> GetLeaveSettingById(int id) => Ok(await _leaveSettingService.GetLeaveSettingById(id));

        [HttpGet("GetLeaveSettingByLeaveType")]
        public async Task<IActionResult> GetLeaveSettingByLeaveType(int leaveTypeId) => Ok(await _leaveSettingService.GetLeaveSettingByLeaveType(leaveTypeId));

        [HttpDelete("DeleteLeaveSetting")]
        public async Task<IActionResult> DeleteLeaveSetting(int id) => Ok(await _leaveSettingService.DeleteLeaveSetting(id));
    }
}
