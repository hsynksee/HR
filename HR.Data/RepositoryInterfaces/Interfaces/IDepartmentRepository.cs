using HR.Data.Abstractions;
using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces.Interfaces
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        Task<List<Department>> FindByBranchOfficeId(int branchOfficeId);
        Task<DepartmentManager> DepartmentManagerFindById(int id);
        Task<List<DepartmentManager>> DepartmentManagerFindAllDepartmentId(int departmentId);
        Task DepartmentManagerDelete(int id);
    }
}
