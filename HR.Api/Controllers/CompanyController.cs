using HR.Api.Infrastructure.Abstractions;
using HR.Api.Infrastructure.Attributes;
using HR.Data.Constants;
using HR.Service.Request.User;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    public class CompanyController : BaseController
    {
        private ICompanyService _companyService;
        public CompanyController(ISystemAppService systemAppService, ICompanyService companyService) : base(systemAppService)
        {
            _companyService = companyService;
        }

        #region Companies
        [HttpGet("GetCompanies")]
        [HasPermission(PermissionCodes.CompanyList)]
        public async Task<IActionResult> GetCompanies() => Ok(await _companyService.GetCompanies());

        [HttpGet("GetCompanyById")]
        [HasPermission(PermissionCodes.CompanyList)]
        public async Task<IActionResult> GetCompanyById(int id) => Ok(await _companyService.GetCompanyById(id));

        [HttpPost("CreateCompany")]
        [HasPermission(PermissionCodes.CompanyCreate)]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyRequest request) => Ok(await _companyService.CreateCompany(request));

        [HttpPut("UpdateCompany")]
        [HasPermission(PermissionCodes.CompanyUpdate)]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyUpdateRequest request) => Ok(await _companyService.UpdateCompany(request));

        [HttpDelete("DeleteCompany")]
        [HasPermission(PermissionCodes.CompanyDelete)]
        public async Task<IActionResult> DeleteCompany(int id) => Ok(await _companyService.DeleteCompany(id));
        #endregion

        #region BranchOffices
        [HttpGet("GetBranchOffices")]
        [HasPermission(PermissionCodes.BranchOfficeList)]
        public async Task<IActionResult> GetBranchOffices() => Ok(await _companyService.GetBranchOffices());

        [HttpGet("GetBranchOfficeById")]
        [HasPermission(PermissionCodes.BranchOfficeList)]
        public async Task<IActionResult> GetBranchOfficeById(int id) => Ok(await _companyService.GetBranchOfficeById(id));

        [HttpPost("CreateBranchOffice")]
        [HasPermission(PermissionCodes.BranchOfficeCreate)]
        public async Task<IActionResult> CreateBranchOffice([FromBody] BranchOfficeRequest request) => Ok(await _companyService.CreateBranchOffice(request));

        [HttpPut("UpdateBranchOffice")]
        [HasPermission(PermissionCodes.BranchOfficeUpdate)]
        public async Task<IActionResult> UpdateBranchOffice([FromBody] BranchOfficeUpdateRequest request) => Ok(await _companyService.UpdateBranchOffice(request));

        [HttpDelete("DeleteBranchOffice")]
        [HasPermission(PermissionCodes.BranchOfficeDelete)]
        public async Task<IActionResult> DeleteBranchOffice(int id) => Ok(await _companyService.DeleteBranchOffice(id));

        [HttpGet("GetBranchOfficeByCompanyId")]
        [HasPermission(PermissionCodes.BranchOfficeList)]
        public async Task<IActionResult> GetBranchOfficeByCompanyId(int companyId) => Ok(await _companyService.GetBranchOfficeByCompanyId(companyId));
        #endregion

        #region Departments
        [HttpGet("GetDepartments")]
        [HasPermission(PermissionCodes.DepartmentList)]
        public async Task<IActionResult> GetDepartments() => Ok(await _companyService.GetDepartments());

        [HttpGet("GetDepartmentById")]
        [HasPermission(PermissionCodes.DepartmentList)]
        public async Task<IActionResult> GetDepartmentById(int id) => Ok(await _companyService.GetDepartmentById(id));

        [HttpPost("CreateDepartment")]
        [HasPermission(PermissionCodes.DepartmentCreate)]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentCreateRequest request) => Ok(await _companyService.CreateDepartment(request));

        [HttpPut("UpdateDepartment")]
        [HasPermission(PermissionCodes.DepartmentUpdate)]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentUpdateRequest request) => Ok(await _companyService.UpdateDepartment(request));

        [HttpDelete("DeleteDepartment")]
        [HasPermission(PermissionCodes.DepartmentDelete)]
        public async Task<IActionResult> DeleteDepartment(int id) => Ok(await _companyService.DeleteDepartment(id));

        [HttpGet("GetDepartmentByBranchOfficesId")]
        [HasPermission(PermissionCodes.DepartmentList)]
        public async Task<IActionResult> GetDepartmentByBranchOfficesId(int branchOfficeId) => Ok(await _companyService.GetDepartmentByBranchOfficesId(branchOfficeId));
        #endregion

        #region JobTitles
        [HttpGet("GetJobTitles")]
        [HasPermission(PermissionCodes.JobTitleList)]
        public async Task<IActionResult> GetJobTitles() => Ok(await _companyService.GetJobTitles());

        [HttpGet("GetJobTitleById")]
        [HasPermission(PermissionCodes.JobTitleList)]
        public async Task<IActionResult> GetJobTitleById(int id) => Ok(await _companyService.GetJobTitleById(id));

        [HttpPost("CreateJobTitle")]
        [HasPermission(PermissionCodes.JobTitleCreate)]
        public async Task<IActionResult> CreateJobTitle([FromBody] JobTitleRequest request) => Ok(await _companyService.CreateJobTitle(request));

        [HttpPut("UpdateJobTitle")]
        [HasPermission(PermissionCodes.JobTitleUpdate)]
        public async Task<IActionResult> UpdateJobTitle([FromBody] JobTitleUpdateRequest request) => Ok(await _companyService.UpdateJobTitle(request));

        [HttpDelete("DeleteJobTitle")]
        [HasPermission(PermissionCodes.JobTitleDelete)]
        public async Task<IActionResult> DeleteJobTitle(int id) => Ok(await _companyService.DeleteJobTitle(id));

        [HttpGet("GetJobTitleByDepartmentId")]
        [HasPermission(PermissionCodes.JobTitleList)]
        public async Task<IActionResult> GetJobTitleByDepartmentId(int departmentId) => Ok(await _companyService.GetJobTitleByDepartmentId(departmentId));
        #endregion
    }
}
