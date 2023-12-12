using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Membership>? Memberships { get; set; }
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>()
                .Property(m => m.DiscountRate)
                .HasColumnType("decimal(18,2)");

            // Other entity configurations...

            base.OnModelCreating(modelBuilder);
        }

    }
}
