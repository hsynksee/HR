using AutoMapper;
using HR.Data.Entities;
using HR.Service.Request.User;
using HR.Service.Request.UserDemand;
using HR.Service.Response.Location;
using HR.Service.Response.LeaveSetting;
using HR.Service.Response.User;
using HR.Service.Response.UserDemand;
using HR.Service.Response.UserJobPosition;
using SharedKernel.Constants;
using SharedKernel.Helpers;
using SharedKernel.Models;
using System.ComponentModel;
using HR.Service.Request.PossessionCategory;
using HR.Service.Response.Possession;

namespace HR.Service.AutoMapper
{
    public class AutoMapperService : Profile
    {
        public AutoMapperService()
        {
            #region Request

            #endregion

            #region Response

            #region User
            CreateMap<Role, RoleResponse>();
            CreateMap<JobTitle, RoleResponse>()
                .ForMember(u => u.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<User, UserResponse>()
                .ForMember(u => u.Roles, opt => opt.MapFrom(x => x.UserRoles.Select(s => s.RoleId)));

            CreateMap<User, CurrentUser>()
                .ForMember(u => u.Name, opt => opt.MapFrom(x => x.Name + " " + x.Surname))
                .ForMember(u => u.Permissions, opt => opt.MapFrom(x => SetPermissions(x.UserRoles.ToList())));

            CreateMap<UserPersonelInformation, UserPersonelInformationResponse>()
                .ForMember(u => u.IdentityNumber, opt => opt.MapFrom(x => EncryptHelper.Decrypt(x.IdentityNumber, HttpContextKeys.IdentityNumberKey)));
            CreateMap<UserOtherInformation, UserOtherInformationResponse>()
                .ForMember(u => u.CityId, opt => opt.MapFrom(x => x.District.CityId))
                .ForMember(u => u.CountryId, opt => opt.MapFrom(x => x.District.City.CountryId));

            CreateMap<UserJobPosition, UserJobPositionResponse>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.User.Name + " " + x.User.Surname))
                .ForMember(u => u.Manager, opt => opt.MapFrom(x => x.Manager.Name + " " + x.Manager.Surname))
                .ForMember(u => u.JobTitle, opt => opt.MapFrom(x => x.JobTitle.Name))
                .ForMember(u => u.DepartmentId, opt => opt.MapFrom(x => x.JobTitle.DepartmentId))
                .ForMember(u => u.BranchOfficeId, opt => opt.MapFrom(x => x.JobTitle.Department.BranchOfficeId))
                .ForMember(u => u.CompanyId, opt => opt.MapFrom(x => x.JobTitle.Department.BranchOffice.CompanyId));

            CreateMap<UserSalary, UserSalaryResponse>();
            CreateMap<LeaveSetting, LeaveSettingResponse>()
                .ForMember(u => u.NumberOfMeritDays, opt => opt.MapFrom(x => x.NumberOfMeritDays))
                .ForMember(u => u.MinExperienceYear, opt => opt.MapFrom(x => x.MinExperienceYear))
                .ForMember(u => u.MaxExperienceYear, opt => opt.MapFrom(x => x.MaxExperienceYear))
                .ForMember(u => u.LeaveTypeId, opt => opt.MapFrom(x => x.LeaveTypeId));
            #endregion

            #region UserDemand
            CreateMap<UserLeave, UserLeaveListResponse>()
                .ForMember(u => u.User, opt => opt.MapFrom(x => x.User.Name + " " + x.User.Surname))
                .ForMember(u => u.TemporaryUser, opt => opt.MapFrom(x => x.TemporaryUser.Name + " " + x.TemporaryUser.Surname))
                .ForMember(u => u.OvertimeStart, opt => opt.MapFrom(x => OvertimeStart(x.EndDate)))
                .ForMember(u => u.LeaveDays, opt => opt.MapFrom(x => LeaveDays(x.StartDate, x.EndDate)));
            CreateMap<AdvancePayment, AdvancePaymentListResponse>()
                .ForMember(u => u.User, opt => opt.MapFrom(x => x.User.Name + " " + x.User.Surname));
            CreateMap<Expense, ExpenseListResponse>()
                .ForMember(u => u.User, opt => opt.MapFrom(x => x.User.Name + " " + x.User.Surname))
                .ForMember(u => u.Category, opt => opt.MapFrom(x => EnumHelper.GetEnumDescription(x.CategoryId)));
            CreateMap<Overtime, OvertimeListResponse>()
                .ForMember(u => u.User, opt => opt.MapFrom(x => x.User.Name + " " + x.User.Surname));
            #endregion

