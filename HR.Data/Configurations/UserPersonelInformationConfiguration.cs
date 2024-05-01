using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class UserPersonelInformationConfiguration : IEntityTypeConfiguration<UserPersonelInformation>
    {
        public void Configure(EntityTypeBuilder<UserPersonelInformation> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.UserId).IsRequired();
        }
    }
}
