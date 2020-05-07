using Dietician.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dietician.Database
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(user => user.Status).IsRequired();

            builder.OwnsOne(user => user.FullName, ownedBuilder =>
            {
                ownedBuilder.Property(fullName => fullName.Name).HasColumnName(nameof(FullName.Name)).HasMaxLength(100).IsRequired();
                ownedBuilder.Property(fullName => fullName.Surname).HasColumnName(nameof(FullName.Surname)).HasMaxLength(200).IsRequired();
            });

            builder.OwnsOne(user => user.Email, ownedBuilder =>
            {
                ownedBuilder.Property(email => email.Value).HasColumnName(nameof(User.Email)).HasMaxLength(300).IsRequired();
                ownedBuilder.HasIndex(email => email.Value).IsUnique();
            });

            builder.HasOne(user => user.Auth);
        }
    }
}
