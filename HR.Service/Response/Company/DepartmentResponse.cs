using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class DepartmentResponse : IdNameResponse
    {
        public int BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }
        public List<IdNameResponse> Managers { get; set;}

    }
}
