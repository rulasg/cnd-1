using Microsoft.EntityFrameworkCore;
using Demo.Models;

namespace Demo.Data
{
    public class DogContext : DbContext
    {
        public DogContext(DbContextOptions<DogContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("dogs");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { Id = 1, Name = "Buddy", Breed = "Golden Retriever", Owner = "John" },
                new Dog { Id = 2, Name = "Bella", Breed = "Labrador Retriever", Owner = "Emily" },
                new Dog { Id = 3, Name = "Charlie", Breed = "Beagle", Owner = "Michael" },
                new Dog { Id = 4, Name = "Max", Breed = "German Shepherd", Owner = "Sarah" },
                new Dog { Id = 5, Name = "Lucy", Breed = "Poodle", Owner = "David" },
                new Dog { Id = 6, Name = "Daisy", Breed = "Bulldog", Owner = "Emma" },
                new Dog { Id = 7, Name = "Bailey", Breed = "Boxer", Owner = "Daniel" },
                new Dog { Id = 8, Name = "Molly", Breed = "Rottweiler", Owner = "Sophia" },
                new Dog { Id = 9, Name = "Lola", Breed = "Dachshund", Owner = "James" },
                new Dog { Id = 10, Name = "Rocky", Breed = "Siberian Husky", Owner = "Olivia" }
            );

        }
    }
}
