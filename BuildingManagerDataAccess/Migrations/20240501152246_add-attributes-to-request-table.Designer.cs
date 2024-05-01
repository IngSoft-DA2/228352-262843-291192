﻿// <auto-generated />
using System;
using BuildingManagerDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuildingManagerDataAccess.Migrations
{
    [DbContext(typeof(BuildingManagerContext))]
    [Migration("20240501152246_add-attributes-to-request-table")]
    partial class addattributestorequesttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BuildingManagerDomain.Entities.Apartment", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<bool>("HasTerrace")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("BuildingId", "Floor", "Number");

                    b.HasIndex("OwnerEmail");

                    b.ToTable("Apartments", (string)null);
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CommonExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ConstructionCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Deadline")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Owner", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Owners", (string)null);
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ApartmentFloor")
                        .HasColumnType("int");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<long>("AttendedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CompletedAt")
                        .HasColumnType("bigint");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MaintainerStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MaintainerStaffId");

                    b.HasIndex("BuildingId", "ApartmentFloor", "ApartmentNumber");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid?>("SessionToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("user_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("user_type").HasValue("User");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Admin", b =>
                {
                    b.HasBaseType("BuildingManagerDomain.Entities.User");

                    b.HasDiscriminator().HasValue("admin_user");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.MaintenanceStaff", b =>
                {
                    b.HasBaseType("BuildingManagerDomain.Entities.User");

                    b.HasDiscriminator().HasValue("maintenance_user");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Manager", b =>
                {
                    b.HasBaseType("BuildingManagerDomain.Entities.User");

                    b.HasDiscriminator().HasValue("manager_user");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Apartment", b =>
                {
                    b.HasOne("BuildingManagerDomain.Entities.Building", null)
                        .WithMany("Apartments")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagerDomain.Entities.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerEmail");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Request", b =>
                {
                    b.HasOne("BuildingManagerDomain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagerDomain.Entities.MaintenanceStaff", "MaintenanceStaff")
                        .WithMany()
                        .HasForeignKey("MaintainerStaffId");

                    b.HasOne("BuildingManagerDomain.Entities.Apartment", null)
                        .WithMany()
                        .HasForeignKey("BuildingId", "ApartmentFloor", "ApartmentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("MaintenanceStaff");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Building", b =>
                {
                    b.Navigation("Apartments");
                });
#pragma warning restore 612, 618
        }
    }
}
