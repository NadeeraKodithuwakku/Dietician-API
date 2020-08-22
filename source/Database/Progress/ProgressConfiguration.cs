using Dietician.Domain.Diet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Dietician.Database
{
    public sealed class ProgressConfiguration : IEntityTypeConfiguration<Progress>
    {
        public void Configure(EntityTypeBuilder<Progress> builder)
        {
            builder.ToTable("Progress", "Progress");

            builder.HasKey(progress => progress.Id);

            builder.Property(progress => progress.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(progress => progress.Weight).IsRequired();
            builder.Property(progress => progress.Date).IsRequired();

            builder.HasOne(progress => progress.User);
        }
    }
}
