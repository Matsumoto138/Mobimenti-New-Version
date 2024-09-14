using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MobimentiNewVersion.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CV3DMKP;initial catalog=MobimentiDb;integrated security=true;TrustServerCertificate=True");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Licence (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Licence)
                .WithOne(l => l.User)
                .HasForeignKey<Licence>(l => l.UserId);

            // Mentor - Appointment (1:N)
            modelBuilder.Entity<Mentor>()
                .HasMany(m => m.Appointments)
                .WithOne(a => a.Mentor)
                .HasForeignKey(a => a.MentorId);

            // User - Appointment (1:N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Appointments)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            // User - Sale (1:N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Sales)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            // Package - Sale (1:N)
            modelBuilder.Entity<Package>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Package)
                .HasForeignKey(s => s.PackageId);
        }


    }
}
