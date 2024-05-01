using HR.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.UserDemand
{
    public class OvertimeCreateRequest
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationHour { get; set; }
        public int DurationMinute { get; set; }
        public string Description { get; set; }

    }
}
