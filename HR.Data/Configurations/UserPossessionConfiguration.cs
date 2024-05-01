using HR.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Configurations
{
    class UserPossessionConfiguration : IEntityTypeConfiguration<UserPossession>
    {
        public void Configure(EntityTypeBuilder<UserPossession> builder)
        {
            builder.AddDefaults();
            builder.Property(a => a.IssueDate).IsRequired();
            builder.Property(a => a.ReturnDate).IsRequired();
        }
    }
}