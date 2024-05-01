using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class UserOtherInformation : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public int? DistrictId { get; protected set; }
        public string? Address { get; protected set; }
        public string? PostCode { get; protected set; }
        public string? HomePhone { get; protected set; }
        public string? BankName { get; protected set; }
        public AccountTypeEnum? AccountType { get; protected set; }
        public string? AccountNumber { get; protected set; }
        public string? IBAN { get; protected set; }
        public string? EmergencyContactPerson { get; protected set; }
        public string? EmergencyContactDegree { get; protected set; }
        public string? EmergencyContactPhone { get; protected set; }
        public string? ConnectionName { get; protected set; }
        public string? ConnectionAddress { get; protected set; }


        #region Virtuals
        public virtual User User { get; protected set; }
        public virtual District District { get; protected set; }
        #endregion

        public UserOtherInformation SetBaseInformation(int userId, int? districtId, string? address, string? postCode, string? homePhone, string? bankName, AccountTypeEnum? accountType, string? accountNumber, string? iban, string? emergencyContactPerson, string? emergencyContactDegree, string? emergencyContactPhone, string? connectionName, string? connectionAddress)
        {
            UserId= userId;
            DistrictId= districtId;
            Address= address;
            PostCode= postCode;
            HomePhone= homePhone;
            BankName= bankName;
            AccountType= accountType;
            AccountNumber= accountNumber;
            IBAN= iban;
            EmergencyContactPerson= emergencyContactPerson;
            EmergencyContactDegree= emergencyContactDegree;
            EmergencyContactPhone= emergencyContactPhone;
            ConnectionName= connectionName;
            ConnectionAddress= connectionAddress;

            return this;
        }

        public UserOtherInformation Update(int? districtId, string? address, string? postCode, string? homePhone, string? bankName, AccountTypeEnum? accountType, string? accountNumber, string? iban, string? emergencyContactPerson, string? emergencyContactDegree, string? emergencyContactPhone, string? connectionName, string? connectionAddress)
        {
            DistrictId = districtId;
            Address = address;
            PostCode = postCode;
            HomePhone = homePhone;
            BankName = bankName;
            AccountType = accountType;
            AccountNumber = accountNumber;
            IBAN = iban;
            EmergencyContactPerson = emergencyContactPerson;
            EmergencyContactDegree = emergencyContactDegree;
            EmergencyContactPhone = emergencyContactPhone;
            ConnectionName = connectionName;
            ConnectionAddress = connectionAddress;

            return this;
        }
    }
}
