using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class UserOtherInformationConfiguration : IEntityTypeConfiguration<UserOtherInformation>
    {
        public void Configure(EntityTypeBuilder<UserOtherInformation> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.UserId).IsRequired();
        }
    }
}
