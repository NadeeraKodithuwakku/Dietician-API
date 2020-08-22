using Dietician.Domain.Diet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Database
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable("Plans", "Plan");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.ActivityLevel).IsRequired();
            builder.Property(p => p.Goal).IsRequired();
            builder.Property(p => p.Target).HasDefaultValue(0.0);
            builder.Property(p => p.Pace).IsRequired();
            builder.Property(p => p.Duration).HasDefaultValue(0);
            builder.Property(p => p.Name).IsRequired();
            builder.HasOne(p => p.User);

        }
    }
}
