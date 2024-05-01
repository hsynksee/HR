using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Data.RepositoryInterfaces.Interfaces;

namespace HR.Data.Abstractions
{
    public interface IRepositoryWrapper
    {
        ICityRepository CityRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICountryRepository CountryRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IDistrictRepository DistrictRepository { get; }
        IEducationRepository EducationRepository { get; }
        IBranchOfficeRepository BranchOfficeRepository { get; }
        ILeaveTypeRepository LeaveTypeRepository { get; }
        IUserJobPositionRepository UserJobPositionRepository { get; }
        IUserLeaveRepository UserLeaveRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IJobTitleRepository JobTitleRepository { get; }
        IAdvancePaymentRepository AdvancePaymentRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
        IOvertimeRepository OvertimeRepository { get; }
        IUserPersonelInformationRepository UserPersonelInformationRepository { get; }
        IUserOtherInformationRepository UserOtherInformationRepository { get; }
        IUserSalaryRepository UserSalaryRepository { get; }
        ILeaveSettingRepository LeaveSettingRepository { get; }
        IPossessionCategoryRepository PossessionCategoryRepository { get; }
        IUserPossessionRepository PossessionRepository { get; }

        Task<int> Save();
    }
}
