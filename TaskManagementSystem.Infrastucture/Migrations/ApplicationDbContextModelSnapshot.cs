﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.Infrastucture.Data;

#nullable disable

namespace TaskManagementSystem.Infrastucture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRead")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("NotificationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.Notification", b =>
                {
                    b.HasOne("TaskManagementSystem.Core.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.Project", b =>
                {
                    b.HasOne("TaskManagementSystem.Core.Entities.Tasks", "Tasks")
                        .WithOne("Project")
                        .HasForeignKey("TaskManagementSystem.Core.Entities.Project", "TaskId");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.Tasks", b =>
                {
                    b.HasOne("TaskManagementSystem.Core.Entities.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.Tasks", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("TaskManagementSystem.Core.Entities.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
