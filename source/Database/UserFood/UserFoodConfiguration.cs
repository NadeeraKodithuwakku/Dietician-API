using Dietician.Domain.Diet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Database
{
    public sealed class UserFoodConfiguration : IEntityTypeConfiguration<UserFood>
    {
        public void Configure(EntityTypeBuilder<UserFood> builder)
        {
            builder.ToTable("UserFoods", "UserFood");

            builder.HasKey(food => food.Id);
            builder.Property(food => food.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(food => food.UserId).IsRequired();
            builder.Property(food => food.FoodId).IsRequired();

            builder.HasOne(food => food.User);
            builder.HasOne(food => food.Food);
        }
    }
}
