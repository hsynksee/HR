using HR.Api.Infrastructure.Abstractions;
using HR.Api.Infrastructure.Attributes;
using HR.Data.Constants;
using HR.Service.Request.User;
using HR.Service.Request.UserJobPosition;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    public class UserController : BaseController
    { 
        private IUserService _userService;
        public UserController(ISystemAppService systemAppService, IUserService userService) : base(systemAppService)
        {
            _userService = userService;
        }

        #region Role
        [HttpGet("GetRoles")]
        [HasPermission(PermissionCodes.RoleList)]
        public async Task<IActionResult> GetRoles() => Ok(await _userService.GetRoles());

        [HttpGet("GetRoleById")]
        [HasPermission(PermissionCodes.RoleList)]
        public async Task<IActionResult> GetRoleById(int id) => Ok(await _userService.GetRoleById(id));
        #endregion

        #region User
        [HttpPost("CreateUser")]
        [HasPermission(PermissionCodes.UserCreate)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request) => Ok(await _userService.CreateUser(request));

        [HttpPut("UpdateUser")]
        [HasPermission(PermissionCodes.UserUpdate)]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request) => Ok(await _userService.UpdateUser(request));

        [HttpGet("GetUsers")]
        [HasPermission(PermissionCodes.UserList)]
        public async Task<IActionResult> GetUsers() => Ok(await _userService.GetUsers());

        [HttpGet("GetUserById")]
        [HasPermission(PermissionCodes.UserList)]
        public async Task<IActionResult> GetUserById(int id) => Ok(await _userService.GetUserById(id));

        [HttpGet("SetUserActive")]
        [HasPermission(PermissionCodes.UserDelete)]
        public async Task<IActionResult> SetUserActive(int id) => Ok(await _userService.SetUserActive(id));

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request) => Ok(await _userService.ChangePassword(request));
        #endregion

        #region User Personel Information
        [HttpPost("SaveUserPersonelInformation")]
        [HasPermission(PermissionCodes.UserPersonelInformationSave)]
        public async Task<IActionResult> SaveUserPersonelInformation([FromBody] UserPersonelInformationSaveRequest request) => Ok(await _userService.SaveUserPersonelInformation(request));

        [HttpGet("GetUserPersonelInformationByUserId")]
        [HasPermission(PermissionCodes.UserPersonelInformationList)]
        public async Task<IActionResult> GetUserPersonelInformationByUserId(int userId) => Ok(await _userService.GetUserPersonelInformationByUserId(userId));
        #endregion

        #region User Other Information
        [HttpPost("SaveUserOtherInformation")]
        [HasPermission(PermissionCodes.UserOtherInformationSave)]
        public async Task<IActionResult> SaveUserOtherInformation([FromBody] UserOtherInformationSaveRequest request) => Ok(await _userService.SaveUserOtherInformation(request));

        [HttpGet("GetUserOtherInformationByUserId")]
        [HasPermission(PermissionCodes.UserOtherInformationList)]
        public async Task<IActionResult> GetUserOtherInformationByUserId(int userId) => Ok(await _userService.GetUserOtherInformationByUserId(userId));
        #endregion

        #region User Job Position
        [HttpPost("CreateUserJobPosition")]
        [HasPermission(PermissionCodes.UserJobPositionCreate)]
        public async Task<IActionResult> CreateUserJobPosition([FromBody] UserJobPositionCreateRequest request) => Ok(await _userService.CreateUserJobPosition(request));

        [HttpPut("UpdateUserJobPosition")]
        [HasPermission(PermissionCodes.UserJobPositionUpdate)]
        public async Task<IActionResult> UpdateUserJobPosition([FromBody] UserJobPositionUpdateRequest request) => Ok(await _userService.UpdateUserJobPosition(request));

        [HttpDelete("DeleteUserJobPosition")]
        [HasPermission(PermissionCodes.UserJobPositionDelete)]
        public async Task<IActionResult> DeleteUserJobPosition(int id) => Ok(await _userService.DeleteUserJobPosition(id));

        [HttpGet("GetUserJobPositionById")]
        [HasPermission(PermissionCodes.UserJobPositionList)]
        public async Task<IActionResult> GetUserJobPositionById(int id) => Ok(await _userService.GetUserJobPositionById(id));

        [HttpGet("GetUserJobPositionByUserId")]
        [HasPermission(PermissionCodes.UserJobPositionList)]
        public async Task<IActionResult> GetUserJobPositionByUserId(int userId) => Ok(await _userService.GetUserJobPositionByUserId(userId));
        #endregion

        #region User Salary
        [HttpPost("CreateUserSalary")]
        [HasPermission(PermissionCodes.UserSalaryCreate)]
        public async Task<IActionResult> CreateUserSalary([FromBody] UserSalaryCreateRequest request) => Ok(await _userService.CreateUserSalary(request));

        [HttpPut("UpdateUserSalary")]
        [HasPermission(PermissionCodes.UserSalaryUpdate)]
        public async Task<IActionResult> UpdateUserSalary([FromBody] UserSalaryUpdateRequest request) => Ok(await _userService.UpdateUserSalary(request));

        [HttpDelete("DeleteUserSalary")]
        [HasPermission(PermissionCodes.UserSalaryDelete)]
        public async Task<IActionResult> DeleteUserSalary(int id) => Ok(await _userService.DeleteUserSalary(id));

        [HttpGet("GetUserSalaryById")]
        [HasPermission(PermissionCodes.UserSalaryList)]
        public async Task<IActionResult> GetUserSalaryById(int id) => Ok(await _userService.GetUserSalaryById(id));

        [HttpGet("GetUserSalaryByUserId")]
        [HasPermission(PermissionCodes.UserSalaryList)]
        public async Task<IActionResult> GetUserSalaryByUserId(int userId) => Ok(await _userService.GetUserSalaryByUserId(userId));
        #endregion
    }
}
