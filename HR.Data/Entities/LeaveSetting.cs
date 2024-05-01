using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HR.Data.Entities
{
    public class LeaveSetting: AuditableBaseEntity
    {
        public LeaveTypeEnum LeaveTypeId { get; protected set; }
        public int MaxExperienceYear { get;protected set; }
        public int MinExperienceYear { get;protected set; }
        public int NumberOfMeritDays { get;protected set; }

        public LeaveSetting SetBaseInformation(LeaveTypeEnum leaveTypeId, int maxExperienceYear, int minExperienceYear, int numberOfMeritDays) { 
            this.LeaveTypeId = leaveTypeId;
            this.MaxExperienceYear = maxExperienceYear;
            this.MinExperienceYear = minExperienceYear;
            this.NumberOfMeritDays = numberOfMeritDays;
            return this;
        }
    }
}
