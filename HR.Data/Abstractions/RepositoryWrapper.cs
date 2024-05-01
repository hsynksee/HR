using HR.Data.Entities;
using HR.Data.RepositoryInterfaces;
using HR.Data.RepositoryInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Abstractions
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private HumanResourcesContext _ctx;

        private ICityRepository _cities;
        private ICompanyRepository _companies;
        private ICountryRepository _countries;
        private IDepartmentRepository _departments;
        private IDistrictRepository _districts;
        private IEducationRepository _educations;
        private IBranchOfficeRepository _branchOffices;
        private ILeaveTypeRepository _leaveTypes;
        private IUserJobPositionRepository _userJobPositions;
        private IUserLeaveRepository _userLeaves;
        private IUserRepository _users;
        private IRoleRepository _roles;
        private IPermissionRepository _permissions;
        private IJobTitleRepository _jobTitles;
        private IAdvancePaymentRepository _advancePayment;
        private IExpenseRepository _expense;
        private IOvertimeRepository _overtime;
        private IUserPersonelInformationRepository _userPersonelInformation;
        private IUserOtherInformationRepository _userOtherInformation;
        private IUserSalaryRepository _userSalary;
        private ILeaveSettingRepository _leaveSetting;
        private IPossessionCategoryRepository _possessionCategory;
        private IUserPossessionRepository _possession;

        public ICityRepository CityRepository
        {
            get
            {
                if (_cities == null)
                    _cities = new CityRepository(_ctx);

                return _cities;
            }
        }

        public ICompanyRepository CompanyRepository
        {
            get
            {
                if (_companies == null)
                    _companies = new CompanyRepository(_ctx);

                return _companies;
            }
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                if (_countries == null)
                    _countries = new CountryRepository(_ctx);

                return _countries;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departments == null)
                    _departments = new DepartmentRepository(_ctx);

                return _departments;
            }
        }

        public IDistrictRepository DistrictRepository
        {
            get
            {
                if (_districts == null)
                    _districts = new DistrictRepository(_ctx);

                return _districts;
            }
        }

        public IEducationRepository EducationRepository
        {
            get
            {
                if (_educations == null)
                    _educations = new EducationRepository(_ctx);

                return _educations;
            }
        }

        public IBranchOfficeRepository BranchOfficeRepository
        {
            get
            {
                if (_branchOffices == null)
                    _branchOffices = new BranchOfficeRepository(_ctx);

                return _branchOffices;
            }
        }

        public ILeaveTypeRepository LeaveTypeRepository
        {
            get
            {
                if (_leaveTypes == null)
                    _leaveTypes = new LeaveTypeRepository(_ctx);

                return _leaveTypes;
            }
        }

        public IUserJobPositionRepository UserJobPositionRepository
        {
            get
            {
                if (_userJobPositions == null)
                    _userJobPositions = new UserJobPositionRepository(_ctx);

                return _userJobPositions;
            }
        }

        public IUserLeaveRepository UserLeaveRepository
        {
            get
            {
                if (_userLeaves == null)
                    _userLeaves = new UserLeaveRepository(_ctx);

                return _userLeaves;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(_ctx);

                return _users;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roles == null)
                    _roles = new RoleRepository(_ctx);

                return _roles;
            }
        }
        
        public IPermissionRepository PermissionRepository
        {
            get
            {
                if (_permissions == null)
                    _permissions = new PermissionRepository(_ctx);

                return _permissions;
            }
        }

        public IJobTitleRepository JobTitleRepository
        {
            get
            {
                if (_jobTitles == null)
                    _jobTitles = new JobTitleRepository(_ctx);

                return _jobTitles;
            }
        }

        public IAdvancePaymentRepository AdvancePaymentRepository
        {
            get
            {
                if (_advancePayment == null)
                    _advancePayment = new AdvancePaymentRepository(_ctx);

                return _advancePayment;
            }
        }

        public IExpenseRepository ExpenseRepository
        {
            get
            {
                if (_expense == null)
                    _expense = new ExpenseRepository(_ctx);

                return _expense;
            }
        }

        public IOvertimeRepository OvertimeRepository
        {
            get
            {
                if (_overtime == null)
                    _overtime = new OvertimeRepository(_ctx);

                return _overtime;
            }
        }

        public IUserPersonelInformationRepository UserPersonelInformationRepository
        {
            get
            {
                if (_userPersonelInformation == null)
                    _userPersonelInformation = new UserPersonelInformationRepository(_ctx);

                return _userPersonelInformation;
            }
        }

        public IUserOtherInformationRepository UserOtherInformationRepository
        {
            get
            {
                if (_userOtherInformation == null)
                    _userOtherInformation = new UserOtherInformationRepository(_ctx);

                return _userOtherInformation;
            }
        }

        public IUserSalaryRepository UserSalaryRepository
        {
            get
            {
                if (_userSalary == null)
                    _userSalary = new UserSalaryRepository(_ctx);

                return _userSalary;
            }
        }
        public ILeaveSettingRepository LeaveSettingRepository
        {
            get
            {
                if (_leaveSetting == null)
                    _leaveSetting = new LeaveSettingRepository(_ctx);

                return _leaveSetting;
            }
        }
        public IPossessionCategoryRepository PossessionCategoryRepository
        {
            get
            {
                if (_possessionCategory == null)
                    _possessionCategory = new PossessionCategoryRepository(_ctx);

                return _possessionCategory;
            }
        }
        public IUserPossessionRepository PossessionRepository
        {
            get
            {
                if (_possession == null)
                    _possession = new UserPossessionRepository(_ctx);

                return _possession;
            }
        }
        public RepositoryWrapper(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> Save()
        {
            return await _ctx.SaveChangesAsync();
        }
    }
}
