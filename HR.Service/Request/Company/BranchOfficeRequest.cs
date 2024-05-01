using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class BranchOfficeRequest : NameRequest
    {
        public int CompanyId { get; set; }
    }
}
