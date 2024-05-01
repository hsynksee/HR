using AutoMapper;
using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Service.Request.User;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;

namespace HR.Service.ServiceInterfaces
{
    public class CompanyService : BaseAppService, ICompanyService
    {
        public CompanyService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
            
        }

        #region Companies
        public async Task<BaseResponse<List<CompanyResponse>>> GetCompanies()
        {
            var companies = _mapper.Map<List<CompanyResponse>>(await _repository.CompanyRepository.GetAll());
            return new BaseResponse<List<CompanyResponse>>(companies);
        }

        public async Task<BaseResponse<CompanyResponse>> GetCompanyById(int id)
        {
            var company = _mapper.Map<CompanyResponse>(await _repository.CompanyRepository.FindById(id));
            return new BaseResponse<CompanyResponse>(company);
        }

        public async Task<BaseResponse<int>> CreateCompany([FromBody] CompanyRequest request)
        {
            var company = new Company().SetBaseInformation(request.Name);

            await _repository.CompanyRepository.Create(company);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(company.Id);
        }

        public async Task<BaseResponse<int>> UpdateCompany([FromBody] CompanyUpdateRequest request)
        {
            var company = await _repository.CompanyRepository.FindById(request.Id);
            if (company == null) return new BaseResponse<int>(0, "Firma bulunamadı..");

            company.SetBaseInformation(request.Name);
            _repository.CompanyRepository.Update(company);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(company.Id);
        }