            #region Company
            CreateMap<Company, CompanyResponse>();
            CreateMap<BranchOffice, BranchOfficeResponse>()
                .ForMember(u => u.CompanyId, opt => opt.MapFrom(x => x.Company.Id))
                .ForMember(u => u.CompanyName, opt => opt.MapFrom(x => x.Company.Name));
            CreateMap<Department, DepartmentResponse>()
                .ForMember(u => u.BranchOfficeId, opt => opt.MapFrom(x => x.BranchOffice.Id))
                .ForMember(u => u.BranchOfficeName, opt => opt.MapFrom(x => x.BranchOffice.Name))
                .ForMember(u => u.Managers, opt => opt.MapFrom(x => x.DepartmentManagers.Select(s => new IdNameResponse { Id = s.User.Id, Name = s.User.Name + " " + s.User.Surname }).ToList()));
            CreateMap<JobTitle, JobTitleResponse>()
                .ForMember(u => u.DepartmentId, opt => opt.MapFrom(x => x.Department.Id))
                .ForMember(u => u.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));
            #endregion

            #region Location
            CreateMap<Country, CountryResponse>();
            CreateMap<City, CityResponse>();
            CreateMap<District, DistrictResponse>();
            #endregion

            #region Possession
            CreateMap<PossessionCategory, PossessionCategoryResponse>();
            CreateMap<UserPossession, UserPossessionResponse>();
            #endregion
            #endregion
        }

        protected virtual DateTime OvertimeStart(DateTime dt)
        {
            if (dt.Hour >= 18)
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 00);
                if (dt.AddDays(1).DayOfWeek == DayOfWeek.Saturday)
                    return dt.AddDays(3);
                else if (dt.AddDays(1).DayOfWeek == DayOfWeek.Sunday)
                    return dt.AddDays(2);
                else
                    return dt.AddDays(1);
            }
            else if (dt.Hour == 12 && dt.Minute == 30)
                return dt.AddHours(1);
            else
                return dt;
        }

        protected virtual double LeaveDays(DateTime start, DateTime end)
        {
            var days = 0.0;
            var dt = new DateTime(start.Year, start.Month, start.Day, 8, 30, 0);
            for (DateTime date = dt; date <= end; date = date.AddDays(1))
            {
                if (date.ToShortDateString() == end.ToShortDateString())
                {
                    if (start.ToShortTimeString() == date.ToShortTimeString())
                    {
                        var minutes = (end - date).TotalMinutes;
                        if (minutes > 240)
                        {
                            days += 0.5;
                            minutes = (end - date.AddHours(5)).TotalMinutes;
                            days += ((minutes / 270) / 2);
                        }
                        else if (minutes == 240)
                            days += 0.5;
                        else
                            days += ((minutes / 240) / 2);
                    }
                    else
                    {
                        days++;
                        var newStart = Convert.ToDateTime(date.ToShortDateString() + " " + start.ToShortTimeString());
                        var minutes = (newStart - date).TotalMinutes;
                        if (minutes > 240)
                        {
                            days -= 0.5;
                            minutes = (newStart - date.AddHours(5)).TotalMinutes;
                            days -= ((minutes / 270) / 2);
                        }
                        else if (minutes == 240)
                            days -= 0.5;
                        else
                            days -= ((minutes / 240) / 2);
                    }
                }
                else
                    days++;
            }

            return Math.Round(days, 2);
        }

        private List<string> SetPermissions(List<UserRole> userRoles)
        {
            List<string> permissionCodes = new List<string>();

            foreach (var item in userRoles)
            {
                permissionCodes.AddRange(item.Role.RolePermissions.Select(a => a.Permission.Code).ToList());
            }

            return permissionCodes;
        }

        private string GetEnumDescription<T>(T enumValue)
        {
            if (enumValue == null)
                return "";

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }
    }
}
