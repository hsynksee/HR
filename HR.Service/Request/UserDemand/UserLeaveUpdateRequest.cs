using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.UserDemand
{
    public class UserLeaveUpdateRequest : UserLeaveCreateRequest
    {
        public int Id { get; set; }
    }
}
