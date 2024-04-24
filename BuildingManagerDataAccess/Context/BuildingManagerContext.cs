﻿using BuildingManagerDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagerDataAccess.Context
{
    public class BuildingManagerContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MaintenanceStaff> MaintenanceStaff { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public BuildingManagerContext(DbContextOptions<BuildingManagerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().ToTable("Apartments").HasKey(a => new { a.BuildingId, a.Floor, a.Number });
            modelBuilder.Entity<Owner>().ToTable("Owners").HasKey(o => o.Email);
        }
    }
}
