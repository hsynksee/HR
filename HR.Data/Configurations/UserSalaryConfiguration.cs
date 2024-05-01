using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class UserSalaryConfiguration : IEntityTypeConfiguration<UserSalary>
    {
        public void Configure(EntityTypeBuilder<UserSalary> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.Salary).IsRequired();
            builder.Property(c => c.CurrencyType).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
        }
    }
}
