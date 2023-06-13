using Microsoft.EntityFrameworkCore;
using UkwWypozyczalnia.Models;

namespace UkwWypozyczalnia.DAL
{
    public class FilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }

        public FilmsContext(DbContextOptions<FilmsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            _ = modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Komedia" },
                new Category() { Id = 2, Name = "Horror" },
                new Category() { Id = 3, Name = "Fantasy" },
                new Category() { Id = 4, Name = "Familijne" }
            );

            _ = modelBuilder.Entity<Film>().HasData(
                new Film() { Id = 1, Title = "Film A", Price = 17.49f, Director = "Person A", CategoryId = 1 },
                new Film() { Id = 2, Title = "Film B", Price = 24.89f, Director = "Person B", CategoryId = 2 },
                new Film() { Id = 3, Title = "Film C", Price = 31.39f, Director = "Person C", CategoryId = 3 },
                new Film() { Id = 4, Title = "Film D", Price = 15.41f, Director = "Person D", CategoryId = 4 },
                new Film() { Id = 5, Title = "Film E", Price = 12.25f, Director = "Person D", CategoryId = 3 },
                new Film() { Id = 6, Title = "Film F", Price = 1.79f, Director = "Person D", CategoryId = 3 },
                new Film() { Id = 7, Title = "Film G", Price = 37.43f, Director = "Person A", CategoryId = 2 },
                new Film() { Id = 8, Title = "Film H", Price = 57.46f, Director = "Person B", CategoryId = 1 },
                new Film() { Id = 9, Title = "Film I", Price = 27.29f, Director = "Person C", CategoryId = 4 },
                new Film() { Id = 10, Title = "Film J", Price = 19.99f, Director = "Person B", CategoryId = 1 }
            );
        }
    }
}
