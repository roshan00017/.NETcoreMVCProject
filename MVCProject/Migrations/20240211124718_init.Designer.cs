﻿// <auto-generated />
using System;
using MVCProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCProject.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    [Migration("20240211124718_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCProject.Models.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4039),
                            ModifiedBy = 1,
                            ModifiedDate = new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4054),
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 2,
                            CreatedDate = new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4055),
                            ModifiedBy = 2,
                            ModifiedDate = new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4056),
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4057),
                            ModifiedBy = 1,
                            ModifiedDate = new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4058),
                            Name = "Category 3"
                        });
                });

            modelBuilder.Entity("MVCProject.Models.Domain.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            CategoryId = 1,
                            Description = "Description 1",
                            DueDate = new DateTime(2024, 2, 18, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4264),
                            IsCompleted = true,
                            Title = "Task 1",
                            UserId = 1
                        },
                        new
                        {
                            TaskID = 2,
                            CategoryId = 1,
                            Description = "Description 2",
                            DueDate = new DateTime(2024, 2, 25, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4279),
                            IsCompleted = false,
                            Title = "Task 2",
                            UserId = 2
                        },
                        new
                        {
                            TaskID = 3,
                            CategoryId = 2,
                            Description = "Description 3",
                            DueDate = new DateTime(2024, 3, 3, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4281),
                            IsCompleted = false,
                            Title = "Task 3",
                            UserId = 1
                        },
                        new
                        {
                            TaskID = 4,
                            CategoryId = 2,
                            Description = "Description 4",
                            DueDate = new DateTime(2024, 3, 10, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4282),
                            IsCompleted = false,
                            Title = "Task 4",
                            UserId = 2
                        },
                        new
                        {
                            TaskID = 5,
                            CategoryId = 3,
                            Description = "Description 5",
                            DueDate = new DateTime(2024, 3, 17, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4283),
                            IsCompleted = false,
                            Title = "Task 5",
                            UserId = 1
                        },
                        new
                        {
                            TaskID = 6,
                            CategoryId = 3,
                            Description = "Description 6",
                            DueDate = new DateTime(2024, 3, 24, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4285),
                            IsCompleted = false,
                            Title = "Task 6",
                            UserId = 2
                        },
                        new
                        {
                            TaskID = 7,
                            CategoryId = 1,
                            Description = "Description 7",
                            DueDate = new DateTime(2024, 3, 31, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4286),
                            IsCompleted = false,
                            Title = "Task 7",
                            UserId = 1
                        },
                        new
                        {
                            TaskID = 8,
                            CategoryId = 1,
                            Description = "Description 8",
                            DueDate = new DateTime(2024, 4, 7, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4288),
                            IsCompleted = false,
                            Title = "Task 8",
                            UserId = 2
                        },
                        new
                        {
                            TaskID = 9,
                            CategoryId = 2,
                            Description = "Description 9",
                            DueDate = new DateTime(2024, 4, 14, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4289),
                            IsCompleted = false,
                            Title = "Task 9",
                            UserId = 1
                        },
                        new
                        {
                            TaskID = 10,
                            CategoryId = 2,
                            Description = "Description 10",
                            DueDate = new DateTime(2024, 4, 21, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4290),
                            IsCompleted = false,
                            Title = "Task 10",
                            UserId = 2
                        },
                        new
                        {
                            TaskID = 11,
                            CategoryId = 3,
                            Description = "Description 11",
                            DueDate = new DateTime(2024, 4, 28, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4293),
                            IsCompleted = false,
                            Title = "Task 11",
                            UserId = 1
                        },
                        new
                        {
                            TaskID = 12,
                            CategoryId = 3,
                            Description = "Description 12",
                            DueDate = new DateTime(2024, 5, 5, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4294),
                            IsCompleted = false,
                            Title = "Task 12",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("MVCProject.Models.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "john@example.com",
                            Password = "password",
                            UserName = "john_doe"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "jane@example.com",
                            Password = "password",
                            UserName = "jane_doe"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "mike@example.com",
                            Password = "password",
                            UserName = "mike_miles"
                        });
                });

            modelBuilder.Entity("MVCProject.Models.Domain.Category", b =>
                {
                    b.HasOne("MVCProject.Models.Domain.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.Domain.User", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("MVCProject.Models.Domain.Task", b =>
                {
                    b.HasOne("MVCProject.Models.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
