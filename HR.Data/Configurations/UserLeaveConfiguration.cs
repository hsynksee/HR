using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class UserLeaveConfiguration : IEntityTypeConfiguration<UserLeave>
    {
        public void Configure(EntityTypeBuilder<UserLeave> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.LeaveTypeId).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired();
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.LeavePeriod).IsRequired();
        }
    }
}
