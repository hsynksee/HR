using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Constants
{
    public static class PermissionCodes
    {
        public const string RoleList = "role-list";
        public const string RoleCreate = "role-create";
        public const string RoleUpdate = "role-update";
        public const string RoleDelete = "role-delete";

        public const string UserList = "user-list";
        public const string UserCreate = "user-create";
        public const string UserUpdate = "user-update";
        public const string UserDelete = "user-delete";

        public const string UserPersonelInformationList = "user-personel-information-list";
        public const string UserPersonelInformationSave = "user-personel-information-save";
        public const string UserPersonelInformationDelete = "user-personel-information-delete";

        public const string UserOtherInformationList = "user-other-information-list";
        public const string UserOtherInformationSave = "user-other-information-save";
        public const string UserOtherInformationDelete = "user-other-information-delete";

        public const string CompanyList = "company-list";
        public const string CompanyCreate = "company-create";
        public const string CompanyUpdate = "company-update";
        public const string CompanyDelete = "company-delete";

        public const string BranchOfficeList = "branch-office-list";
        public const string BranchOfficeCreate = "branch-office-create";
        public const string BranchOfficeUpdate = "branch-office-update";
        public const string BranchOfficeDelete = "branch-office-delete";

        public const string DepartmentList = "department-list";
        public const string DepartmentCreate = "department-create";
        public const string DepartmentUpdate = "department-update";
        public const string DepartmentDelete = "department-delete";

        public const string JobTitleList = "job-title-list";
        public const string JobTitleCreate = "job-title-create";
        public const string JobTitleUpdate = "job-title-update";
        public const string JobTitleDelete = "job-title-delete";

        public const string UserJobPositionList = "user-job-position-list";
        public const string UserJobPositionCreate = "user-job-position-create";
        public const string UserJobPositionUpdate = "user-job-position-update";
        public const string UserJobPositionDelete = "user-job-position-delete";

        public const string UserSalaryList = "user-salary-list";
        public const string UserSalaryCreate = "user-salary-create";
        public const string UserSalaryUpdate = "user-salary-update";
        public const string UserSalaryDelete = "user-salary-delete";

        public const string CreateLeaveSetting = "create-leave-setting";
        public const string UpdateLeaveSetting = "update-leave-setting";
        public const string GetLeaveSetting = "get-leave-setting";
        public const string GetLeaveSettingById = "get-leave-setting-by-ıd";
        public const string GetLeaveSettingByLeaveType = "get-leave-setting-by-leave-type";
        public const string DeleteLeaveSetting = "delete-leave-setting";
    }
}
