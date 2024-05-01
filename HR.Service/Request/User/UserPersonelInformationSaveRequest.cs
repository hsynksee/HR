using FluentValidation;
using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class UserPersonelInformationSaveRequest
    {
        public int UserId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }
        public MaritalStatusEnum? MaritalStatus { get; set; }
        public SpousesEmploymentStatusEnum? SpousesEmploymentStatus { get; set; }
        public GenderEnum? Gender { get; set; }
        public ObstacleDegreeEnum? ObstacleDegree { get; set; }
        public int? NationalityId { get; set; }
        public int? NumberOfChildren { get; set; }
        public BloodTypeEnum? BloodType { get; set; }
        public MilitaryStatusEnum? MilitaryStatus { get; set; }
        public DateTime? MilitaryPostponementDate { get; set; }
        public EducationStatusEnum? EducationStatus { get; set; }
        public EducationStatusEnum? HighestLevelOfEducationCompleted { get; set; }
        public string? LastCompletedEducationalInstitution { get; set; }
    }
}
