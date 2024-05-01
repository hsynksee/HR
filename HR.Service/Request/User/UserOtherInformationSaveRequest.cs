using FluentValidation;
using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class UserOtherInformationSaveRequest
    {
        public int UserId { get; set; }
        public int? DistrictId { get; set; }
        public string? Address { get; set; }
        public string? PostCode { get; set; }
        public string? HomePhone { get; set; }
        public string? BankName { get; set; }
        public AccountTypeEnum? AccountType { get; set; }
        public string? AccountNumber { get; set; }
        public string? IBAN { get; set; }
        public string? EmergencyContactPerson { get; set; }
        public string? EmergencyContactDegree { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? ConnectionName { get; set; }
        public string? ConnectionAddress { get; set; }
    }
}
