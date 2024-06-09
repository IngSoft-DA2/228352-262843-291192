﻿// <auto-generated />
using System;
using BuildingManagerDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuildingManagerDataAccess.Migrations
{
    [DbContext(typeof(BuildingManagerContext))]
    partial class BuildingManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BuildingManagerDomain.Entities.Apartment", b =>
                {
                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<bool?>("HasTerrace")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Rooms")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CommonExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ConstructionCompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionCompanyId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.ConstructionCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConstructionCompanies");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Deadline")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MaintainerStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MaintainerStaffId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("BuildingId", "ApartmentFloor", "ApartmentNumber");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
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

            modelBuilder.Entity("CompanyAdminAssociation", b =>
                {
                    b.Property<Guid>("ConstructionCompanyAdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConstructionCompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConstructionCompanyAdminId", "ConstructionCompanyId");

                    b.HasIndex("ConstructionCompanyId");

                    b.ToTable("CompanyAdminAssociations");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Admin", b =>
                {
                    b.HasBaseType("BuildingManagerDomain.Entities.User");

                    b.HasDiscriminator().HasValue("admin_user");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.ConstructionCompanyAdmin", b =>
                {
                    b.HasBaseType("BuildingManagerDomain.Entities.User");

                    b.HasDiscriminator().HasValue("constructionCompanyAdmin_user");
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
                        .HasForeignKey("OwnerEmail")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Building", b =>
                {
                    b.HasOne("BuildingManagerDomain.Entities.ConstructionCompany", null)
                        .WithMany()
                        .HasForeignKey("ConstructionCompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BuildingManagerDomain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Category", b =>
                {
                    b.HasOne("BuildingManagerDomain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Request", b =>
                {
                    b.HasOne("BuildingManagerDomain.Entities.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BuildingManagerDomain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagerDomain.Entities.MaintenanceStaff", "MaintenanceStaff")
                        .WithMany()
                        .HasForeignKey("MaintainerStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BuildingManagerDomain.Entities.Manager", null)
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagerDomain.Entities.Apartment", null)
                        .WithMany()
                        .HasForeignKey("BuildingId", "ApartmentFloor", "ApartmentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Category");

                    b.Navigation("MaintenanceStaff");
                });

            modelBuilder.Entity("CompanyAdminAssociation", b =>
                {
                    b.HasOne("BuildingManagerDomain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("ConstructionCompanyAdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagerDomain.Entities.ConstructionCompany", null)
                        .WithMany()
                        .HasForeignKey("ConstructionCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildingManagerDomain.Entities.Building", b =>
                {
                    b.Navigation("Apartments");
                });
#pragma warning restore 612, 618
        }
    }
}
