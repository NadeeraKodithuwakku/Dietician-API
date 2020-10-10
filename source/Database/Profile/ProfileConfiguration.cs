using Dietician.Domain.Diet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Database
{
    public sealed class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles", "Profile");

            builder.HasKey(profile => profile.Id);

            builder.Property(profile => profile.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(profile => profile.Weight).IsRequired();
            builder.Property(profile => profile.TargetWeight).HasDefaultValue(0.0);
            builder.Property(profile => profile.CurrentWeight).HasDefaultValue(0.0);
            builder.Property(profile => profile.Height).IsRequired();
            builder.Property(profile => profile.Age).IsRequired();
            builder.Property(profile => profile.Gender).IsRequired();
            builder.Property(profile => profile.IsVeg).IsRequired();
            builder.Property(profile => profile.ActivityLevel).IsRequired();
            builder.Property(profile => profile.Goal).IsRequired();
            builder.Property(profile => profile.Pace).IsRequired();

            builder.HasOne(profile => profile.User);
            builder.HasIndex(profile => profile.UserId).IsUnique();
        }
    }
}
