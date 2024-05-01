using HR.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Helpers;

namespace HR.Data.Configurations
{
    class PossessionCategoryConfiguration : IEntityTypeConfiguration<PossessionCategory>
    {
        public void Configure(EntityTypeBuilder<PossessionCategory> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.Name).HasMaxLength(250).IsRequired();
        }
    }
    
}
