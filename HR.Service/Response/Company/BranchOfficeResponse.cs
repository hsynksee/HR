using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class BranchOfficeResponse : IdNameResponse
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
