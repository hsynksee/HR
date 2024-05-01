using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.RoleId).IsRequired();
            builder.Property(c => c.PermissionId).IsRequired();
        }
    }
}
