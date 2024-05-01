using HR.Data.Entities;
using HR.Data.Enums;
using HR.Service.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.LeaveSetting
{
    public class LeaveSettingUpdateRequest:IdNameRequest
    {
        public LeaveTypeEnum LeaveTypeId { get;  set; }
        public int MaxExperienceYear { get;  set; }
        public int MinExperienceYear { get;  set; }
        public int NumberOfMeritDays { get;  set; }
    }
}
