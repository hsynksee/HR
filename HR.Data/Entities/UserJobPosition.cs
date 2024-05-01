using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class UserJobPosition : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public int? JobTitleId { get; protected set; }
        public int? ApprovalProcessUnitId { get; protected set; }
        public int? ManagerId { get; protected set; }
        public WorkingMethodEnum? WorkingMethod { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }

        #region Virtuals
        public virtual User User { get; protected set; }
        public virtual JobTitle JobTitle { get; protected set; }
        public virtual User Manager { get; protected set; }
        #endregion

        public UserJobPosition SetBaseInformation(int userId, int? jobTitleId, int? approvalProcessUnitId, int? managerId, WorkingMethodEnum? workingMethod, DateTime startDate, DateTime? endDate)
        {
            UserId= userId;
            JobTitleId = jobTitleId;
            ApprovalProcessUnitId = approvalProcessUnitId;
            ManagerId = managerId;
            WorkingMethod = workingMethod;
            StartDate= startDate;
            EndDate= endDate;

            return this;
        }

        public UserJobPosition Update(int? jobTitleId, int? approvalProcessUnitId, int? managerId, WorkingMethodEnum? workingMethod, DateTime startDate, DateTime? endDate)
        {
            JobTitleId = jobTitleId;
            ApprovalProcessUnitId = approvalProcessUnitId;
            ManagerId = managerId;
            WorkingMethod = workingMethod;
            StartDate= startDate;
            EndDate= endDate;

            return this;
        }
    }
}
