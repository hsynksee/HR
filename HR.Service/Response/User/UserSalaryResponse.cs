using HR.Data.Enums;
using HR.Service.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.User
{
    public class UserSalaryResponse : UserSalaryCreateRequest
    {
        public int Id { get; set; }
    }
}
