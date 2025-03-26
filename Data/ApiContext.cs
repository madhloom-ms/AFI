using Microsoft.EntityFrameworkCore;
using AFI.Models;

namespace AFI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Surname).IsRequired().HasMaxLength(50);
                entity.Property(c => c.PolicyReferenceNumber).IsRequired().HasMaxLength(9);
                entity.Property(c => c.DateOfBirth).IsRequired(false);
                entity.Property(c => c.Email).HasMaxLength(255);
            });
        }
    }
}
