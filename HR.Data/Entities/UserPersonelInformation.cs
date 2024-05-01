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
    public partial class UserPersonelInformation : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public DateTime? DateOfBirth { get; protected set; }
        public string IdentityNumber { get; protected set; }
        public MaritalStatusEnum? MaritalStatus { get; protected set; }
        public SpousesEmploymentStatusEnum? SpousesEmploymentStatus { get; protected set; }
        public GenderEnum? Gender { get; protected set; }
        public ObstacleDegreeEnum? ObstacleDegree { get; protected set; }
        public int? NationalityId { get; protected set; }
        public int? NumberOfChildren { get; protected set; }
        public BloodTypeEnum? BloodType { get; protected set; }
        public MilitaryStatusEnum? MilitaryStatus { get; protected set; }
        public DateTime? MilitaryPostponementDate { get; protected set; }
        public EducationStatusEnum? EducationStatus { get; protected set; }
        public EducationStatusEnum? HighestLevelOfEducationCompleted { get; protected set; }
        public string? LastCompletedEducationalInstitution { get; protected set; }


        #region Virtuals
        public virtual User User { get; protected set; }
        public virtual Country Nationality { get; protected set; }
        #endregion

        public UserPersonelInformation SetBaseInformation(int userId, DateTime? dateOfBirth, string identityNumber, MaritalStatusEnum? maritalStatus, SpousesEmploymentStatusEnum? spousesEmploymentStatus, GenderEnum? gender, ObstacleDegreeEnum? obstacleDegree, int? numberOfChildren, BloodTypeEnum? bloodType, MilitaryStatusEnum? militaryStatus, DateTime? militaryPostponementDate, EducationStatusEnum? educationStatus, EducationStatusEnum? highestLevelOfEducationCompleted, string? lastCompletedEducationalInstitution)
        {
            UserId= userId;
            DateOfBirth= dateOfBirth;
            IdentityNumber= identityNumber;
            MaritalStatus= maritalStatus;
            SpousesEmploymentStatus= spousesEmploymentStatus;
            Gender= gender;
            ObstacleDegree= obstacleDegree;
            NumberOfChildren= numberOfChildren;
            BloodType= bloodType;
            MilitaryStatus= militaryStatus;
            MilitaryPostponementDate = militaryPostponementDate;
            EducationStatus= educationStatus;
            HighestLevelOfEducationCompleted= highestLevelOfEducationCompleted;
            LastCompletedEducationalInstitution = lastCompletedEducationalInstitution;

            return this;
        }

        public UserPersonelInformation Update(DateTime? dateOfBirth, string identityNumber, MaritalStatusEnum? maritalStatus, SpousesEmploymentStatusEnum? spousesEmploymentStatus, GenderEnum? gender, ObstacleDegreeEnum? obstacleDegree, int? numberOfChildren, BloodTypeEnum? bloodType, MilitaryStatusEnum? militaryStatus, DateTime? militaryPostponementDate, EducationStatusEnum? educationStatus, EducationStatusEnum? highestLevelOfEducationCompleted, string? lastCompletedEducationalInstitution)
        {
            DateOfBirth = dateOfBirth;
            IdentityNumber = identityNumber;
            MaritalStatus = maritalStatus;
            SpousesEmploymentStatus = spousesEmploymentStatus;
            Gender = gender;
            ObstacleDegree = obstacleDegree;
            NumberOfChildren = numberOfChildren;
            BloodType = bloodType;
            MilitaryStatus = militaryStatus;
            MilitaryPostponementDate = militaryPostponementDate;
            EducationStatus = educationStatus;
            HighestLevelOfEducationCompleted = highestLevelOfEducationCompleted;
            LastCompletedEducationalInstitution = lastCompletedEducationalInstitution;

            return this;
        }
    }
}
