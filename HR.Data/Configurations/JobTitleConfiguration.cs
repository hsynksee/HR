using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.DepartmentId).IsRequired();
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
