using HR.Data.Entities;
using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.UserDemand
{
    public class UserLeaveCreateRequest
    {
        public int UserId { get; set; }
        public LeaveTypeEnum LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int? TemporaryUserId { get; set; }
        public StatusTypeEnum Status { get; set; }
        public decimal LeavePeriod { get; set; }
        public DateTime OvertimeStart { get; set; }
    }
}
