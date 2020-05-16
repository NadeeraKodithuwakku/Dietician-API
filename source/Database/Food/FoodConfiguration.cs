using Dietician.Domain.Diet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Database
{
    public sealed class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Foods", "Food");
            builder.HasKey(food => food.Id);

            builder.Property(food => food.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(food => food.Name).IsRequired();
            builder.Property(food => food.Carbohydrate).IsRequired();
            builder.Property(food => food.Protine).IsRequired();
            builder.Property(food => food.Fat).IsRequired();

        }
    }
}
