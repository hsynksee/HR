using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class UserLeave : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public LeaveTypeEnum LeaveTypeId { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string Description { get; protected set; }
        public DateTime OvertimeStart { get; protected set; }
        public int? TemporaryUserId { get; protected set; }
        public StatusTypeEnum Status { get; protected set; }
        public decimal LeavePeriod { get; protected set; }

        #region Virtuals
        public virtual User User { get; protected set; }
        public virtual User TemporaryUser { get; protected set; }
        #endregion

        public UserLeave SetBaseInformation(int userId, LeaveTypeEnum leaveTypeId, DateTime startDate, DateTime endDate, string description, DateTime overtimeStart, int? temporaryUserId, StatusTypeEnum status, decimal leavePeriod)
        {
            this.UserId = userId;
            this.LeaveTypeId = leaveTypeId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
            this.OvertimeStart = overtimeStart;
            this.TemporaryUserId = temporaryUserId;
            this.Status = status;
            this.LeavePeriod = leavePeriod;
            return this;
        }
    }
}
