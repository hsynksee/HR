using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class BranchOfficeConfiguration : IEntityTypeConfiguration<BranchOffice>
    {
        public void Configure(EntityTypeBuilder<BranchOffice> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.CompanyId).IsRequired();
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
