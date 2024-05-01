using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class Overtime : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public int DurationHour { get; protected set; }
        public int DurationMinute { get; protected set; }
        public string Description { get; protected set; }

        #region Virtuals
        public virtual User User { get; protected set; }
        #endregion

        public Overtime SetBaseInformation(int userId, DateTime startDate, int durationHour, int durationMinute, string description)
        {
            this.UserId = userId;
            this.StartDate = startDate;
            this.DurationHour = durationHour;
            this.DurationMinute = durationMinute;
            this.Description = description;

            return this;
        }
    }
}
