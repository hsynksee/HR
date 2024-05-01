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
     class LeaveSettingConfiguration :IEntityTypeConfiguration<LeaveSetting>
    {
        public void Configure(EntityTypeBuilder<LeaveSetting> builder)
        {
            builder.AddDefaults();
            builder.Property(c => c.MaxExperienceYear).IsRequired();
            builder.Property(c => c.MinExperienceYear).IsRequired();
            builder.Property(c=>c.LeaveTypeId).IsRequired();
            builder.Property(c=>c.NumberOfMeritDays).IsRequired();
        }
    }
}
