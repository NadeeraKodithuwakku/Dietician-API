﻿// <auto-generated />
using System;
using Dietician.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dietician.Database.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200809124859_AddPlanTableNewColumns")]
    partial class AddPlanTableNewColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dietician.Domain.Auth", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Auths","Auth");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Login = "admin",
                            Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                            Roles = 3,
                            Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                        });
                });

            modelBuilder.Entity("Dietician.Domain.Diet.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Carbohydrate")
                        .HasColumnType("real");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<float>("Fat")
                        .HasColumnType("real");

                    b.Property<int>("FoodCategory")
                        .HasColumnType("int");

                    b.Property<string>("FoodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Protine")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Foods","Food");
                });

            modelBuilder.Entity("Dietician.Domain.Diet.Plan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityLevel")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pace")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Target")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("Plans","Plan");
                });

            modelBuilder.Entity("Dietician.Domain.Diet.Profile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsPregnant")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles","Profile");
                });

            modelBuilder.Entity("Dietician.Domain.Diet.Progress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Progress","Progress");
                });

            modelBuilder.Entity("Dietician.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AuthId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthId");

                    b.ToTable("Users","User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AuthId = 1L,
                            Status = 1
                        });
                });

            modelBuilder.Entity("Dietician.Domain.Diet.Profile", b =>
                {
                    b.HasOne("Dietician.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Dietician.Domain.Diet.Progress", b =>
                {
                    b.HasOne("Dietician.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Dietician.Domain.User", b =>
                {
                    b.HasOne("Dietician.Domain.Auth", "Auth")
                        .WithMany()
                        .HasForeignKey("AuthId");

                    b.OwnsOne("Dietician.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("nvarchar(300)")
                                .HasMaxLength(300);

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasFilter("[Email] IS NOT NULL");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = 1L,
                                    Value = "administrator@administrator.com"
                                });
                        });

                    b.OwnsOne("Dietician.Domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnName("Surname")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = 1L,
                                    Name = "Administrator",
                                    Surname = "Administrator"
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
