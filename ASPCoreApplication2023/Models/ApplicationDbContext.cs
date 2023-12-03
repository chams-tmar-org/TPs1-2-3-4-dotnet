using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Ajout des DbSet pour mapper les entités avec les tables de la base de données.
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Membership>? Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            string GenreJSon = System.IO.File.ReadAllText("Genre.Json");
            List<Genre>? genres = System.Text.Json.
            JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                model.Entity<Genre>()
                .HasData(c);
        }

    }
}
