using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class User : AuditableBaseEntity
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string? EmailBusiness { get; protected set; }
        public string? EmailPersonal { get; protected set; }
        public string? PhoneBusiness { get; protected set; }
        public string? PhonePersonal { get; protected set; }
        public DateTime? StartDate { get; protected set; }
        public AccessTypeEnum? AccessType { get; protected set; }
        public ContractTypeEnum? ContractType { get; protected set; }
        public DateTime? ContractEndDate { get; protected set; }
        public byte[] PasswordSalt { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public bool IsActive { get; set; } = true;
        public string? ProfilPicture { get; protected set; }
        public DateTime? LastLoginDate { get; protected set; }
        public Guid? ForgotPasswordKey { get; protected set; }
        public DateTime? ForgotPasswordValidDate { get; protected set; }


        #region Virtuals
        public virtual ICollection<UserRole> UserRoles { get; protected set; }
        public virtual ICollection<Overtime> Overtimes { get; protected set; }
        public virtual UserPersonelInformation UserPersonelInformation { get; protected set; }
        public virtual UserOtherInformation UserOtherInformation { get; protected set; }
        public virtual ICollection<UserSalary> UserSalaries { get; protected set; }
        #endregion

        public User SetBaseInformation(string name, string surname, string emailBusiness, string emailPersonal, string phoneBusiness, string phonePersonal, DateTime? startDate, AccessTypeEnum? accessType, ContractTypeEnum? contractType, DateTime? contractEndDate, byte[] passwordSalt, byte[] passwordHash)
        {
            Name = name;
            Surname = surname;
            EmailBusiness = emailBusiness;
            EmailPersonal = emailPersonal;
            PhoneBusiness = phoneBusiness;
            PhonePersonal= phonePersonal;
            StartDate = startDate;
            AccessType = accessType;
            ContractType = contractType;
            ContractEndDate = contractEndDate;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            
            UserRoles = new List<UserRole>();

            return this;
        }

        public User Update(string name, string surname, string emailBusiness, string emailPersonal, string phoneBusiness, string phonePersonal, DateTime? startDate, AccessTypeEnum? accessType, ContractTypeEnum? contractType, DateTime? contractEndDate)
        {
            Name = name;
            Surname = surname;
            EmailBusiness = emailBusiness;
            EmailPersonal = emailPersonal;
            PhoneBusiness = phoneBusiness;
            PhonePersonal = phonePersonal;
            StartDate = startDate;
            AccessType = accessType;
            ContractType = contractType;
            ContractEndDate = contractEndDate;

            return this;
        }

        public User SetActive(bool active)
        {
            IsActive = active;

            return this;
        }

        public User SetLoginDate()
        {
            LastLoginDate = DateTime.Now;

            return this;
        }

        public User SetForgotPasswordKey(Guid guid)
        {
            this.ForgotPasswordKey = guid;

            return this;
        }

        public User SetChangePassword(byte[] passwordSalt, byte[] passwordHash)
        {
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            ForgotPasswordKey = null;
            ForgotPasswordValidDate = null;

            return this;
        }

        public void AdjustRoles(List<int> roles)
        {
            UserRoles.Clear();

            roles.ForEach(p =>
            {
                UserRoles.Add(new UserRole(Id, p));
            });
        }
    }
}
