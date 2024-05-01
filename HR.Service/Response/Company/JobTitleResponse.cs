using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class JobTitleResponse : IdNameResponse
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}
