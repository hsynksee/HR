using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class DepartmentManagerConfiguration : IEntityTypeConfiguration<DepartmentManager>
    {
        public void Configure(EntityTypeBuilder<DepartmentManager> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.DepartmentId).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
        }
    }
}
