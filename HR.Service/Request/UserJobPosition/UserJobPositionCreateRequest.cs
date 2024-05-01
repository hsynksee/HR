using FluentValidation;
using HR.Data.Enums;
using HR.Service.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.UserJobPosition
{
    public class UserJobPositionCreateRequest
    {
        public int UserId { get; set; }
        public int? JobTitleId { get; set; }
        public int? ApprovalProcessUnitId { get; set; }
        public int? ManagerId { get; set; }
        public WorkingMethodEnum? WorkingMethod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class UserJobPositionCreateRequestValidator : AbstractValidator<UserJobPositionCreateRequest>
    {
        public UserJobPositionCreateRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı alanı boş olamaz");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Başlangıç tarih alanı boş olamaz");
        }
    }
}
