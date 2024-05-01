using HR.Service.Request.User;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;

namespace HR.Service.ServiceInterfaces.Interfaces
{
    public interface ICompanyService
    {
        #region Companies
        Task<BaseResponse<List<CompanyResponse>>> GetCompanies();
        Task<BaseResponse<CompanyResponse>> GetCompanyById(int id);
        Task<BaseResponse<int>> CreateCompany([FromBody] CompanyRequest request);
        Task<BaseResponse<int>> UpdateCompany([FromBody] CompanyUpdateRequest request);
        Task<BaseResponse<bool>> DeleteCompany(int id);
        #endregion

        #region BranchOffices
        Task<BaseResponse<List<BranchOfficeResponse>>> GetBranchOffices();
        Task<BaseResponse<BranchOfficeResponse>> GetBranchOfficeById(int id);
        Task<BaseResponse<List<BranchOfficeResponse>>> GetBranchOfficeByCompanyId(int companyId);
        Task<BaseResponse<int>> CreateBranchOffice([FromBody] BranchOfficeRequest request);
        Task<BaseResponse<int>> UpdateBranchOffice([FromBody] BranchOfficeUpdateRequest request);
        Task<BaseResponse<bool>> DeleteBranchOffice(int id);
        #endregion

        #region Departments
        Task<BaseResponse<List<DepartmentResponse>>> GetDepartments();
        Task<BaseResponse<DepartmentResponse>> GetDepartmentById(int id);
        Task<BaseResponse<List<DepartmentResponse>>> GetDepartmentByBranchOfficesId(int branchOfficeId);
        Task<BaseResponse<int>> CreateDepartment([FromBody] DepartmentCreateRequest request);
        Task<BaseResponse<int>> UpdateDepartment([FromBody] DepartmentUpdateRequest request);
        Task<BaseResponse<bool>> DeleteDepartment(int id);
        #endregion

        #region JobTitles
        Task<BaseResponse<List<JobTitleResponse>>> GetJobTitles();
        Task<BaseResponse<JobTitleResponse>> GetJobTitleById(int id);
        Task<BaseResponse<List<JobTitleResponse>>> GetJobTitleByDepartmentId(int departmentId);
        Task<BaseResponse<int>> CreateJobTitle([FromBody] JobTitleRequest request);
        Task<BaseResponse<int>> UpdateJobTitle([FromBody] JobTitleUpdateRequest request);
        Task<BaseResponse<bool>> DeleteJobTitle(int id);
        #endregion
    }
}
