using HR.Data.Entities;
using HR.Service.Request.User;
using HR.Service.Request.UserJobPosition;
using HR.Service.Response.User;
using HR.Service.Response.UserJobPosition;
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
    public interface IUserService
    {
        #region Role
        Task<BaseResponse<List<RoleResponse>>> GetRoles();

        Task<BaseResponse<RoleResponse>> GetRoleById(int id);
        #endregion

        #region User
        Task<BaseResponse<int>> CreateUser(UserCreateRequest request);

        Task<BaseResponse<int>> UpdateUser(UserUpdateRequest request);

        Task<BaseResponse<List<UserResponse>>> GetUsers();

        Task<BaseResponse<UserResponse>> GetUserById(int id);

        Task<BaseResponse<bool>> SetUserActive(int id);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordRequest request);

        Task<BaseResponse<Guid?>> ForgotPassword(ForgotRequest request);

        Task<BaseResponse<bool>> ForgotChangePassword(ForgotChangePassword request);
        #endregion

        #region User Personel Information
        Task<BaseResponse<int>> SaveUserPersonelInformation(UserPersonelInformationSaveRequest request);

        Task<BaseResponse<int>> CreateUserPersonelInformation(UserPersonelInformationSaveRequest request);

        Task<BaseResponse<int>> UpdateUserPersonelInformation(UserPersonelInformationSaveRequest request);

        Task<BaseResponse<UserPersonelInformationResponse>> GetUserPersonelInformationByUserId(int userId);
        #endregion

        #region User Other Information
        Task<BaseResponse<int>> SaveUserOtherInformation(UserOtherInformationSaveRequest request);

        Task<BaseResponse<int>> CreateUserOtherInformation(UserOtherInformationSaveRequest request);

        Task<BaseResponse<int>> UpdateUserOtherInformation(UserOtherInformationSaveRequest request);

        Task<BaseResponse<UserOtherInformationResponse>> GetUserOtherInformationByUserId(int userId);
        #endregion

        #region User Job
        Task<BaseResponse<int>> CreateUserJobPosition(UserJobPositionCreateRequest request);
        Task<BaseResponse<int>> UpdateUserJobPosition(UserJobPositionUpdateRequest request);
        Task<BaseResponse<bool>> DeleteUserJobPosition(int id);
        Task<BaseResponse<UserJobPositionResponse>> GetUserJobPositionById(int id);
        Task<BaseResponse<List<UserJobPositionResponse>>> GetUserJobPositionByUserId(int userId);
        #endregion

        #region User Salary
        Task<BaseResponse<int>> CreateUserSalary(UserSalaryCreateRequest request);
        Task<BaseResponse<int>> UpdateUserSalary(UserSalaryUpdateRequest request);
        Task<BaseResponse<bool>> DeleteUserSalary(int id);
        Task<BaseResponse<UserSalaryResponse>> GetUserSalaryById(int id);
        Task<BaseResponse<List<UserSalaryResponse>>> GetUserSalaryByUserId(int userId);
        #endregion
    }
}