        public async Task<BaseResponse<bool>> DeleteCompany(int id)
        {
            var company = await _repository.CompanyRepository.FindById(id);
            if (company == null) return new BaseResponse<bool>(false, "Firma bulunamadı..");

            if (company.BranchOffices != null && company.BranchOffices.Count() > 0)
                return new BaseResponse<bool>(false, "Firmaya bağlı şube(ler) olmamalıdır..");

            await _repository.CompanyRepository.Delete(company.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }
        #endregion

        #region BranchOffices
        public async Task<BaseResponse<List<BranchOfficeResponse>>> GetBranchOffices()
        {
            var branchOffices = _mapper.Map<List<BranchOfficeResponse>>(await _repository.BranchOfficeRepository.GetAll());
            return new BaseResponse<List<BranchOfficeResponse>>(branchOffices);
        }

        public async Task<BaseResponse<BranchOfficeResponse>> GetBranchOfficeById(int id)
        {
            var branchOffice = _mapper.Map<BranchOfficeResponse>(await _repository.BranchOfficeRepository.FindById(id));
            return new BaseResponse<BranchOfficeResponse>(branchOffice);
        }

        public async Task<BaseResponse<int>> CreateBranchOffice([FromBody] BranchOfficeRequest request)
        {
            var branchOffice = new BranchOffice().SetBaseInformation(request.Name, request.CompanyId);

            await _repository.BranchOfficeRepository.Create(branchOffice);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(branchOffice.Id);
        }

        public async Task<BaseResponse<int>> UpdateBranchOffice([FromBody] BranchOfficeUpdateRequest request)
        {
            var branchOffice = await _repository.BranchOfficeRepository.FindById(request.Id);
            if (branchOffice == null) return new BaseResponse<int>(0, "Şube bulunamadı..");

            branchOffice.SetBaseInformation(request.Name, request.CompanyId);
            _repository.BranchOfficeRepository.Update(branchOffice);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(branchOffice.Id);
        }

        public async Task<BaseResponse<bool>> DeleteBranchOffice(int id)
        {
            var branchOffice = await _repository.BranchOfficeRepository.FindById(id);
            if (branchOffice == null) return new BaseResponse<bool>(false, "Şube bulunamadı..");

            if (branchOffice.Departments != null && branchOffice.Departments.Count() > 0)
                return new BaseResponse<bool>(false, "Şubeye bağlı departman(lar) olmamalıdır..");

            await _repository.BranchOfficeRepository.Delete(branchOffice.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }

        public async Task<BaseResponse<List<BranchOfficeResponse>>> GetBranchOfficeByCompanyId(int companyId)
        {
            var branchOffices = _mapper.Map<List<BranchOfficeResponse>>(await _repository.BranchOfficeRepository.FindByCompanyId(companyId));
            return new BaseResponse<List<BranchOfficeResponse>>(branchOffices);
        }
        #endregion

        #region Departments
        public async Task<BaseResponse<List<DepartmentResponse>>> GetDepartments()
        {
            var departments = _mapper.Map<List<DepartmentResponse>>(await _repository.DepartmentRepository.GetAll());
            return new BaseResponse<List<DepartmentResponse>>(departments);
        }

        public async Task<BaseResponse<DepartmentResponse>> GetDepartmentById(int id)
        {
            var department = _mapper.Map<DepartmentResponse>(await _repository.DepartmentRepository.FindById(id));
            return new BaseResponse<DepartmentResponse>(department);
        }

        public async Task<BaseResponse<int>> CreateDepartment([FromBody] DepartmentCreateRequest request)
        {
            var department =new Department().SetBaseInformation(request.Name, request.BranchOfficeId);
            department.AdjusDepartmentManagers(request.Managers);

            await _repository.DepartmentRepository.Create(department);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(department.Id);
        }

        public async Task<BaseResponse<int>> UpdateDepartment([FromBody] DepartmentUpdateRequest request)
        {
            var department = await _repository.DepartmentRepository.FindById(request.Id);
            if (department == null) return new BaseResponse<int>(0, "Departman bulunamadı..");

            department.SetBaseInformation(request.Name, request.BranchOfficeId);
            department.AdjusDepartmentManagers(request.Managers);

            _repository.DepartmentRepository.Update(department);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(department.Id);
        }

        public async Task<BaseResponse<bool>> DeleteDepartment(int id)
        {
            var department = await _repository.DepartmentRepository.FindById(id);
            if (department == null) return new BaseResponse<bool>(false, "Departman bulunamadı..");

            if (department.JobTitles != null && department.JobTitles.Count() > 0)
                return new BaseResponse<bool>(false, "Departmana bağlı ünvan(lar) olmamalıdır..");

            await _repository.DepartmentRepository.Delete(department.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }

        public async Task<BaseResponse<List<DepartmentResponse>>> GetDepartmentByBranchOfficesId(int branchOfficeId)
        {
            var departments = _mapper.Map<List<DepartmentResponse>>(await _repository.DepartmentRepository.FindByBranchOfficeId(branchOfficeId));
            return new BaseResponse<List<DepartmentResponse>>(departments);
        }
        #endregion

        #region JobTitles
        public async Task<BaseResponse<List<JobTitleResponse>>> GetJobTitles()
        {
            var jobTitles = _mapper.Map<List<JobTitleResponse>>(await _repository.JobTitleRepository.GetAll());
            return new BaseResponse<List<JobTitleResponse>>(jobTitles);
        }

        public async Task<BaseResponse<JobTitleResponse>> GetJobTitleById(int id)
        {
            var jobTitle = _mapper.Map<JobTitleResponse>(await _repository.JobTitleRepository.FindById(id));
            return new BaseResponse<JobTitleResponse>(jobTitle);
        }

        public async Task<BaseResponse<List<JobTitleResponse>>> GetJobTitleByDepartmentId(int departmentId)
        {
            var jobTitles = _mapper.Map<List<JobTitleResponse>>(await _repository.JobTitleRepository.FindByDepartmentId(departmentId));
            return new BaseResponse<List<JobTitleResponse>>(jobTitles);
        }

        public async Task<BaseResponse<int>> CreateJobTitle([FromBody] JobTitleRequest request)
        {
            var jobTitle = new JobTitle().SetBaseInformation(request.Name, request.DepartmentId);

            await _repository.JobTitleRepository.Create(jobTitle);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(jobTitle.Id);
        }

        public async Task<BaseResponse<int>> UpdateJobTitle([FromBody] JobTitleUpdateRequest request)
        {
            var jobTitle = await _repository.JobTitleRepository.FindById(request.Id);
            if (jobTitle == null) return new BaseResponse<int>(0, "Ünvan bulunamadı..");

            jobTitle.SetBaseInformation(request.Name, request.DepartmentId);
            _repository.JobTitleRepository.Update(jobTitle);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(jobTitle.Id);
        }

        public async Task<BaseResponse<bool>> DeleteJobTitle(int id)
        {
            var jobTitle = await _repository.JobTitleRepository.FindById(id);
            if (jobTitle == null) return new BaseResponse<bool>(false, "Ünvan bulunamadı..");

            //if (jobTitle.Users != null && jobTitle.Users.Count() > 0)
            //    return new BaseResponse<bool>(false, "Ünvana bağlı kullanıcı(lar) olmamalıdır..");

            await _repository.JobTitleRepository.Delete(jobTitle.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }
        #endregion
    }
}
