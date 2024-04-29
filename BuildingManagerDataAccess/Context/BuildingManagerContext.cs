﻿using BuildingManagerDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace BuildingManagerDataAccess.Context
{
    [ExcludeFromCodeCoverage]
    public class BuildingManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MaintenanceStaff> MaintenanceStaff { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Request> Requests { get; set; }

        public BuildingManagerContext(DbContextOptions<BuildingManagerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasDiscriminator<string>("user_type")
                    .HasValue<Admin>("admin_user")
                    .HasValue<Manager>("manager_user")
                    .HasValue<MaintenanceStaff>("maintenance_user");

            modelBuilder.Entity<Apartment>().ToTable("Apartments").HasKey(a => new { a.BuildingId, a.Floor, a.Number });
            modelBuilder.Entity<Owner>().ToTable("Owners").HasKey(o => o.Email);
            
            modelBuilder.Entity<Request>()
                .HasOne<Apartment>()
                .WithMany()
                .HasForeignKey(r => new { r.BuildingId, r.ApartmentFloor, r.ApartmentNumber });
            modelBuilder.Entity<Request>()
                        .HasOne<Category>()
                        .WithMany()
                        .HasForeignKey(r => r.CategoryId);
            modelBuilder.Entity<Request>()
                        .HasOne<MaintenanceStaff>()
                        .WithMany()
                        .HasForeignKey(r => r.MaintainerId)
                        .IsRequired(false);
        }
    }
}
