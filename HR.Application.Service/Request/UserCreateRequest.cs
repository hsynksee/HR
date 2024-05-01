using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Service.Request
{
    public class UserCreateRequest
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public string EmailJob { get; set; }
        public string EmailPersonality { get; set; }
        public string PhoneJob { get; set; }
        public string PhonePersonality { get; set; }
        public int ContractType { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public int UserTitleId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
