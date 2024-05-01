using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.UserDemand
{
    public class OvertimeListResponse
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationHour { get; set; }
        public int DurationMinute { get; set; }
        public string Description { get; set; }
    }
}
