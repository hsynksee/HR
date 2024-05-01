using FluentValidation;
using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class UserCreateRequest
    {
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
        public List<int> Roles { get; set; }
    }

    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş olamaz");
            RuleFor(x => x.EmailBusiness).NotEmpty().WithMessage("İş email alanı boş olamaz");
            RuleFor(x => x.Roles).NotEmpty().WithMessage("En az bir rol ataması yapılmalıdır.");
        }
    }
}
