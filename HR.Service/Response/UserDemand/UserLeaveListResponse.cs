using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.UserDemand
{
    public class UserLeaveListResponse
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string LeaveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string TemporaryUser { get; set; }
        public DateTime CreateDate { get; set; }
        public double? LeaveDays { get; set; }
        public DateTime? OvertimeStart { get; set; }
        public string Status { get; set; }
    }
}
