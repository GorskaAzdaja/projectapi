﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAPI.Models;

#nullable disable

namespace ProjectAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectAPI.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectID"), 1L, 1);

                    b.Property<DateTime?>("Completion_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Project_Priority")
                        .HasColumnType("int");

                    b.Property<int>("Project_Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectID = 1,
                            Name = "First Project",
                            Project_Priority = 2,
                            Project_Status = 1,
                            Start_Date = new DateTime(2022, 2, 8, 19, 4, 31, 961, DateTimeKind.Local).AddTicks(4086)
                        },
                        new
                        {
                            ProjectID = 2,
                            Completion_Date = new DateTime(2022, 2, 8, 19, 4, 31, 961, DateTimeKind.Local).AddTicks(4132),
                            Name = "Second Project",
                            Project_Priority = 1,
                            Project_Status = 2,
                            Start_Date = new DateTime(2022, 2, 8, 19, 4, 31, 961, DateTimeKind.Local).AddTicks(4129)
                        });
                });

            modelBuilder.Entity("ProjectAPI.Models.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("Task_Priority")
                        .HasColumnType("int");

                    b.Property<int>("Task_Status")
                        .HasColumnType("int");

                    b.HasKey("TaskID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            Description = "Some description 1",
                            Name = "First task in first project",
                            ProjectID = 1,
                            Task_Priority = 0,
                            Task_Status = 0
                        },
                        new
                        {
                            TaskID = 2,
                            Description = "Some description 2",
                            Name = "Second task in first project",
                            ProjectID = 1,
                            Task_Priority = 2,
                            Task_Status = 1
                        },
                        new
                        {
                            TaskID = 3,
                            Description = "Some description 3",
                            Name = "Third task in second project",
                            ProjectID = 2,
                            Task_Priority = 1,
                            Task_Status = 0
                        });
                });

            modelBuilder.Entity("ProjectAPI.Models.Task", b =>
                {
                    b.HasOne("ProjectAPI.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectAPI.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
