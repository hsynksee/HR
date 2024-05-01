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
    public class UserJobPositionUpdateRequest : UserJobPositionCreateRequest
    {
        public int Id { get; set; }
    }

    public class UserJobPositionUpdateRequestValidator : AbstractValidator<UserJobPositionUpdateRequest>
    {
        public UserJobPositionUpdateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Pozisyon Id alanı boş olamaz");
        }
    }
}
