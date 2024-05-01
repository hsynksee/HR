using HR.Data.Entities;
using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.LeaveSetting
{
    public class LeaveSettingResponse
    {
        public LeaveTypeEnum LeaveTypeId { get;  set; }
        public int MaxExperienceYear { get;  set; }
        public int MinExperienceYear { get;  set; }
        public int NumberOfMeritDays { get;  set; }
    }
}
