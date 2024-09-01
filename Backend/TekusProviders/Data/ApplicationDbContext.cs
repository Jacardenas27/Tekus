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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().ToTable("Providers", "Tekus");
        }
    }
}
