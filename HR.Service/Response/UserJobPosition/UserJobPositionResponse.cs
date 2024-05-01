using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.UserJobPosition
{
    public class UserJobPositionResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchOfficeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobTitleId { get; set; }
        public string JobTitle { get; set; }
        public int? ApprovalProcessUnitId { get; set; }
        public string ApprovalProcessUnit { get; set; }
        public int? ManagerId { get; set; }
        public string Manager { get; set; }
        public WorkingMethodEnum? WorkingMethod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
