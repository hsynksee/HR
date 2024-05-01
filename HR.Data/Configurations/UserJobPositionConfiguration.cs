using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class UserJobPositionConfiguration : IEntityTypeConfiguration<UserJobPosition>
    {
        public void Configure(EntityTypeBuilder<UserJobPosition> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
        }
    }
}
