using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class UserUpdateRequest : UserCreateRequest
    {
        public int Id { get; set; }
    }
}
