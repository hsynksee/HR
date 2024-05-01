using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailBusiness { get; set; }
        public string EmailPersonal { get; set; }
        public string PhoneBusiness { get; set; }
        public string PhonePersonal { get; set; }
        public DateTime? StartDate { get; set; }
        public AccessTypeEnum? AccessType { get; set; }
        public ContractTypeEnum? ContractType { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public string? ProfilPicture { get; set; }
        public string? JobTitle { get; set; }
        public bool IsActive { get; set; }
        public List<int> Roles { get; set; }
    }
}
