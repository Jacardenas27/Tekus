using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TekusProviders.Models;

namespace TekusProviders.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<DetailsProviderService> DetailsProviderService { get; set; }

        public DbSet<DetailsServiceCountry> DetailsServiceCountry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().ToTable("Providers", "Tekus");
            modelBuilder.Entity<Service>().ToTable("Services", "Tekus");
            modelBuilder.Entity<DetailsProviderService>().ToTable("DetailsProviderService", "Tekus");
            modelBuilder.Entity<DetailsServiceCountry>().ToTable("DetailsServiceCountry", "Tekus");
        }
    }
}
